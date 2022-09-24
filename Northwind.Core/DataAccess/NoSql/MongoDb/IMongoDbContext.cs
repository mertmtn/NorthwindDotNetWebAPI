using MongoDB.Driver;

namespace Northwind.Core.DataAccess.NoSql.MongoDb
{
    public interface IMongoDbContext
    {
        IMongoCollection<IEntity> GetCollection<IEntity>(string name);
    }
}
