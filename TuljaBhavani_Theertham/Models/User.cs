using System.ComponentModel.DataAnnotations;

namespace TuljaBhavani_Theertham.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        [StringLength(10)]
        public string Mobile { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        
        [Required]
        public string Role { get; set; }
        
        [Required]
        [StringLength(16)]
        public string AddharNo { get; set; }

        // New properties for authentication
        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string PasswordSalt { get; set; }
    }
}
