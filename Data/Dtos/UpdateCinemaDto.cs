using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAPI.Data.Dtos
{
    public class UpdateCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name field is required.")]
        public string? Name { get; set; }
        [Required]
        public string? AdressId { get; set; }
        [Required]
        public string? Owner { get; set; }
    }
}
