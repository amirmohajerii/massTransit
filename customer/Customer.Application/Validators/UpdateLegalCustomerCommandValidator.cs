using FluentValidation;
using Customer.Application.Features.LegalCustomer.Commands;
using Customer.Application.Features.legalCustomer.Commands;

public class UpdateLegalCustomerCommandValidator : AbstractValidator<UpdateLegalCustomerCommand>
{
    public UpdateLegalCustomerCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.CompanyRegistrationNumber).NotEmpty().WithMessage("RegistrationNumber is required.");
    }
}
