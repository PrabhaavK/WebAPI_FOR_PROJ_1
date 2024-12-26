using System.ComponentModel.DataAnnotations;

namespace TuljaBhavani_Theertham.Models
{
    public class Poojari
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Specialization { get; set; }
    }
}
