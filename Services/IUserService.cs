using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Data.Dtos;

namespace UsersApi.Services
{
  public interface IUserService
  {
    public Task<GetUserDto> UserRegister(AddUserDto newUser);
  }
}