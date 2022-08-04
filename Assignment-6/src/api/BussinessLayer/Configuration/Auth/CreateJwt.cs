using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TödebBootcampAssignment4.DTOs.AuthDto;
using TödebBootcampAssignment4.EntityLayer.Entities;

namespace TödebBootcampAssignment4.BusinessLayer.Configuration.Auth
{
    public class CreateJwt
    {
        internal static TokenDto GetJtwtToken(IConfiguration configuration, Customer customer)
        {
            var claims = new Claim[]
            {
                    new Claim(ClaimTypes.GivenName, customer.Id.ToString()),
                    new Claim(ClaimTypes.Email, customer.Mail),
                    new Claim(ClaimTypes.GivenName, customer.FirstName),
                    new Claim(ClaimTypes.Role,customer.Status.ToString())
            };
            var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOption>();

            var expireDate = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));
            var jwtToken = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                claims: claims,
                expires: expireDate,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            );

            return new()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                ExpireDate = expireDate,
            };
        }
    }
}
