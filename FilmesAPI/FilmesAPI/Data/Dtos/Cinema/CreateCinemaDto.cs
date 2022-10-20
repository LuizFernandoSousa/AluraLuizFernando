using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace FilmesAPI.Data.Dtos.Cinema
{
    public class CreateEnderecoDto
    {
        [Required(ErrorMessage ="O campo de nome é obrigatório")]
        public string Nome { get; set; }
        public int EnderecoFK { get; set; }
        public int GerenteFK { get; set; }

    }
}
