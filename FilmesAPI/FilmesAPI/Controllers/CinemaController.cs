using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;
using AutoMapper;
using System.Linq;
using System.Collections.Generic;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using FluentResults;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaServices _cinemaService;
       
        public CinemaController(CinemaServices cinemaServices)
        {
            
        }

        [HttpPost]
        public IActionResult AdicionaCinema(CreateCinemaDto cinemaDto)
        {
            ReadCinemaDto readDto = _cinemaService.AdicionaCinema( cinemaDto);
            return CreatedAtAction(nameof(RecuperaCinemasPorID), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinemas([FromQuery] string nomeDoCinema)
        {
            List<ReadCinemaDto> cinemaDto = _cinemaService.RecuperaCinemas(nomeDoCinema);
            if (cinemaDto!=null)
            {
                return Ok(cinemaDto);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorID(int id)
        {
            ReadCinemaDto readDto = _cinemaService.RecuperarCinemasPorId(id);
            if (readDto!=null)
            {
                return Ok(readDto);
            }
            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result resultado = _cinemaService.AtualizarCinema(id,cinemaDto);
            if (resultado.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result resultado = _cinemaService.DeletaCinema(id);
            if (resultado.IsSuccess)
            {
                return NoContent();
            }
            return NoContent();
        }
    }
}
