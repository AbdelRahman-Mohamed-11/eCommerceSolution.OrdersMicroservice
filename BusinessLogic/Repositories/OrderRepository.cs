using BusinessLogic.Entities;
using BusinessLogic.RespositoryContracts;
using MongoDB.Driver;

namespace BusinessLogic.Repositories;

/// <summary>
/// MongoDB implementation of IOrdersRepository.
/// </summary>
public class OrderRepository(IMongoDatabase mongoDatabase) : IOrdersRepository
{
    private const string collectionName = "orders";
    private readonly IMongoCollection<Order> _ordersCollection = mongoDatabase.GetCollection<Order>(collectionName);

    public async Task<Order?> AddOrderAsync(Order order)
    {
        await _ordersCollection.InsertOneAsync(order);
        return order;
    }

    public async Task<bool> DeleteOrderAsync(Guid orderId)
    {
        var result = await _ordersCollection.DeleteOneAsync(o => o.Id == orderId);
        return result.DeletedCount > 0;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        var result = await _ordersCollection.FindAsync(FilterDefinition<Order>.Empty);
        return await result.ToListAsync();
    }

    public async Task<Order> GetOrderByCondition(FilterDefinition<Order> filterDefinition)
    {
        var result = await _ordersCollection.FindAsync(filterDefinition);
        return await result.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Order?>> GetOrdersByCondition(FilterDefinition<Order> filterDefinition)
    {
        var result = await _ordersCollection.FindAsync(filterDefinition);
        return await result.ToListAsync();
    }

    public async Task<bool> UpdateOrderAsync(Order order)
    {
        var result = await _ordersCollection.ReplaceOneAsync(o => o.Id == order.Id, order);
        return result.ModifiedCount > 0;
    } 
}
