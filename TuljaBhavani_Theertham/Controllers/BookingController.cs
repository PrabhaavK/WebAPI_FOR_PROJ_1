using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TuljaBhavani_Theertham.Models;
using TuljaBhavani_Theertham.Services;
using System.Collections.Generic;

namespace TuljaBhavani_Theertham.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookPooja(Booking booking)
        {
            var result = await _bookingService.BookPooja(booking);
            if (result)
            {
                return Ok("Pooja booked successfully");
            }
            return BadRequest("Failed to book pooja");
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserBookings(int userId)
        {
            var bookings = await _bookingService.GetUserBookings(userId);
            return Ok(bookings);
        }
    }
}
