using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Data.Dtos
{
    public class ReadCinemaDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ReadAddressDto ReadAddressDto { get; set; }
        public string? Owner { get; set; }
    }
}
