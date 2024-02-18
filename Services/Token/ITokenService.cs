using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Model;

namespace UsersApi.Services.Token
{
  public interface ITokenService
  {
    string GenerateToken(UserModel user);
  }
}