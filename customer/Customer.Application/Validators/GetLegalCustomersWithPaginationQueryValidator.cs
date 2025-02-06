using FluentValidation;
using Customer.Application.Features.LegalCustomer.Queries;

public class GetLegalCustomersWithPaginationQueryValidator : AbstractValidator<GetLegalCustomersWithPaginationQuery>
{
    public GetLegalCustomersWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0).WithMessage("Page number must be greater than zero.");
        RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("Page size must be greater than zero.");
    }
}
