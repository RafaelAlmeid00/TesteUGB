using UGB.Data;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UGB.Interface;
using System.Security.Cryptography;

namespace UGB.Services
{
    public class Auth : IAuth
    {
        private readonly IUsuario _usuario;

        public Auth(IUsuario usuario)
        {
            _usuario = usuario;
        }

        public string CreateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new byte[32]; // 32 bytes = 256 bits
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.NameIdentifier, _usuario.UserMat.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, _usuario.UserNome.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, _usuario.UserEmail.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, _usuario.UserSenha.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, _usuario.UserDepartamento.ToString()),

                ]),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
