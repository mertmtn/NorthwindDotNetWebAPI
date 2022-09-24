using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Data.Concrete.Dapper;
using Northwind.Data.Concrete.EntityFramework;
using Northwind.Entity.Concrete;
using System;
using System.Collections.Generic; 

namespace NorthwindDotNetWebAPI.Benchmarking
{
    [Config(typeof(DapperEFCoreConfig))]
    public class DapperEFCore
    {
        private IProductService _productServiceDapper;
        private IProductService _productServiceEFCore;

        private DapperProductDal dapper = new DapperProductDal();
        private EfProductDal efCore = new EfProductDal();

        [GlobalSetup]
        public void Setup()
        {
            _productServiceEFCore = new ProductManager(efCore);
            _productServiceDapper = new ProductManager(dapper);
        }

        //[Params(1, 10, 25, 50)]
        //public int productId;
        //

        [Benchmark(Description = "Benchmark for Dapper ORM")]
        public List<Product> DapperGetAllProducts() => _productServiceDapper.GetAll().Data;

        [Benchmark(Description = "Benchmark for Entitiy Framework Core")]
        public List<Product> EFCoreGetAllProducts() => _productServiceEFCore.GetAll().Data;


        //[Benchmark(Description = "Benchmark for Dapper ORM")]       
        //public List<Product> DapperGetAllProducts() => _productServiceDapper.GetAll(x => x.ProductId > productId).Data;

        //[Benchmark(Description = "Benchmark for Entitiy Framework Core")]
        //public List<Product> EFCoreGetAllProducts() => _productServiceEFCore.GetAll(x => x.ProductId > productId).Data;
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ManualConfig();
            config.AddDiagnoser(MemoryDiagnoser.Default);
            config.Add(DefaultConfig.Instance);

            BenchmarkRunner.Run<DapperEFCore>(config);
            Console.ReadLine();
        }
    }

    public class DapperEFCoreConfig : ManualConfig
    {
        public DapperEFCoreConfig()
        {
            AddDiagnoser(MemoryDiagnoser.Default);
            Add(DefaultConfig.Instance);
        }
    }


}
//[Benchmark(Description ="Benchmark for Dapper ORM")]
//[Arguments(5)]
//public Product DapperGetAllProductsById(int productId) => _productServiceDapper.GetById(x=>x.ProductId==productId).Data;

//[Benchmark(Description = "Benchmark for Entitiy Framework Core")]
//[Arguments(5)]
//public Product EFCoreGetAllProductsById(int productId) => _productServiceEFCore.GetById(x => x.ProductId == productId).Data;