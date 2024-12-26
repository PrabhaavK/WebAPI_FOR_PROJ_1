using System.Collections.Generic;
using System.Threading.Tasks;
using TuljaBhavani_Theertham.Models;
using Microsoft.EntityFrameworkCore;

namespace TuljaBhavani_Theertham.Repository
{
    public class HotelRepository
    {
        private readonly AppDbContext _context;

        public HotelRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> GetAvailableHotels()
        {
            return await _context.Hotels
                .Where(h => h.Availability)
                .ToListAsync();
        }

        public async Task<bool> AddBooking(HotelBooking booking)
        {
            _context.HotelBookings.Add(booking);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
