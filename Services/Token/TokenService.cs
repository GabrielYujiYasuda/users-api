using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using UsersApi.Model;

namespace UsersApi.Services.Token
{
  public class TokenService
  {
    public string GenerateToken(UserModel user)
    {
      if (user.UserName is null)
      {
        throw new Exception($"User not authenticated");
      }

      Claim[] claims = new Claim[]
      {
        new Claim("username", user.UserName),
        new Claim("id", user.Id),
        new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString())
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("65DA65DAS54D654DAS6D4A6S54D8A4D852AS4D85"));

      var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        expires: DateTime.Now.AddMinutes(10),
        claims: claims,
        signingCredentials: signingCredentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}