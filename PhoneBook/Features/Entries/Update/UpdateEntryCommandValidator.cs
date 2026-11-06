using FluentValidation;

namespace PhoneBook.Features.Entries.Update;

public class UpdateEntryCommandValidator : AbstractValidator<UpdateEntryCommand>
{
    public UpdateEntryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty")
            ;

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .MaximumLength(255).WithMessage("{PropertyName} cannot exceed 255 chars in length")
            ;

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .MaximumLength(255).WithMessage("{PropertyName} cannot exceed 255 chars in length")
            ;

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("{PropertyName} cannot be empty")
            .MaximumLength(255).WithMessage("{PropertyName} cannot exceed 255 chars in length")
            ;
    }
}