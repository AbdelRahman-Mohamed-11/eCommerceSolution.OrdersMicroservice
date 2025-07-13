namespace BusinessLogic.Dtos.OrderItems;

public record OrderItemUpdateRequest(
 Guid ProductId,
 int Quantity,
 decimal UnitPrice
);

