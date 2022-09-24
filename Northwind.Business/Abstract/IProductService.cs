using Northwind.Core;
using Northwind.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Northwind.Business.Abstract
{
    public interface IProductService
    {        
        IDataResult<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null);
        IResult Add(Product product);
        IResult Update(Product product, Expression<Func<Product, bool>> filter=null);



        IResult Delete(Product product, Expression<Func<Product, bool>> filter = null);
        IDataResult<Product> GetById(Expression<Func<Product, bool>> filter = null);
    }
}
