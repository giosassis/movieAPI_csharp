using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Address
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public virtual ICollection<Cinema> Cinema { get; set; }
        public string? ZipCode { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? Region { get; set; }
        [Required]
        public string? State { get; set;}
        [Required]
        public string? Street { get; set;}
        [Required]
        public int Number { get; set;}
    }
}
