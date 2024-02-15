using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Dtos;

namespace UsersApi.Services
{
  public interface IUserService
  {

    Task<GetUserDto> UserRegister(AddUserDto newUser);
  }
}