using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace UsersApi.Auth
{
  public class MinimumAge : IAuthorizationRequirement
  {
    public MinimumAge(int age)
    {
      Age = age;
    }

    public int Age { get; set; }
  }
}