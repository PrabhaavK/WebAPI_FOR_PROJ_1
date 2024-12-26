using System;
using System.ComponentModel.DataAnnotations;

namespace TuljaBhavani_Theertham.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public decimal PricePerNight { get; set; }

        [Required]
        public bool Availability { get; set; }
    }
}
