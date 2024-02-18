using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Data.Dtos
{
  public class LoginUserDto
  {
    [Required]
    public required string Username { get; set; }
    [DataType(DataType.Password)]

    public required string Password { get; set; }
  }
}