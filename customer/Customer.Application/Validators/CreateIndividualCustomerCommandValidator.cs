using Customer.Application.Features.IndividualCustomer.Commands;
using FluentValidation;

public class CreateIndividualCustomerCommandValidator : AbstractValidator<CreateIndividualCustomerCommand>
{
    public CreateIndividualCustomerCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.NationalId).NotEmpty().WithMessage("NationalId is required.");
    }
}
