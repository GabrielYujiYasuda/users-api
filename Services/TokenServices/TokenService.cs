using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using UsersApi.Model;

namespace UsersApi.Services.TokenServices
{
  public class TokenService : ITokenService
  {
    public void GenerateToken(UserModel user)
    {
      Claim[] claims = new Claim[]
      {
        new Claim("username", user.UserName),
        new Claim("id", user.Id),
        new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString())
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("A95N7aiAT8V0N4V"));

      var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        expires: DateTime.Now.AddMinutes(10),
        claims: claims,
        signingCredentials: signingCredentials);
    }
  }
}