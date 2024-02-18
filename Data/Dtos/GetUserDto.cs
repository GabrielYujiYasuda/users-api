using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApi.Data.Dtos
{
  public class GetUserDto
  {
    [Required]
    public required string Username { get; set; } = string.Empty;
    public required DateTime BirthDate { get; set; }
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    [Compare("Password")]
    public required string PasswordConfirmation { get; set; }
  }
}