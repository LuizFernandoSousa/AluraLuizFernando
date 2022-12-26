using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text;
using System;
using UsuariosAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace UsuariosAPI.Services
{
    public class TokenService
    {
        public Token CreateToken(CustomIdentityUser usuario, string role)
        {
            Claim[] direitosUsuarios = new Claim[]
            {
                new Claim("username",usuario.UserName),
                new Claim("id",usuario.Id.ToString()),
                new Claim(ClaimTypes.Role,role),
                new Claim(ClaimTypes.DateOfBirth,usuario.DataNascimento.ToString())

            };

            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("3nnwojos304miopfnmisd423i"));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);



            var token = new JwtSecurityToken(
                claims: direitosUsuarios,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString);


        }
    }
}
