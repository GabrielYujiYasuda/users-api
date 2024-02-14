using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Dtos;
using UsersApi.Model;

namespace UsersApi.Services
{
  public class UserService : IUserService

  {
    private readonly IMapper _mapper;
    private readonly UserManager<UserModel> _userManager;

    public UserService(IMapper mapper, UserManager<UserModel> userManager)
    {
      _mapper = mapper;
      _userManager = userManager;
    }

    public async Task<GetUserDto> UserRegister(AddUserDto newUser)
    {
      var user = _mapper.Map<UserModel>(newUser);

      var response = await _userManager.CreateAsync(user, newUser.Password);

      if (!response.Succeeded)
      {
        throw new Exception($"Fail to register the user.");
      }

      var responseMapped = _mapper.Map<GetUserDto>(response);
      return responseMapped;
    }
  }
}