using BusinessLogic.Dtos.OrderItems;

namespace BusinessLogic.Dtos.Orders;

public record OrderAddRequest(Guid UserId, DateTime Date, List<OrderItemAddRequest> OrderItems);
