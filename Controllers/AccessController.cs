using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsersApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AccessController : ControllerBase
  {
    [HttpGet]
    [Authorize(Policy = "MinimumAge")]
    public ActionResult Get()
    {
      return Ok("Access allowed");
    }
  }
}