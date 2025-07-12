using BusinessLogic.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.RespositoryContracts;

/// <summary>
/// Defines the contract for order-related data operations.
/// </summary>
public interface IOrdersRepository
{
    /// <summary>
    /// Retrieves all orders from the database.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of all orders.</returns>
    Task<IEnumerable<Order>> GetAllOrdersAsync();

    /// <summary>
    /// Retrieves orders that match a given filter condition.
    /// </summary>
    /// <param name="filterDefinition">The filter condition to apply to the query.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of matching orders, which may include null items.</returns>
    Task<IEnumerable<Order?>> GetOrdersByCondition(FilterDefinition<Order> filterDefinition);

    /// <summary>
    /// Retrieves a single order that matches a specific filter condition.
    /// </summary>
    /// <param name="filterDefinition">The filter condition to find the order.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the matching order.</returns>
    Task<Order> GetOrderByCondition(FilterDefinition<Order> filterDefinition);

    /// <summary>
    /// Adds a new order to the database.
    /// </summary>
    /// <param name="order">The order to be added.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the added order, or null if the operation failed.</returns>
    Task<Order?> AddOrderAsync(Order order);

    /// <summary>
    /// Updates an existing order in the database.
    /// </summary>
    /// <param name="order">The order with updated values.</param>
    /// <returns>A task representing the asynchronous operation. The task result indicates whether the update was successful.</returns>
    Task<bool> UpdateOrderAsync(Order order);

    /// <summary>
    /// Deletes an order from the database by its ID.
    /// </summary>
    /// <param name="orderId">The unique identifier of the order to delete.</param>
    /// <returns>A task representing the asynchronous operation. The task result indicates whether the deletion was successful.</returns>
    Task<bool> DeleteOrderAsync(Guid orderId);
}
