using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;
using FilmesAPI.Data.Dtos.Filme;
using AutoMapper;
using System.Linq;
using System;
using FilmesAPI.Data.Dtos.Gerente;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GerenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDto);

            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { id = gerente.Id }, gerente);

        }
        [HttpGet]
        public IActionResult RecuperaGerentes()
        {
            return Ok(_context.Gerentes);
        }
        [HttpGet("{id}")]
        public IActionResult RecuperaGerentesPorId(int id)
        {

            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente != null)
            {
                ReadGerenteDto gerenteDto = _mapper.Map<ReadGerenteDto>(gerente);

                return Ok(gerente);
            }

            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarGerente(int id, [FromBody] UpdateGerenteDto gerenteDto)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }

            _mapper.Map(gerenteDto, gerente);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente == null)
            {
                return NotFound();
            }
            _context.Remove(gerente);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
