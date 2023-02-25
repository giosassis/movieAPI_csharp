using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;

namespace MovieAPI.Controllers;

[ApiController]
[Route("[controller]")]

// DataAnnotations
public class MovieController : ControllerBase
{
    private MovieContext _context;
    private IMapper _mapper;

    public MovieController(MovieContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostMovie([FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _context.Movie.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovieById), 
            new { id = movie.Id },
            movie);
    }

    [HttpGet]
    //?skip=skip&take=5
    public IEnumerable<Movie> Movies([FromQuery]int skip = 0, [FromQuery] int take = 50) {
        return _context.Movie.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id){ 
       var result = _context.Movie.FirstOrDefault(movie => movie.Id == id);
        if (result == null) return NotFound("This movie doest not exists on database");
        return Ok(result);
    }
}
