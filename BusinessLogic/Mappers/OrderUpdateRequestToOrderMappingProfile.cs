using BusinessLogic.Dtos.Orders;
using BusinessLogic.Entities;
using Mapster;

public class OrderUpdateRequestToOrderMappingProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<OrderUpdateRequest, Order>()
            .Ignore(dest => dest.UserId)
            .Ignore(dest => dest.TotalBill);
    }
} 