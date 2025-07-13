using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities;

public class Order
{
    [BsonId]
    public ObjectId _id { get; set; }

    [BsonElement("id")]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid Id { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid UserId { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
    public DateTime OrderDate { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
    public decimal TotalBill { get; set; }

    [BsonElement("Items")]
    public List<OrderItem> Items { get; set; } = [];
}
