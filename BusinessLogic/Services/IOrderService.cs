using BusinessLogic.Dtos.Orders;
using MongoDB.Driver;
using BusinessLogic.Entities;

namespace BusinessLogic.Services;

/// <summary>
/// Defines the contract for order-related business logic operations.
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Retrieves all orders.
    /// </summary>
    /// <returns>A task that returns a list of all orders as <see cref="OrderResponse"/> objects. Each item may be null.</returns>
    Task<List<OrderResponse?>> GetOrdersAsync();

    /// <summary>
    /// Retrieves orders that match the given filter condition.
    /// </summary>
    /// <param name="filter">The MongoDB filter definition used to query orders.</param>
    /// <returns>A task that returns a list of matching <see cref="OrderResponse"/> objects. Each item may be null.</returns>
    Task<List<OrderResponse?>> GetOrdersByConditionAsync(FilterDefinition<Order> filter);

    /// <summary>
    /// Retrieves a single order that matches the given filter condition.
    /// </summary>
    /// <param name="filter">The MongoDB filter used to find the order.</param>
    /// <returns>A task that returns the matching <see cref="OrderResponse"/>, or null if not found.</returns>
    Task<OrderResponse?> GetOrderByConditionAsync(FilterDefinition<Order> filter);

    /// <summary>
    /// Adds a new order based on the provided request.
    /// </summary>
    /// <param name="orderAddRequest">The request containing order creation details.</param>
    /// <returns>A task that returns the newly added <see cref="OrderResponse"/>, or null if the operation fails.</returns>
    Task<OrderResponse?> AddOrderAsync(OrderAddRequest orderAddRequest);

    /// <summary>
    /// Updates an existing order based on the provided request.
    /// </summary>
    /// <param name="orderUpdateRequest">The request containing updated order details.</param>
    /// <returns>A task that returns the updated <see cref="OrderResponse"/>, or null if the order is not found or update fails.</returns>
    Task<OrderResponse?> UpdateOrderAsync(OrderUpdateRequest orderUpdateRequest);

    /// <summary>
    /// Deletes an order by its unique identifier.
    /// </summary>
    /// <param name="orderID">The unique identifier of the order to delete.</param>
    /// <returns>A task that returns true if the order was successfully deleted; otherwise, false.</returns>
    Task<bool> DeleteOrderAsync(Guid orderID);
}
