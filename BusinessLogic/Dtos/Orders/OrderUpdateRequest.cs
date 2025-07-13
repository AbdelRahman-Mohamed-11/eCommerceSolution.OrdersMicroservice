using BusinessLogic.Dtos.OrderItems;

namespace BusinessLogic.Dtos.Orders;

public record OrderUpdateRequest(
 Guid Id,
 DateTime Date,
 List<OrderItemUpdateRequest> OrderItems
);

