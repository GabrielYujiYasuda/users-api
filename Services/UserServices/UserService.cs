using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Dtos;
using UsersApi.Model;
using UsersApi.Services.TokenServices;

namespace UsersApi.Services
{
  public class UserService : IUserService

  {
    private readonly IMapper _mapper;
    private readonly UserManager<UserModel> _userManager;
    private readonly SignInManager<UserModel> _signInManager;
    private readonly TokenService _tokenService;

    public UserService(IMapper mapper, UserManager<UserModel> userManager, SignInManager<UserModel> signInManager, TokenService tokenService)
    {
      _mapper = mapper;
      _userManager = userManager;
      _signInManager = signInManager;
      _tokenService = tokenService;
    }

    public async Task Login(LoginUserDto user)
    {
      var mappedUser = _mapper.Map<UserModel>(user);

      var response = await _signInManager.PasswordSignInAsync(mappedUser, user.Password, false, false);

      if (!response.Succeeded)
      {
        throw new Exception($"User not authenticated");
      }
    }

    public async Task UserRegister(AddUserDto newUser)
    {
      UserModel user = _mapper.Map<UserModel>(newUser);

      var response = await _userManager.CreateAsync(user, newUser.Password);

      if (!response.Succeeded)
      {
        throw new Exception($"Fail to register the user.");
      }

      _tokenService.GenerateToken(user);
      //If the method retuns a User
      // var responseMapped = _mapper.Map<GetUserDto>(user);
      // return responseMapped;
    }
  }
}