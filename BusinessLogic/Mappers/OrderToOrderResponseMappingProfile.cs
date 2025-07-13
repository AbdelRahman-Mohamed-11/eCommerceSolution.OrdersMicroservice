using BusinessLogic.Entities;
using BusinessLogic.Dtos.Orders;
using Mapster;

namespace BusinessLogic.Mappers;

public class OrderToOrderResponseMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Order, OrderResponse>();
    }
}