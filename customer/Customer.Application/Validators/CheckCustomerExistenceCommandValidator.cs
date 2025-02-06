using FluentValidation;
using Customer.Application.Features.Customer.Commands;

public class CheckCustomerExistenceCommandValidator : AbstractValidator<CheckCustomerExistenceCommand>
{
    public CheckCustomerExistenceCommandValidator()
    {
        RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("CustomerId must be greater than zero.");
    }
}
