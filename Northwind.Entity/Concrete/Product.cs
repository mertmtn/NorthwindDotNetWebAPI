using Dapper.Contrib.Extensions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Northwind.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Entity.Concrete
{
    [Dapper.Contrib.Extensions.Table("Products")]
    public class Product : IEntity
    {
        [Write(false)]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [NotMapped]
        public string Id { get; set; }

        [Key]        
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public bool DisContinued { get; set; }
    }
}
