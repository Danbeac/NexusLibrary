using FluentValidation;
using NexusLibrary.Core.Entities;

namespace NexusLibrary.Infraestructure.Validators
{
    public class EditorialValidator : AbstractValidator<Editorial>
    {
        public EditorialValidator()
        {
            RuleFor(editorial => editorial.Name)
            .NotNull()
            .WithMessage("El nombre de la editorial no puede ser vacio");

            RuleFor(editorial => editorial.CorrespondenceAdress)
            .NotNull()
            .WithMessage("La direccion de correspondencia no puede estar vacia");

            RuleFor(editorial => editorial.Phonenumber)
            .NotNull()
            .WithMessage("El numero de telefono de la editorial no puede ser vacio");

            RuleFor(editorial => editorial.Email)
            .NotNull()
            .WithMessage("El email no puede estar vacio");
        }
    }
}
