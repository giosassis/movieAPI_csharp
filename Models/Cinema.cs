using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAPI.Models
{
    public class Cinema
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name field is required.")]
        public string? Name { get; set; }
        [Required]
        public int AdressId { get; set; }
        public virtual ICollection<Address>? Address { get; set; }
        [Required]
        public string? Owner { get; set; }

    }
}
