using MongoDB.Driver;
using Northwind.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Northwind.Core.DataAccess.NoSql.MongoDb
{
    public class MongoEntityRepositoryBase<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly IMongoDbContext Context;
        protected IMongoCollection<TEntity> DbSet;

        protected MongoEntityRepositoryBase(IMongoDbContext context)
        {
            Context = context;
            DbSet = Context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public void Add(TEntity entity)
        {
            DbSet.InsertOneAsync(entity);
        }

        public void Delete(TEntity entity, Expression<Func<TEntity, bool>> filter)
        {
            DbSet.DeleteOneAsync(Builders<TEntity>.Filter.Where(filter));
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.FindAsync(Builders<TEntity>.Filter.Where(filter)).Result?.FirstOrDefault();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            var mongoFilter = filter == null ? Builders<TEntity>.Filter.Empty : Builders<TEntity>.Filter.Where(filter);
            return DbSet.FindAsync(mongoFilter).Result?.ToList();            
        }

        public void Update(TEntity entity, Expression<Func<TEntity, bool>> filter)
        {
            DbSet.FindOneAndReplaceAsync(filter, entity);
        }
    }
}
