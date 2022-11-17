    using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using FluentResults;
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
        private FilmeServices _filmeService;
        public FilmeController(FilmeServices filmeServices)
        {
            _filmeService = filmeServices;
        }

        [HttpPost]

        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmedto)
        {

            ReadFilmeDto readDto =  _filmeService.AdicionarFilme(filmedto);            
            return CreatedAtAction(nameof(RecuperaFilmesPorID), new { id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaFilmes([FromBody] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDto> readDto = _filmeService.RecuperaFilmes(classificacaoEtaria);
            if (readDto != null)
            {
                return Ok(readDto);
            }                
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorID(int id)
        {

            ReadFilmeDto readDto = _filmeService.RecuperaFilmesPorID(id);
            if(readDto != null)
            {
                return Ok(readDto);
            }       
            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, UpdateFilmeDto filmeDto)
        {
            Result result = _filmeService.AtualizarFilme(id,filmeDto);
            if(result.IsSuccess)
            {
                return NoContent();
            }
            
            return NotFound(); 

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Result result = _filmeService.DeletaFilme(id);
            if(result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();

        }


    }
}
