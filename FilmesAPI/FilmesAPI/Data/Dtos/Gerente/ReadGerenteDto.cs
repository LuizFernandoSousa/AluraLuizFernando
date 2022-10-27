﻿using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace FilmesAPI.Data.Dtos
{
    public class ReadGerenteDto
    {        
        public int Id { get; set; }
        public string Nome { get; set; }

        public object cinemas { get; set; }
    }
}
