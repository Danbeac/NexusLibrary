using FluentValidation;
using NexusLibrary.Core.DTOs;

namespace NexusLibrary.Infraestructure.Validators
{
    public class EditorialValidator : AbstractValidator<EditorialDto>
    {
        public EditorialValidator()
        {
            RuleFor(editorial => editorial.Name)
            .NotEmpty()
            .WithMessage("El nombre de la editorial no puede ser vacio");

            RuleFor(editorial => editorial.CorrespondenceAdress)
            .NotEmpty()
            .WithMessage("La direccion de correspondencia no puede estar vacia");

            RuleFor(editorial => editorial.Phonenumber)
            .NotEmpty()
            .WithMessage("El numero de telefono de la editorial no puede ser vacio");

            RuleFor(editorial => editorial.Email)
            .NotEmpty()
            .WithMessage("El email no puede estar vacio");
        }
    }
}
