using System;
using System.ComponentModel.DataAnnotations;

namespace TuljaBhavani_Theertham.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public int? PoojaId { get; set; }

        public int? HotelId { get; set; }

        public int? PoojariId { get; set; }

        [Required]
        public int Rating { get; set; }

        public string Comments { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
