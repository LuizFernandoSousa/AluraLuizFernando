using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
    public IEnumerable<ReadMovieDto> readMovies([FromQuery] int skip = 0, int take = 20)
    {
        return _mapper.Map<List<ReadMovieDto>>(_context.Movies.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]   
    public IActionResult readMovieForID(int id)
    {
        var movie =  _context.Movies.FirstOrDefault(movie => movie.Id == id);

        if (movie == null)
        {
           return NotFound();
        }
        var movieDto = _mapper.Map<ReadMovieDto>(movie);

        return Ok(movieDto);

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

    [HttpPatch("{id}")]
    public IActionResult UpdateMoviePartial(int id, JsonPatchDocument<UpdateMovieDto> patch)
    {
        var movie = _context.Movies.FirstOrDefault(
            movie => movie.Id == id);
        if (movie == null)
        {
            return NotFound();
        }

        var movieForUpdate = _mapper.Map<UpdateMovieDto>(movie);

        patch.ApplyTo(movieForUpdate, ModelState);

        if (!TryValidateModel(movieForUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(movieForUpdate, movie);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies.FirstOrDefault(
            movie => movie.Id == id);
        if (movie == null)
        {
            return NotFound();
        }
        _context.Remove(movie);
        _context.SaveChanges();

        return NoContent();
    }



}
