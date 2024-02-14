using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UsersApi.Model
{
  public class UserModel : IdentityUser
  {
    public DateTime BirthDate { get; set; }
    public UserModel() : base() { }
  }
}