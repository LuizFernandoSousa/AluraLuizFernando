using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;
using AutoMapper;
using System.Linq;
using System;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Services;
using System.Collections.Generic;
using FluentResults;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class GerenteController : ControllerBase
    {
        private GerenteServices _gerenteServices;

        public GerenteController()
        {
            
        }
        [HttpPost]
        public IActionResult AdicionarGerente([FromBody] CreateGerenteDto gerenteDto)
        {
            ReadGerenteDto readDto = _gerenteServices.AdicionarGerente(gerenteDto);            
            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { id = readDto.Id }, readDto);

        }

        
        [HttpGet("{id}")]
        public IActionResult RecuperaGerentesPorId(int id)
        {
            ReadGerenteDto gerente = _gerenteServices.RecuperaGerentesPorId(id);
            if (gerente != null)
            {
                return Ok(gerente);
            }
            return NotFound();
        }
       
        [HttpDelete("{id}")]
        public IActionResult DeletaGerente(int id)
        {
            Result result = _gerenteServices.DeletaGerente(id);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();
        }


       


    }
}
