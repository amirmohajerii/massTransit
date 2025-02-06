using Customer.Application.Features.IndividualCustomer.Commands;
using FluentValidation;

public class UpdateIndividualCustomerCommandValidator : AbstractValidator<UpdateIndividualCustomerCommand>
{
    public UpdateIndividualCustomerCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.NationalId).NotEmpty().WithMessage("NationalId is required.");
    }
}
