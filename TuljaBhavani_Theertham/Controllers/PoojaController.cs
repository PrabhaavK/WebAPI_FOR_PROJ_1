using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TuljaBhavani_Theertham.Models;
using TuljaBhavani_Theertham.Services;
using System.Collections.Generic;

namespace TuljaBhavani_Theertham.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoojaController : ControllerBase
    {
        private readonly PoojaService _poojaService;

        public PoojaController(PoojaService poojaService)
        {
            _poojaService = poojaService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListPoojas()
        {
            var poojas = await _poojaService.ListPoojas();
            return Ok(poojas);
        }
    }
}
