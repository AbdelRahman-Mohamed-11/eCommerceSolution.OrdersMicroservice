using BusinessLogic.Dtos.OrderItems;
using BusinessLogic.Entities;
using Mapster;

namespace BusinessLogic.Mappers;

public class OrderItemUpdateRequestToOrderItemMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderItemUpdateRequest, OrderItem>()
            .Map(dest => dest.TotalPrice, src => src.UnitPrice * src.Quantity);
    }
}