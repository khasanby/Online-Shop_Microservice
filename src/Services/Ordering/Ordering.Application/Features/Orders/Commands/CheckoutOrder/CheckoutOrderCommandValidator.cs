using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder;

public sealed class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandValidator()
    {
        RuleFor(p => p.UserName)
            .NotEmpty().WithMessage("{UserName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{UserName} length must not exceed 50 characters");
        RuleFor(p => p.EmailAddress)
            .NotEmpty().WithMessage("{EmailAddress} is required");
        RuleFor(p => p.TotalPrice)
            .NotEmpty().WithMessage("{TotalPrice} is required")
            .GreaterThan(0).WithMessage("{TotalPrice} value should be greater than zero");
    }
}