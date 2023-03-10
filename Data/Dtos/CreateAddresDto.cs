using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.Dtos
{
    public class CreateAddresDto
    {
        public string? ZipCode { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Country { get; set; }
        public string? Region { get; set; }
        public string? State { get; set; }
        [Required]
        public string? Street { get; set; }
        [Required]
        public int Number { get; set; }
    }
}
