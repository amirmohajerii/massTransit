using FluentValidation;
using Transaction.Application.Features.Transaction.Queries;

public class GetTransactionsWithPaginationQueryValidator : AbstractValidator<GetTransactionsWithPaginationQuery>
{
    public GetTransactionsWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0).WithMessage("Page number must be greater than zero.");
        RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("Page size must be greater than zero.");
    }
}
