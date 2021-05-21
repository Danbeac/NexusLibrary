using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace NexusLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
    }
}
