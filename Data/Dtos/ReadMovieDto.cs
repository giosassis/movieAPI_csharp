namespace MovieAPI.Data.Dtos
{
    public class ReadMovieDto
    {
        
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int Runtime { get; set; }
        public string? Description { get; set; }
        public string? Director { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
