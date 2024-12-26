using System.Collections.Generic;
using System.Threading.Tasks;
using TuljaBhavani_Theertham.Models;
using Microsoft.EntityFrameworkCore;

namespace TuljaBhavani_Theertham.Repository
{
    public class BookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Booking>> GetUserBookings(int userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }
    }
}
