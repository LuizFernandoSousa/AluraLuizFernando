using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;

namespace MovieAPI.Controllers;

[ApiController]
[Route("[controller]")]

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
    public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(readMovieForID), new { id = movie.Id }, movie);
        
    }

    [HttpGet]
    public IEnumerable<Movie> readMovies([FromQuery] int skip = 0, int take = 20)
    {
        return _context.Movies.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]   
    public IActionResult readMovieForID(int id)
    {
        var movie =  _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null)
        {
           return NotFound();
        }
        return Ok(movie);

    }


    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
    {
        var movie =_context.Movies.FirstOrDefault(
            movie => movie.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        _mapper.Map(movieDto, movie);
        _context.SaveChanges();

        return NoContent();
    }


}
