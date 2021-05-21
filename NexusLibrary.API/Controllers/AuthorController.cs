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
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(ILogger<AuthorController> logger, IAuthorRepository authorRepository)
        {
            _logger = logger;
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var authors = await _authorRepository.GetAll();
            var response = new Response<IEnumerable<Author>>(authors);
            return Ok(response);
        }

        [HttpGet("{nameAuthor}")]
        public async Task<IActionResult> GetAuthor([FromQuery] string nameAuthor)
        {
            var author = await _authorRepository.GetByName(nameAuthor);
            var response = new Response<Author>(author);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(Author author)
        {
            await _authorRepository.Add(author);
            var response = new Response<string>("Se ha añadido correctamente el author.");
            return Ok(response);
        }
    }
}
