using FluentValidation;
using Customer.Application.Features.LegalCustomer.Commnads;

public class CreateLegalCustomerCommandValidator : AbstractValidator<CreateLegalCustomerCommand>
{
    public CreateLegalCustomerCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.CompanyRegistrationNumber).NotEmpty().WithMessage("RegistrationNumber is required.");
    }
}
