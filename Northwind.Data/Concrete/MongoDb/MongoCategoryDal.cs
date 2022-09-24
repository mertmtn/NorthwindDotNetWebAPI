using Northwind.Core.DataAccess.NoSql.MongoDb;
using Northwind.Data.Abstract;
using Northwind.Entity.Concrete;

namespace Northwind.Data.Concrete.MongoDb
{
    public class MongoCategoryDal : MongoEntityRepositoryBase<Category>, ICategoryDal
    {
        public MongoCategoryDal(IMongoDbContext context) : base(context)
        {

        }
    }
}
