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
    public class EnderecoController : ControllerBase
    {
        private EnderecoServices _enderecoServices;

        public EnderecoController(EnderecoServices enderecoServices)
        {
            _enderecoServices = enderecoServices;
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto readDto = _enderecoServices.AdicionaEndereco(enderecoDto);            
            return CreatedAtAction(nameof(RecuperaEnderecoPorID), new { Id = readDto.Id }, readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorID(int id)
        {
            Endereco endereco = _enderecoServices.RecuperaEnderecoPorID(id);
            if (endereco!=null)
            {
                return Ok(endereco);
            }
            return NotFound();
        }


        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result result = _enderecoServices.AtualizarEndereco(id,enderecoDto);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();
            

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Result result = _enderecoServices.DeletaEndereco(id);
            if (result.IsSuccess)
            {
                return NoContent();
            }
            return NotFound();
            


        }


    }
}
