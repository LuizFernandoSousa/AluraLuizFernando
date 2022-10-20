using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace FilmesAPI.Data.Dtos.Cinema
{
    public class UpdateEnderecoDto
    {

        [Required(ErrorMessage = "O campo titulo deve ser obrigatorio")]
        public string Nome { get; set; }

    }
}
