using AutoMapper;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    public class SessaoController
    {
        [ApiController]
        [Route("[controller]")]
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
            public IActionResult AdicionaSessao([FromBody] CreateSessaoDto SessaoDto)
            {
                Sessao sessao = _mapper.Map<Sessao>(SessaoDto);
                _context.Sessoes.Add(sessao);
                _context.SaveChanges();
                return CreatedAtAction(nameof(RecuperaSessoesPorID), new { id = sessao.Id }, sessao);
            }

            [HttpGet]
            public IEnumerable<Sessao> RecuperaSessao([FromQuery] string nomeDaSessao)
            {
                return _context.Sessoes;
            }

            [HttpGet("{id}")]
            public IActionResult RecuperaSessoesPorID(int id)
            {

                Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

                if (sessao != null)
                {
                    ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

                    return Ok(sessaoDto);
                }

                return NotFound();
            }


        //    [HttpPut("{id}")]
        //    public IActionResult AtualizarSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        //    {
        //        Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
        //        if (sessao == null)
        //        {
        //            return NotFound();
        //        }
        //
        //        _mapper.Map(sessaoDto, sessao);
        //        _context.SaveChanges();
        //        return NoContent();
        //
        //    }

            [HttpDelete("{id}")]
            public IActionResult DeletaSessao(int id)
            {
                Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
                if (sessao == null)
                {
                    return NotFound();
                }
                _context.Remove(sessao);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
