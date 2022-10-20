using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Filme;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FilmesAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;
        public FilmeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]

        public IActionResult AdicionaFilme([FromBody] CreateCinemaDto filmedto)
        {
            Filme filme = _mapper.Map<Filme>(filmedto);


            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmesPorID), new { id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorID(int id)
        {

            Filme filme = _context.Filmes.FirstOrDefault(filmes => filmes.Id == id);

            if (filme != null)
            {
                ReadCinemaDto filmeDto = _mapper.Map<ReadCinemaDto>(filme);

                return Ok(filme);
            }

            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateCinemaDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme==null)
            {
                return NotFound();
            }

            _mapper.Map(filmeDto,filme);
            _context.SaveChanges();
            return NoContent(); 

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();


        }


    }
}
