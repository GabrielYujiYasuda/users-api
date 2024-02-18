using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace UsersApi.Auth
{
  public class AgeAuth : AuthorizationHandler<MinimalAge>
  {
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimalAge requirement)
    {
      var birthDateClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

      if (birthDateClaim is null)
      {
        return Task.CompletedTask;
      }

      var birthDate = Convert.ToDateTime(birthDateClaim.Value);

      var userAge = DateTime.Today.Year - birthDate.Year;

      if (birthDate > DateTime.Today.AddYears(-userAge))
      {
        userAge--;
      }

      if (userAge >= requirement.Age)
      {
        context.Succeed(requirement);
      }

      return Task.CompletedTask;
    }
  }
}