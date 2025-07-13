using BusinessLogic.Dtos.Orders;
using FluentValidation;

namespace BusinessLogic.Dtos.Validators;

public class OrderAddRequestValidator : AbstractValidator<OrderAddRequest>
{
    public OrderAddRequestValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Date).NotEqual(default(DateTime));
        RuleFor(x => x.Items).NotNull().NotEmpty();
        RuleForEach(x => x.Items).SetValidator(new OrderItemAddRequestValidator());
    }
} 