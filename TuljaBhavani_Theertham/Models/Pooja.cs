using System;
using System.ComponentModel.DataAnnotations;

namespace TuljaBhavani_Theertham.Models
{
    public class Pooja
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DateType { get; set; }

        [Required]
        public TimeSpan Time { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public bool Availability { get; set; }

        [Required]
        public int MaxPeople { get; set; }
    }
}
