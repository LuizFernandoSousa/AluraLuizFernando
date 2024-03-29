﻿using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.Requests
{
    public class EfetuaResetRequest
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string rePassword { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }


    }
}
