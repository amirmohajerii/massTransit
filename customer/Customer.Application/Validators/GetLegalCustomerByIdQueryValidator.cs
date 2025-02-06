using FluentValidation;
using Customer.Application.Features.LegalCustomer.Queries;

public class GetLegalCustomerByIdQueryValidator : AbstractValidator<GetLegalCustomerByIdQuery>
{
    public GetLegalCustomerByIdQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
