using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Session
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}

