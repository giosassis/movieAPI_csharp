using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
    public IEnumerable<ReadMovieDto> Movies([FromQuery]int skip = 0, [FromQuery] int take = 50) {
        return _mapper.Map<List<ReadMovieDto>>(_context.Movie.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id){
        var movie = _context.Movies;
        var result = _context.Movie.FirstOrDefault(movie => movie.Id == id);
        if (result == null) return NotFound("This movie does not exists on database");
        var movieDto = _mapper.Map<ReadMovieDto>(movie);
        return Ok(movieDto);
    }

    [HttpPut("{id}")]
    public IActionResult MovieUpdate(int id , [FromBody] UpdateMovieDto movieDto)
    {
        var movie = _context.Movie.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound("This movie does not exists on database");
        _mapper.Map(movieDto, movie );
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchMovie(int id, 
        JsonPatchDocument<UpdateMovieDto> patch) 
    {
        var movie = _context.Movie.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound("This movie does not exists on database");
        
        var movieToUpdate = _mapper.Map<UpdateMovieDto>(movie);

        patch.ApplyTo(movieToUpdate, ModelState);

        if(!TryValidateModel(movieToUpdate))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(movieToUpdate, movie);
        _context.SaveChanges();
        return NoContent();

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movie.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) return NotFound("This movie does not exists on database");
        _context.Movie.Remove(movie);
        _context.SaveChanges();
        return NoContent();
    }
}
