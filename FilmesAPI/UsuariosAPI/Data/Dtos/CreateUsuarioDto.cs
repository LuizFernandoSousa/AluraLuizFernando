using System;
using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Dtos
{
    public class CreateUsuarioDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string rePassword { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }


    }
}
