using Northwind.Core;
using Northwind.Entity.Concrete;
using Northwind.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Northwind.Business.Abstract
{
    public interface ICategoryService
    { 
        IDataResult<List<CategoryDTO>> GetAll();
        IResult Add(Category category);
        IResult Update(Category category, Expression<Func<Category, bool>> filter = null);
        IResult Delete(Category category, Expression<Func<Category, bool>> filter = null);
        IDataResult<CategoryDTO> GetById(Expression<Func<Category, bool>> filter = null);
    }
}
