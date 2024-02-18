using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Dtos;

namespace UsersApi.Services.User
{
  public interface IUserService
  {
    Task UserRegister(AddUserDto newUser);
    Task<string> Login(LoginUserDto user);
  }
}