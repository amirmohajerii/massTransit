using FluentValidation;
using Transaction.Application.Features.Request.Commands;

public class DeleteRequestCommandValidator : AbstractValidator<DeleteRequestCommand>
{
    public DeleteRequestCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than zero.");
    }
}
