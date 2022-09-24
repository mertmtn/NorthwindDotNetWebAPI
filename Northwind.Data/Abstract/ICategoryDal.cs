using Northwind.Core.DataAccess;
using Northwind.Entity.Concrete;

namespace Northwind.Data.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {

    }
}
