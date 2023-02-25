using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;

namespace MovieAPI.Controllers;

[ApiController]
[Route("[controller]")]

// DataAnnotations
public class MovieController : ControllerBase
{
    private static List<Movie> movies = new List<Movie>();
    private static int id = 1;
    [HttpPost]
    public IActionResult PostMovie([FromBody] Movie movie)
    {
        movie.Id = id++;
        movies.Add(movie);
        return CreatedAtAction(nameof(GetMovieById), 
            new { id = movie.Id },
            movie);
    }

    [HttpGet]
    //?skip=skip&take=5
    public IEnumerable<Movie> Movies([FromQuery]int skip = 0, [FromQuery] int take = 50) {
        return movies.Skip(skip).Take(take) ;
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id) { 
    
       var result =  movies.FirstOrDefault(movie => movie.Id == id);
        if (result == null) return NotFound("This movie doest not exists on database");
        return Ok(result);
    }
}
