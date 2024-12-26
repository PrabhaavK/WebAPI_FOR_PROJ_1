using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TuljaBhavani_Theertham.Models;
using TuljaBhavani_Theertham.Services;
using System.Collections.Generic;

namespace TuljaBhavani_Theertham.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoojariDashboardController : ControllerBase
    {
        private readonly PoojariService _poojariService;
        private readonly PoojaService _poojaService;
        private readonly HotelService _hotelService;
        private readonly BookingService _bookingService;

        public PoojariDashboardController(PoojariService poojariService, PoojaService poojaService, HotelService hotelService, BookingService bookingService)
        {
            _poojariService = poojariService;
            _poojaService = poojaService;
            _hotelService = hotelService;
            _bookingService = bookingService;
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

        [HttpPost("pooja/add")]
        public async Task<IActionResult> AddPooja(Pooja pooja)
        {
            // Logic to add pooja
            var result = await _poojaService.AddPooja(pooja);
            if (result)
            {
                return Ok("Pooja added successfully");
            }
            return BadRequest("Failed to add pooja");
        }

        [HttpPut("pooja/edit/{id}")]
        public async Task<IActionResult> EditPooja(int id, Pooja pooja)
        {
            // Logic to edit pooja
            var result = await _poojaService.EditPooja(id, pooja);
            if (result)
            {
                return Ok("Pooja updated successfully");
            }
            return BadRequest("Failed to update pooja");
        }

        [HttpDelete("pooja/delete/{id}")]
        public async Task<IActionResult> DeletePooja(int id)
        {
            // Logic to delete pooja
            var result = await _poojaService.DeletePooja(id);
            if (result)
            {
                return Ok("Pooja deleted successfully");
            }
            return BadRequest("Failed to delete pooja");
        }

        [HttpPost("hotel/add")]
        public async Task<IActionResult> AddHotel(Hotel hotel)
        {
            // Logic to add hotel
            var result = await _hotelService.AddHotel(hotel);
            if (result)
            {
                return Ok("Hotel added successfully");
            }
            return BadRequest("Failed to add hotel");
        }

        [HttpPut("hotel/edit/{id}")]
        public async Task<IActionResult> EditHotel(int id, Hotel hotel)
        {
            // Logic to edit hotel
            var result = await _hotelService.EditHotel(id, hotel);
            if (result)
            {
                return Ok("Hotel updated successfully");
            }
            return BadRequest("Failed to update hotel");
        }

        [HttpDelete("hotel/delete/{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            // Logic to delete hotel
            var result = await _hotelService.DeleteHotel(id);
            if (result)
            {
                return Ok("Hotel deleted successfully");
            }
            return BadRequest("Failed to delete hotel");
        }

        [HttpGet("bookings")]
        public async Task<IActionResult> GetBookings(int poojariId)
        {
            var bookings = await _bookingService.GetPoojaBookings(poojariId);
            return Ok(bookings);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Logic to handle logout
            return Ok("Logged out successfully");
        }
        
        [HttpPost("book/pooja")]
        public async Task<IActionResult> BookPoojaForUser(Booking booking)
        {
            var result = await _bookingService.BookPooja(booking);
            if (result)
            {
                return Ok("Pooja booked successfully for user");
            }
            return BadRequest("Failed to book pooja for user");
        }

        [HttpPost("book/hotel")]
        public async Task<IActionResult> BookHotelForUser(HotelBooking hotelBooking)
        {
            var result = await _bookingService.BookHotel(hotelBooking);
            if (result)
            {
                return Ok("Hotel booked successfully for user");
            }
            return BadRequest("Failed to book hotel for user");
        }
    }
}
