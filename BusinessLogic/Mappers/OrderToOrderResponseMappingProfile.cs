using BusinessLogic.Entities;
using BusinessLogic.Dtos.Orders;
using Mapster;

namespace BusinessLogic.Mappers;

public class OrderToOrderResponseMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Order, OrderResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Date, src => src.OrderDate)
            .Map(dest => dest.TotalBill, src => src.TotalBill)
            .Map(dest => dest.Items, src => src.Items);
    }
}