using BusinessLogic.Dtos.Orders;
using BusinessLogic.Entities;
using Mapster;

namespace BusinessLogic.Mappers;

public class OrderAddRequestToOrderMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderAddRequest, Order>()
            .Map(dest => dest.Items, src => src.Items)
            .Map(dest => dest.OrderDate, src => src.Date)
            .Ignore(dest => dest.Id)
            .Ignore(dest => dest.TotalBill);
    }
}