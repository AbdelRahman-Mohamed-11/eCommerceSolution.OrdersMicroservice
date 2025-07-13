namespace BusinessLogic.Dtos.OrderItems;

public record OrderItemResponse(
Guid ProductID,
decimal UnitPrice,
int Quantity,
decimal TotalPrice
);
