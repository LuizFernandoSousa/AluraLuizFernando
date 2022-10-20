using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo titulo deve ser obrigatorio")]
        public string Titulo {get;set;}


        [Required]
        [StringLength(100, ErrorMessage = "O campo diretor deve ser obrigatorio")]
        public string Diretor {get;set;}


        [StringLength(30,ErrorMessage = "O genêro deve conter no maximo 30 caracteres")]
        public string Genero { get; set; }


        [Range(1,600,ErrorMessage = " A duração deve conter no minimo 1 e no maximo 600 minutos")]
        public int Duracao { get; set; }

        public int ClassificacaoEtaria { get; set; }

    }
}
