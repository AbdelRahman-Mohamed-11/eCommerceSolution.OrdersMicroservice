namespace BusinessLogic.Dtos.OrderItems;

public record OrderItemAddRequest(Guid ProductId, int Quantity, decimal UnitPrice);