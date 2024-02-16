using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Dtos;
using UsersApi.Services;

namespace UsersApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpPost("Register")]
    public async Task<ActionResult> UserRegister(AddUserDto newUser)
    {
      await _userService.UserRegister(newUser);

      return Ok("User registered successfully.");
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login(LoginUserDto user)
    {
      await _userService.Login(user);

      return Ok("User authenticated.");
    }
  }
}