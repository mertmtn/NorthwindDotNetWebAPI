using Northwind.Business.Abstract;
using Northwind.Business.Constants.Messages;
using Northwind.Core;
using Northwind.Core.Entities.Mapping;
using Northwind.Core.Success;
using Northwind.Data.Abstract;
using Northwind.Entity.Concrete;
using Northwind.Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Northwind.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IMapper _mapper;
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }
        ////[ValidationAspect(typeof(ProductValidator), Priority = 1)]
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(ProductMessage.ProductAddedSuccessfully);
        }

        public IResult Delete(Category category, Expression<Func<Category, bool>> filter = null)
        {
            _categoryDal.Delete(category, filter);
            return new SuccessResult(ProductMessage.ProductDeletedSuccessfully);
        }
        public IDataResult<List<CategoryDTO>> GetAll()
        {
            return new SuccessDataResult<List<CategoryDTO>>(_mapper.Map<List<Category>, List <CategoryDTO>>(_categoryDal.GetAll()));
        }

        public IDataResult<CategoryDTO> GetById(Expression<Func<Category, bool>> filter = null)
        {

            return new SuccessDataResult<CategoryDTO>(_mapper.Map<Category,CategoryDTO>(_categoryDal.Get(filter)));
        }

        //[ValidationAspect(typeof(ProductValidator), Priority = 1)]
        public IResult Update(Category category, Expression<Func<Category, bool>> filter = null)
        {
            _categoryDal.Update(category, filter);
            return new SuccessResult(ProductMessage.ProductUpdatedSuccessfully);
        }
    }
}
