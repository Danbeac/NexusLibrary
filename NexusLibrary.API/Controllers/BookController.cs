using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NexusLibrary.API.Responses;
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

        public BookController(ILogger<BookController> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _bookRepository.GetAll();
            var response = new Response<IEnumerable<Book>>(books);
            return Ok(response);
        }

        [HttpGet("{nameBook}")]
        public async Task<IActionResult> GetBook([FromQuery] string nameBook)
        {
            var book = await _bookRepository.GetByName(nameBook);
            var response = new Response<Book>(book);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            await _bookRepository.Add(book);
            var response = new Response<string>("Se ha añadido correctamente el libro.");
            return Ok(response);
        }
    }
}
