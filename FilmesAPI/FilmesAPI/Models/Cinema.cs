﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatorio")]
        public string Nome { get; set; }

        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }
        [JsonIgnore]
        public virtual Gerente Gerente { get; set; }
        [JsonIgnore]
        public int GerenteId { get; set; }
        public virtual List<Sessao> Sessoes { get; set; } 

    }
}
