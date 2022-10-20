using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        public virtual Endereco endereco { get; set; }
        public int enderecoId { get; set; }

        public int EnderecoFK { get; set; }

        public int GerenteFk { get; set; }

    }
}
