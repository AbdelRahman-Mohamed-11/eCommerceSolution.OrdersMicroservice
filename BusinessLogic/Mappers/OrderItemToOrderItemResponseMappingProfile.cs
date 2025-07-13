using BusinessLogic.Entities;
using BusinessLogic.Dtos.OrderItems;
using Mapster;

public class OrderItemToOrderItemResponseMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderItem, OrderItemResponse>()
            .Map(dest => dest.ProductID, src => src.ProductId)
            .Map(dest => dest.UnitPrice, src => src.UnitPrice)
            .Map(dest => dest.Quantity, src => src.Quantity)
            .Map(dest => dest.TotalPrice, src => src.TotalPrice);
    }
} 