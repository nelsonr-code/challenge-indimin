using FluentValidation;
using Indimin.Application.Features.Citizens.Commands;

namespace Indimin.Application.Features.Citizens;

public class InsertAlbumValidator : AbstractValidator<InsertCitizen>
{
    public InsertAlbumValidator()
    {
        RuleFor(citizen => citizen.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(50);

        RuleFor(citizen => citizen.Lastname)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(50);
    }
}