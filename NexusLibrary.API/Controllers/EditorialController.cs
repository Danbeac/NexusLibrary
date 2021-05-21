using Microsoft.AspNetCore.Mvc;
using NexusLibrary.API.Responses;
using NexusLibrary.Core.Entities;
using NexusLibrary.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NexusLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorialRepository _editorialRepository;
        public EditorialController(IEditorialRepository editorialRepository)
        {
            _editorialRepository = editorialRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var editorials = await _editorialRepository.GetAll();
            var response = new Response<IEnumerable<Editorial>>(editorials);
            return Ok(response);
        }

        [HttpGet("{nameEditorial}")]
        public async Task<IActionResult> GetEditorial([FromQuery] string nameEditorial)
        {
            var editorial = await _editorialRepository.GetByName(nameEditorial);
            var response = new Response<Editorial>(editorial);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditorial(Editorial editorial)
        {
            await _editorialRepository.Add(editorial);
            var response = new Response<string>("Se ha añadido correctamente la editorial");
            return Ok(response);
        }
    }
}
