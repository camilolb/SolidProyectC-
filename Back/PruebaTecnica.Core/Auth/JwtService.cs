using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PruebaTecnica.Core.Interfaces;

namespace PruebaTecnica.Core.Auth
{
    public class JwtService : IJwtService
    {
        private string SecureKey = "274ywwplwz27417AA$a12va3";

        public string Generate(int id)
        {
            
            var simetricSecurity = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecureKey));
            var credentials = new SigningCredentials(simetricSecurity, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);

            var payload = new JwtPayload(id.ToString(), null, null, null, DateTime.Today.AddDays(1));
            var securityToken = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
        
    }
}
