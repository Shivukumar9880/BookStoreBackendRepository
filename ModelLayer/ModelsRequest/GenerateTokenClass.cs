using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ModelsRequest
{
    public class GenerateTokenClass
    {


        public string GenerateSecurityToken(string Email, int UserId, IConfiguration configuration)
        {
            try
            {
                var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
                var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                    new Claim("Email", Email),
                    new Claim("UserId", UserId.ToString())
                };
                var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(configuration["Jwt:Issuer"],
                    configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials);


                return new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
    }
}
