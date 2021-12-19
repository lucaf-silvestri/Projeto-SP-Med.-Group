using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_spMedicalGroup_webApi.Domains;
using senai_spMedicalGroup_webApi.Interfaces;
using senai_spMedicalGroup_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai_spMedicalGroup_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public LoginController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost("Login")]
        public IActionResult Login(Usuario login)
        {
            Usuario usuarioBuscado = _UsuarioRepository.Login(login.Email, login.Senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos.");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                new Claim("role", usuarioBuscado.IdTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmed-chave-autenticacao"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "Luca",
                audience: "Luca",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );
            return Ok(new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}