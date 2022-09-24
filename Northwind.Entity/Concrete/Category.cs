using Dapper.Contrib.Extensions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Northwind.Core.Entity; 

namespace Northwind.Entity.Concrete
{
    [Table("Categories")]
    public class Category:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Write(false)]
        public string Id { get; set; }

        [Key]       
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
