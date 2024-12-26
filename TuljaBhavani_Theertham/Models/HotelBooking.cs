using System;
using System.ComponentModel.DataAnnotations;

namespace TuljaBhavani_Theertham.Models
{
    public class HotelBooking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int HotelId { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Required]
        public int NumberOfGuests { get; set; }
    }
}
