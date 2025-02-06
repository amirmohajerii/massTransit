using FluentValidation;
using Transaction.Application.Features.Request.Commands;

public class UpdateRequestCommandValidator : AbstractValidator<UpdateRequestCommand>
{
    public UpdateRequestCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than zero.");
        RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("CustomerId must be greater than zero.");
        RuleFor(x => x.RequestType).NotEmpty().WithMessage("RequestType is required.");
        RuleFor(x => x.RequestDate).LessThanOrEqualTo(DateTime.Now).WithMessage("RequestDate cannot be in the future.");
    }
}
