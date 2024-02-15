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
    public async Task<ActionResult<GetUserDto>> UserRegister(AddUserDto newUser)
    {
      var response = await _userService.UserRegister(newUser);

      if (response is null)
      {
        return BadRequest(response);
      }

      return Ok(response);
    }
  }
}