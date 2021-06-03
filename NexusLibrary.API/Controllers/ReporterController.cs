using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NexusLibrary.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexusLibrary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporterController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReporterController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet]
        [Route("StateOfBooks")]
        public async Task<IActionResult> ReportStateOfBooks()
        {
            await _reportService.ReportActiveAndInactiveBooks();
            return Ok("Se ha generado el archivo correctamente");
        }
    }
}
