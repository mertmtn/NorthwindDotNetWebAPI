using AutoMapper;
using Northwind.Entity.Concrete;
using Northwind.Entity.DTOs;

namespace Northwind.Entity.Mapping.AutoMapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}
