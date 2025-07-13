using BusinessLogic.Dtos.Orders;
using BusinessLogic.Entities;
using Mapster;

public class OrderUpdateRequestToOrderMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderUpdateRequest, Order>()
            .Map(dest => dest.Items, src => src.OrderItems)
            .Map(dest => dest.OrderDate, src => src.Date)
            .Ignore(dest => dest.UserId)
            .Ignore(dest => dest.TotalBill);
    }
} 