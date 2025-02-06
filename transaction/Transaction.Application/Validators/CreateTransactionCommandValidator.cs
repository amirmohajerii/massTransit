using FluentValidation;
using Transaction.Application.Features.Transaction.Commands;

public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
{
    public CreateTransactionCommandValidator()
    {
        RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("CustomerId must be greater than zero.");
        RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero.");
        RuleFor(x => x.TransactionDate).LessThanOrEqualTo(DateTime.Now).WithMessage("TransactionDate cannot be in the future.");
        RuleFor(x => x.RequestId).GreaterThan(0).WithMessage("RequestId must be greater than zero.");
    }
}
