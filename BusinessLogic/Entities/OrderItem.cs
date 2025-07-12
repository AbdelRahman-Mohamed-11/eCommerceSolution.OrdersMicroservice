using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

namespace BusinessLogic.Entities;

public class OrderItem
{
    [BsonId]
    public int Id { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid ProductId { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
    public decimal UnitPrice { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]
    public int Quantity { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.Double)]
    public decimal TotalPrice { get; set; }
}
