using BusinessLogic.Dtos.OrderItems;
using BusinessLogic.Dtos.Orders;
using BusinessLogic.Entities;
using BusinessLogic.RespositoryContracts;
using MongoDB.Driver;
using Mapster;
using FluentValidation;
using MongoDB.Bson;

namespace BusinessLogic.Services;

public class OrderService(
    IOrdersRepository ordersRepository,
    IValidator<OrderAddRequest> orderAddValidator,
    IValidator<OrderUpdateRequest> orderUpdateValidator) : IOrderService
{
    public async Task<List<OrderResponse?>> GetOrdersAsync()
    {
        IEnumerable<Order>? orders = await ordersRepository.GetAllOrdersAsync();
        return orders.Adapt<List<OrderResponse?>>();
    }

    public async Task<List<OrderResponse?>> GetOrdersByConditionAsync(FilterDefinition<Order> filter)
    {
        var orders = await ordersRepository.GetOrdersByCondition(filter);
        return orders.Adapt<List<OrderResponse?>>();
    }

    public async Task<OrderResponse?> GetOrderByConditionAsync(FilterDefinition<Order> filter)
    {
        var order = await ordersRepository.GetOrderByCondition(filter);
        return order?.Adapt<OrderResponse>();
    }

    public async Task<OrderResponse?> AddOrderAsync(OrderAddRequest orderAddRequest)
    {
        var validationResult = await orderAddValidator.ValidateAsync(orderAddRequest);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var order = orderAddRequest.Adapt<Order>();
        order._id = ObjectId.GenerateNewId();
        order.Id = Guid.NewGuid();
        order.TotalBill = orderAddRequest.Items.Sum(i => i.UnitPrice * i.Quantity);
        var createdOrder = await ordersRepository.AddOrderAsync(order);
        return createdOrder?.Adapt<OrderResponse>();
    }

    public async Task<OrderResponse?> UpdateOrderAsync(OrderUpdateRequest orderUpdateRequest)
    {
        var validationResult = await orderUpdateValidator.ValidateAsync(orderUpdateRequest);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var filter = Builders<Order>.Filter.Eq(o => o.Id, orderUpdateRequest.Id);
        var existingOrder = await ordersRepository.GetOrderByCondition(filter);
        if (existingOrder == null)
            return null;

        var updatedOrder = orderUpdateRequest.Adapt<Order>();
        updatedOrder.UserId = existingOrder.UserId;
        updatedOrder.TotalBill = orderUpdateRequest.OrderItems.Sum(i => i.UnitPrice * i.Quantity);
        var success = await ordersRepository.UpdateOrderAsync(updatedOrder);
        return success ? updatedOrder.Adapt<OrderResponse>() : null;
    }

    public async Task<bool> DeleteOrderAsync(Guid orderID)
    {
        return await ordersRepository.DeleteOrderAsync(orderID);
    }
} 