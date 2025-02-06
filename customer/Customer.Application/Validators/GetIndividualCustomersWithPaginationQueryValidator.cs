using Customer.Application.Features.IndividualCustomer.Queries;
using FluentValidation;

public class GetIndividualCustomersWithPaginationQueryValidator : AbstractValidator<GetIndividualCustomersWithPaginationQuery>
{
    public GetIndividualCustomersWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0).WithMessage("Page number must be greater than zero.");
        RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("Page size must be greater than zero.");
    }
}
