using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace MovieAPI.Models
{
    public class Movie
    {
       
        [Required]
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Movie Title is required")]   
        public string? Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Genre { get; set; }
        [Range(70, 600)]
        [Required]
        public int Runtime { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Director { get; set; }
        public int AgeGroup { get; set; }

    }
}
