using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;
using FilmesAPI.Data.Dtos.Filme;
using AutoMapper;
using System.Linq;

namespace FilmesAPI.Controllers
{
    public class CinemaController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]

        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);


            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemasPorID), new { id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas()
        {
            return Ok(_context.Cinemas);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorID(int id)
        {

            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema != null)
            {
                ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);

                return Ok(cinema);
            }

            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }

            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
