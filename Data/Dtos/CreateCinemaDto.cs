using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAPI.Data.Dtos
{
    public class CreateCinemaDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int AdressId { get; set; }
        [Required]
        public string? Owner { get; set; }
    }
}
