using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestfulAPI.Core.Interfaces;
using RestfulAPI.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestfulAPI.Core.Services
{
    public class Tokenuser : ITokenuser
    {
        private readonly SymmetricSecurityKey _key;
        public Tokenuser(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }
        public string CreateToken(AppUser user)
        {
            var cliam = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId , user.Username)
            };
             
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(cliam),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = cred
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(TokenDescriptor);

            return tokenHandler.WriteToken(token);
            
        }
    }
}
