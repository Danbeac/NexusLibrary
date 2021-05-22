using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialRepository _editorialRepository;
        private readonly IMapper _mapper;
        public EditorialController(IEditorialRepository editorialRepository, IMapper mapper)
        {
            _editorialRepository = editorialRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var editorials = await _editorialRepository.GetAll();
            var response = new Response<IEnumerable<Editorial>>(editorials);
            return Ok(response);
        }

        [HttpGet("{nameEditorial}")]
        public async Task<IActionResult> GetEditorial(string nameEditorial)
        {
            var editorial = await _editorialRepository.GetByName(nameEditorial);
            var response = new Response<Editorial>(editorial);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditorial(EditorialDto editorialDto)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var editorial = _mapper.Map<Editorial>(editorialDto);
            await _editorialRepository.Add(editorial);

            var response = new Response<string>("Se ha añadido correctamente la editorial.");
            return Ok(response);
        }
    }
}
