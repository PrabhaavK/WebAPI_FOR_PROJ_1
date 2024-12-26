using System;
using System.ComponentModel.DataAnnotations;

namespace TuljaBhavani_Theertham.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
