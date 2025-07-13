using BusinessLogic.Dtos.OrderItems;
using BusinessLogic.Entities;
using Mapster;

namespace BusinessLogic.Mappers;

public class OrderItemAddRequestToOrderItemMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderItemAddRequest, OrderItem>()
            .Ignore(dest => dest.Id)
            .Ignore(dest => dest.TotalPrice);
    }
}