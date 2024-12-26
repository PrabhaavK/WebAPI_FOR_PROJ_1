using System.Collections.Generic;
using System.Threading.Tasks;
using TuljaBhavani_Theertham.Models;
using TuljaBhavani_Theertham.Repository;

namespace TuljaBhavani_Theertham.Services
{
    public class BookingService
    {
        private readonly BookingRepository _bookingRepository;

        public BookingService(BookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<bool> BookPooja(Booking booking)
        {
            return await _bookingRepository.AddBooking(booking);
        }

        public async Task<List<Booking>> GetUserBookings(int userId)
        {
            return await _bookingRepository.GetUserBookings(userId);
        }
    }
}
