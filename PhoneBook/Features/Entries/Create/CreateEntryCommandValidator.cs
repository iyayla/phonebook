using FluentValidation;

namespace PhoneBook.Features.Entries.Create;

public class CreateEntryCommandValidator : AbstractValidator<CreateEntryCommand>
{

    public CreateEntryCommandValidator()
    {
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
