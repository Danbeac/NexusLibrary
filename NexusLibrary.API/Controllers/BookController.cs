using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NexusLibrary.API.Responses;
using NexusLibrary.Core.DTOs;
using NexusLibrary.Core.Entities;
using NexusLibrary.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NexusLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(ILogger<BookController> logger, 
                              IBookRepository bookRepository,
                              IBookService bookService,
                              IMapper mapper)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _bookRepository.GetAll();
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);

            var response = new Response<IEnumerable<BookDto>>(booksDto);
            return Ok(response);
        }

        [HttpGet("{nameBook}")]
        public async Task<IActionResult> GetBook(string nameBook)
        {
            var book = await _bookRepository.GetByName(nameBook);
            var response = new Response<Book>(book);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookDto bookDto)
        {
            await _bookService.AddBook(bookDto);

            var response = new Response<string>("Se ha añadido correctamente el libro.");
            return Ok(response);
        }
    }
}
