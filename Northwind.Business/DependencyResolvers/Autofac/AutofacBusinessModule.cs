using Autofac;
using Northwind.Business.Concrete;
using Northwind.Business.Abstract;
using Northwind.Data.Abstract;
using Northwind.Data.Concrete.EntityFramework;
using Northwind.Data.Concrete.MongoDb;
using Northwind.Core.DataAccess.NoSql.MongoDb; 
using Northwind.Entity.Mapping;
using MapsterMapper;
using Northwind.Core.Entities.Mapping.AutoMapper;
using Northwind.Core.Entities.Mapping.Mapster; 
using Northwind.Core.Entities.Mapping.Tinymapper;

namespace Northwind.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            #region Entity Framework Db Dependencies
            builder.RegisterType<EfProductDal>().As<IProductDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().InstancePerLifetimeScope();
           
            #endregion

            #region Dapper Db Dependencies
            //builder.RegisterType<DapperProductDal>().As<IProductDal>().InstancePerLifetimeScope();
            //builder.RegisterType<DapperCategoryDal>().As<ICategoryDal>().InstancePerLifetimeScope();
            #endregion

            #region Mongo Db Dependencies
            //builder.RegisterType<MongoProductDal>().As<IProductDal>().InstancePerLifetimeScope();
            //builder.RegisterType<MongoCategoryDal>().As<ICategoryDal>().InstancePerLifetimeScope();
            //builder.RegisterType<MongoDbContext>().As<IMongoDbContext>().InstancePerLifetimeScope();

            //TODO: Options pattern uygulanacak
            //services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));           
            #endregion

            builder.RegisterType<CategoryManager>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductManager>().As<IProductService>().InstancePerLifetimeScope();


            #region AutoMapper Registiration
            //builder.Register(context => new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<CategoryProfile>();
            //})).AsSelf().SingleInstance();

            //builder.Register(c =>
            //{
            //    //This resolves a new context that can be used later.
            //    var context = c.Resolve<IComponentContext>();
            //    var config = context.Resolve<MapperConfiguration>();
            //    return config.CreateMapper(context.Resolve);
            //}).As<IMapper>().InstancePerLifetimeScope();
            #endregion
            //AutoMapper
            //builder.RegisterType<AutoMapperMapper<CategoryProfile>>().As<Core.Entities.Mapping.IMapper>().SingleInstance();

            //Mapster
            //builder.RegisterType<MapsterMapperMapper>().As<Core.Entities.Mapping.IMapper>().SingleInstance();

            //TinyMapper
            builder.RegisterType<TinyMapperMapper>().As<Core.Entities.Mapping.IMapper>().SingleInstance();

            // Other Lifetime
            // Transient
            //builder.RegisterType<EmployeeService>().As<IEmployeeService>()
            //    .InstancePerDependency();

            //// Scoped
            //builder.RegisterType<EmployeeService>().As<IEmployeeService>()   .InstancePerLifetimeScope();


            //// Singleton
            //builder.RegisterType<EmployeeService>().As<IEmployeeService>()
            //    .SingleInstance();*/
        }

    }
}
