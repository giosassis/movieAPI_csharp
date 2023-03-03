using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public CinemaController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult PostCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema? cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinema.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCinemaById),
            new { Id = cinema.Id },
            cinemaDto);
        }

        [HttpGet] 
        public IEnumerable<ReadCinemaDto> GetCinema()
        {
            return _mapper.Map<List<ReadCinemaDto>>(_context.Cinema.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCinemaById(int id)
        {
            Cinema? cinema = _context.Cinema.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto> (cinema);
                return Ok(cinemaDto);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult CinemaUpdate(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinema.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null) return NotFound("This cinema does not exists on database");
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCinema(int id)
        {
            Cinema? cinema = _context.Cinema.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound("This cinema does not exists on database");
            }
            _context.Cinema.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
