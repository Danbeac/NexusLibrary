using FluentValidation;
using NexusLibrary.Core.DTOs;

namespace NexusLibrary.Infraestructure.Validators
{
    public class AuthorValidator : AbstractValidator<AuthorDto>
    {
        public AuthorValidator()
        {
            RuleFor(author => author.FullName)
            .NotNull()
            .WithMessage("El nombre del autor no puede ser vacio");

            RuleFor(author => author.DateBirthday)
            .NotNull()
            .WithMessage("La fecha de nacimiento no puede ser vacio");

            RuleFor(author => author.CityBirth)
            .NotNull()
            .WithMessage("La ciudad de procedencia no puede ser vacio");

            RuleFor(author => author.Email)
            .NotNull()
            .WithMessage("El email no puede ser vacio");
        }
    }
}
