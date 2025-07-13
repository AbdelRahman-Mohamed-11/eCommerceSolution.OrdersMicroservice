using MongoDB.Bson.Serialization.Attributes;
using NUlid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities;

public class Order
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid Id { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid UserId { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
    public DateTime Date { get; set; }

    [BsonRepresentation(MongoDB.Bson.BsonType.Double)]

    public decimal TotalBill { get; set; }

    public List<OrderItem> OrderItems { get; set; } = [];
}
