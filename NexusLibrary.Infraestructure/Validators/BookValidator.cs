using FluentValidation;
using NexusLibrary.Core.DTOs;

namespace NexusLibrary.Infraestructure.Validators
{
    public class BookValidator : AbstractValidator<BookDto>
    {
        public BookValidator()
        {
            RuleFor(book => book.Title)
                .NotEmpty()
                .WithMessage("El titulo no puede estar vacio");

            RuleFor(book => book.Year)
                .NotEmpty()
                .WithMessage("El año del libro no puede ser vacio");

            RuleFor(book => book.Gender)
                .NotEmpty()
                .WithMessage("El genero del libro no puede ser vacio");

            RuleFor(book => book.AuthorName)
                .NotEmpty()
                .WithMessage("El nombre del autor no puede ser vacio");

            RuleFor(book => book.EditorialName)
                .NotEmpty()
                .WithMessage("El nombre de la editorial no puede ser vacio");
        }
    }
}
