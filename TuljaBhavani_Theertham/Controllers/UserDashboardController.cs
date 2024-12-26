using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TuljaBhavani_Theertham.Models;
using TuljaBhavani_Theertham.Services;
using System.Collections.Generic;

namespace TuljaBhavani_Theertham.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDashboardController : ControllerBase
    {
        private readonly PoojariService _poojariService;
        private readonly PoojaService _poojaService;
        private readonly HotelService _hotelService;

        public UserDashboardController(PoojariService poojariService, PoojaService poojaService, HotelService hotelService)
        {
            _poojariService = poojariService;
            _poojaService = poojaService;
            _hotelService = hotelService;
        }

        [HttpGet("poojaris")]
        public async Task<IActionResult> ListPoojaris()
        {
            var poojaris = await _poojariService.ListPoojaris();
            return Ok(poojaris);
        }

        [HttpGet("poojas")]
        public async Task<IActionResult> ListPoojas()
        {
            var poojas = await _poojaService.ListPoojas();
            return Ok(poojas);
        }

        [HttpGet("hotels")]
        public async Task<IActionResult> ListHotels()
        {
            var hotels = await _hotelService.ListAvailableHotels();
            return Ok(hotels);
        }

        [HttpPost("feedback")]
        public async Task<IActionResult> SubmitFeedback(Feedback feedback)
        {
            var result = await _poojariService.SubmitFeedback(feedback);
            if (result)
            {
                return Ok("Feedback submitted successfully");
            }
            return BadRequest("Failed to submit feedback");
        }
    }
}
