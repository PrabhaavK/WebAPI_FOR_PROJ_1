using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TuljaBhavani_Theertham.Models;
using TuljaBhavani_Theertham.Services;
using System.Collections.Generic;

namespace TuljaBhavani_Theertham.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelService _hotelService;

        public HotelController(HotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet("available")]
        public async Task<IActionResult> ListAvailableHotels()
        {
            var hotels = await _hotelService.ListAvailableHotels();
            return Ok(hotels);
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookHotel(HotelBooking booking)
        {
            var result = await _hotelService.BookHotel(booking);
            if (result)
            {
                return Ok("Hotel booked successfully");
            }
            return BadRequest("Failed to book hotel");
        }
    }
}
