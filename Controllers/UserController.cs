using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Dtos;
using UsersApi.Services;
using UsersApi.Services.User;

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
      await _userService.UserRegister(newUser);

      return Ok("User registered successfully.");
    }

    [HttpPost("Login")]
    public async Task<ActionResult<string>> Login(LoginUserDto user)
    {
      var response = await _userService.Login(user);

      return Ok(response);
    }
  }
}