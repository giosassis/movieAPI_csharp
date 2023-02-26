using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.Dtos
{
    public class UpdateMovieDto
    {
        [Key]

        [StringLength(50)]
        [Required(ErrorMessage = "Movie Title is required")]
        public string? Title { get; set; }
        [Required]
        [StringLength(50)]
        public string? Genre { get; set; }
        [Range(70, 600)]
        [Required]
        public int Runtime { get; set; }
        [Required]
        [StringLength(500)]
        public string? Description { get; set; }
        [Required]
        [StringLength(50)]
        public string? Director { get; set; }
    }
}
