using Northwind.Core.DataAccess.Rdbms.Dapper;
using Northwind.Data.Abstract;
using Northwind.Entity.Concrete;

namespace Northwind.Data.Concrete.Dapper
{
    public class DapperProductDal : DapperGenericRepository<Product>, IProductDal
    {
     
    }
}
