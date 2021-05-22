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
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorController(ILogger<AuthorController> logger, 
                                IAuthorRepository authorRepository,
                                IMapper mapper)
        {
            _logger = logger;
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var authors = await _authorRepository.GetAll();
            var response = new Response<IEnumerable<Author>>(authors);
            return Ok(response);
        }

        [HttpGet("{nameAuthor}")]
        public async Task<IActionResult> GetAuthor(string nameAuthor)
        {
            var author = await _authorRepository.GetByName(nameAuthor);
            var response = new Response<Author>(author);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            await _authorRepository.Add(author);
            var response = new Response<string>("Se ha añadido correctamente el autor.");
            return Ok(response);
        }
    }
}
