using FluentValidation;
using Customer.Application.Features.LegalCustomer.Commands;

public class DeleteLegalCustomerCommandValidator : AbstractValidator<DeleteLegalCustomerCommand>
{
    public DeleteLegalCustomerCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
