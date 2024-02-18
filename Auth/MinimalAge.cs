using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace UsersApi.Auth
{
  public class MinimalAge : IAuthorizationRequirement
  {
    public MinimalAge(int age)
    {
      Age = age;
    }

    public int Age { get; set; }
  }
}