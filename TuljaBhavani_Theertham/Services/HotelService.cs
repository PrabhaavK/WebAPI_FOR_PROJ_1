using System.Collections.Generic;
using System.Threading.Tasks;
using TuljaBhavani_Theertham.Models;
using TuljaBhavani_Theertham.Repository;

namespace TuljaBhavani_Theertham.Services
{
    public class HotelService
    {
        private readonly HotelRepository _hotelRepository;

        public HotelService(HotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<List<Hotel>> ListAvailableHotels()
        {
            return await _hotelRepository.GetAvailableHotels();
        }

        public async Task<bool> BookHotel(HotelBooking booking)
        {
            return await _hotelRepository.AddBooking(booking);
        }
    }
}
