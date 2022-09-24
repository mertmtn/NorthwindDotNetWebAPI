using Northwind.Core.DataAccess.NoSql.MongoDb;
using Northwind.Data.Abstract;
using Northwind.Entity.Concrete;

namespace Northwind.Data.Concrete.MongoDb
{
    public class MongoProductDal : MongoEntityRepositoryBase<Product>, IProductDal
    {
        public MongoProductDal(IMongoDbContext context) : base(context)
        {

        }
    }
}
