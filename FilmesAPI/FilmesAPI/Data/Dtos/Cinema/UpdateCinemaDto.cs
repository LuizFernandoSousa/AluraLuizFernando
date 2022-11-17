using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace FilmesAPI.Data.Dtos
{
    public class UpdateCinemaDto
    {

        [Required(ErrorMessage = "O campo Nome é obrigatorio")]
        public string Nome { get; set; }

    }
}
