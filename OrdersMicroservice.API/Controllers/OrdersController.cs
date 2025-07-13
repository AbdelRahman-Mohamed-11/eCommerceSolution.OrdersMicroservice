using BusinessLogic.Dtos.Orders;
using BusinessLogic.Services;
using BusinessLogic.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using FluentValidation;
using MongoDB.Bson;

namespace OrdersMicroservice.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(IOrderService orderService) : ControllerBase
{

    // GET: /api/Orders
    [HttpGet]
    public async Task<ActionResult<List<OrderResponse?>>> Get()
    {
        var orders = await orderService.GetOrdersAsync();
        return Ok(orders);
    }

    // GET: /api/Orders/search/orderid/{orderID}
    [HttpGet("search/orderid/{orderID}")]
    public async Task<ActionResult<OrderResponse?>> GetOrderByOrderID(Guid orderID)
    {
        var filter = Builders<Order>.Filter.Eq(temp => temp.Id, orderID);
        var order = await orderService.GetOrderByConditionAsync(filter);
        
        if (order == null)
            return NotFound();
            
        return Ok(order);
    }

    // GET: /api/Orders/search/productid/{productID}
    [HttpGet("search/productid/{productID}")]
    public async Task<ActionResult<List<OrderResponse?>>> GetOrdersByProductID(Guid productID)
    {
        var filter = Builders<Order>.Filter.ElemMatch(temp => temp.Items, 
            Builders<OrderItem>.Filter.Eq(tempProduct => tempProduct.ProductId, productID));

        var orders = await orderService.GetOrdersByConditionAsync(filter);
        return Ok(orders);
    }

    // GET: /api/Orders/search/orderDate/{orderDate}
    [HttpGet("search/orderDate/{orderDate}")]
    public async Task<ActionResult<List<OrderResponse?>>> GetOrdersByOrderDate(DateTime orderDate)
    {
        var filter = Builders<Order>.Filter.Eq(temp => temp.OrderDate.ToString("yyyy-MM-dd"), 
            orderDate.ToString("yyyy-MM-dd"));

        var orders = await orderService.GetOrdersByConditionAsync(filter);
        return Ok(orders);
    }

    // POST: /api/Orders
    [HttpPost]
    public async Task<ActionResult<OrderResponse?>> Create([FromBody] OrderAddRequest orderAddRequest)
    {
        var order = await orderService.AddOrderAsync(orderAddRequest);
        return CreatedAtAction(nameof(GetOrderByOrderID), new { orderID = order?.Id }, order);
    }

    // PUT: /api/Orders
    [HttpPut]
    public async Task<ActionResult<OrderResponse?>> Update([FromBody] OrderUpdateRequest orderUpdateRequest)
    {
        var order = await orderService.UpdateOrderAsync(orderUpdateRequest);
        
        if (order == null)
            return NotFound();
            
        return Ok(order);
    }

    // DELETE: /api/Orders/{orderID}
    [HttpDelete("{orderID}")]
    public async Task<ActionResult> Delete(Guid orderID)
    {
        var success = await orderService.DeleteOrderAsync(orderID);
        
        if (!success)
            return NotFound();
            
        return NoContent();
    }
} 