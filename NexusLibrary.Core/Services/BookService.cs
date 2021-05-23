using AutoMapper;
using NexusLibrary.Core.DTOs;
using NexusLibrary.Core.Entities;
using NexusLibrary.Core.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NexusLibrary.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IEditorialRepository _editorialRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository,
                           IAuthorRepository authorRepository,
                           IEditorialRepository editorialRepository,
                           IMapper mapper)
        {
            _bookRepository = bookRepository;
            _editorialRepository = editorialRepository;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task AddBook(BookDto bookDto)
        {
            int NOLIMT = -1;
            var editorial = await _editorialRepository.GetByName(bookDto.NameEditorial);
            if(editorial == null)
            {
                throw new Exception("La editorial no está registrada");
            }

            var author = await _authorRepository.GetByName(bookDto.NameAuthor);
            if (author == null)
            {
                throw new Exception("El autor no está registrado");
            }

            if(!(editorial.MaxBooksRegistered == NOLIMT))
            {
                var booksEditorial = await _bookRepository.BooksByEditorialId(editorial.EditorialId);

                if (booksEditorial.Count() >= editorial.MaxBooksRegistered)
                {
                    throw new Exception("No es posible registrar el libro, se alcanzó el máximo permitido.");
                }
            }

            var book = _mapper.Map<Book>(bookDto);
            book.EditorialId = editorial.EditorialId;
            book.AuthorId = author.AuthorId;
            await _bookRepository.Add(book);
        }
    }
}
