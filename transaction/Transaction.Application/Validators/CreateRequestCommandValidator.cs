using FluentValidation;
using Transaction.Application.Features.Request.Commands;

public class CreateRequestCommandValidator : AbstractValidator<CreateRequestCommand>
{
    public CreateRequestCommandValidator()
    {
        RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("CustomerId must be greater than zero.");
        RuleFor(x => x.RequestType).NotEmpty().WithMessage("RequestType is required.");
        RuleFor(x => x.RequestDate).LessThanOrEqualTo(DateTime.Now).WithMessage("RequestDate cannot be in the future.");
        RuleFor(x => x.Method).Must(x => x == 1 || x == 2).WithMessage("Method must be 1 (HTTP) or 2 (gRPC).");
    }
}
