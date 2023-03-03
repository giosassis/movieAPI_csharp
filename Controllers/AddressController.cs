using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;
using System.Net;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public AddressController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult PostAddress([FromBody] CreateAddresDto addresDto)
        {
            Address? address = _mapper.Map<Address>(addresDto);
            _context.Address.Add(address);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAddressById),
            new { Id = address.Id },
            addresDto);
        }

        [HttpGet]
        public IEnumerable<ReadAddressDto> GetAddress()
        {
            return _mapper.Map<List<ReadAddressDto>>(_context.Address.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetAddressById(int id)
        {
            Address? address = _context.Address.FirstOrDefault(address => address.Id == id);
            if (address != null)
            {
                ReadAddressDto addresDto = _mapper.Map<ReadAddressDto>(address);
                return Ok(addresDto);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult AddressUpdate(int id, [FromBody] UpdateAddressDto addresDto)
        {
            Address address = _context.Address.FirstOrDefault(address => address.Id == id);
            if (address == null) return NotFound("This address does not exists on database");
            _mapper.Map(addresDto, address);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(int id)
        {
            Address? address = _context.Address.FirstOrDefault(address => address.Id == id);
            if (address == null)
            {
                return NotFound("This address does not exists on database");
            }
            _context.Address.Remove(address);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

