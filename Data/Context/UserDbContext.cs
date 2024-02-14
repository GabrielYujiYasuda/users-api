using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsersApi.Model;

namespace UsersApi.Data.Context
{
  public class UserDbContext : IdentityDbContext<UserModel>
  {
    public UserDbContext(DbContextOptions<UserDbContext> opts) : base(opts)
    {

    }
  }
}