using Northwind.Business.Abstract;
using Northwind.Business.Constants.Messages;
using Northwind.Core;
using Northwind.Core.Success;
using Northwind.Data.Abstract;
using Northwind.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        ////[ValidationAspect(typeof(ProductValidator), Priority = 1)]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(ProductMessage.ProductAddedSuccessfully);
        }

        //[ValidationAspect(typeof(ProductValidator), Priority = 1)]
        public IResult Update(Product product, Expression<Func<Product, bool>> filter = null)
        {          
            _productDal.Update(product, filter);
            return new SuccessResult(ProductMessage.ProductUpdatedSuccessfully);
        }


        public IResult Delete(Product product, Expression<Func<Product, bool>> filter = null)
        {
            
            _productDal.Delete(product, filter);
            return new SuccessResult(ProductMessage.ProductDeletedSuccessfully);
        }

        public IDataResult<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(filter));
        }

        public IDataResult<Product> GetById(Expression<Func<Product, bool>> filter = null)
        {
           
            return new SuccessDataResult<Product>(_productDal.Get(filter));
        }
    }
}
