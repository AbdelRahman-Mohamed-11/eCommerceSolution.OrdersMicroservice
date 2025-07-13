using BusinessLogic.Dtos.OrderItems;

namespace BusinessLogic.Dtos.Orders;

public record OrderResponse(
Guid Id,
Guid UserId,
DateTime Date,
decimal TotalBill,
List<OrderItemResponse> Items);
