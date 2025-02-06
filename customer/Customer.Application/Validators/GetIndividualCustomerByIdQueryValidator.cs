using Customer.Application.Features.IndividualCustomer.Queries;
using FluentValidation;

public class GetIndividualCustomerByIdQueryValidator : AbstractValidator<GetIndividualCustomerByIdQuery>
{
    public GetIndividualCustomerByIdQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
