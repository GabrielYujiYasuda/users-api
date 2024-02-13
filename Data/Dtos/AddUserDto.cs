using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Data.Dtos
{
  public class AddUserDto
  {
    public required string Username { get; set; }
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    public required DateTime BirthDate { get; set; }
    [Compare("Password")]
    public required string PasswordConfirmation { get; set; }
  }
}