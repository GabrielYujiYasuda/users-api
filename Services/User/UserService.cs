using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Dtos;
using UsersApi.Model;
using UsersApi.Services;
using UsersApi.Services.Token;

namespace UsersApi.Services.User
{
  public class UserService : IUserService

  {
    private readonly IMapper _mapper;
    private readonly UserManager<UserModel> _userManager;
    private readonly SignInManager<UserModel> _signInManager;
    private readonly TokenService _tokenService;

    public UserService(IMapper mapper, UserManager<UserModel> userManager,
     SignInManager<UserModel> signInManager, TokenService tokenService)
    {
      _mapper = mapper;
      _userManager = userManager;
      _signInManager = signInManager;
      _tokenService = tokenService;
    }

    public async Task<string> Login(LoginUserDto userDto)
    {
      var mappedUser = _mapper.Map<UserModel>(userDto);

      var response = await _signInManager.PasswordSignInAsync(userDto.Username, userDto.Password, false, false);

      if (!response.Succeeded)
      {
        Console.WriteLine(response);
        throw new Exception($"User not authenticated");
      }

      var user = _signInManager
      .UserManager
      .Users
      .FirstOrDefault(user => user.NormalizedUserName == userDto.Username.ToUpper());

      if (user is null)
      {
        throw new Exception($"User not authenticated");
      }

      var token = _tokenService.GenerateToken(user);

      return token;
    }

    public async Task UserRegister(AddUserDto newUser)
    {
      UserModel user = _mapper.Map<UserModel>(newUser);

      var response = await _userManager.CreateAsync(user, newUser.Password);

      if (!response.Succeeded)
      {
        throw new Exception($"Fail to register the user.");
      }

    }
  }
}