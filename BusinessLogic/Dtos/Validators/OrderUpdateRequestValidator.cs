using BusinessLogic.Dtos.Orders;
using FluentValidation;

namespace BusinessLogic.Dtos.Validators;

public class OrderUpdateRequestValidator : AbstractValidator<OrderUpdateRequest>
{
    public OrderUpdateRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Date).NotEqual(default(DateTime));
        RuleFor(x => x.OrderItems).NotNull().NotEmpty();
        RuleForEach(x => x.OrderItems).SetValidator(new OrderItemUpdateRequestValidator());
    }
} 