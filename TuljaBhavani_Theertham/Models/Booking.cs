using System;
using System.ComponentModel.DataAnnotations;

namespace TuljaBhavani_Theertham.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int PoojaId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan Time { get; set; }
    }
}
