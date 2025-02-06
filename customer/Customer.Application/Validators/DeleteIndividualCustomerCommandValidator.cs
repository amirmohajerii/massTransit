using Customer.Application.Features.IndividualCustomer.Commands;
using FluentValidation;

public class DeleteIndividualCustomerCommandValidator : AbstractValidator<DeleteIndividualCustomerCommand>
{
    public DeleteIndividualCustomerCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
