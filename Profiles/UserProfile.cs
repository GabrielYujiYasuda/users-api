using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Dtos;
using UsersApi.Model;

namespace UsersApi.Profiles
{
  public class UserProfile : Profile
  {
    public UserProfile()
    {
      CreateMap<AddUserDto, UserModel>();
      CreateMap<UserModel, GetUserDto>();
      CreateMap<LoginUserDto, UserModel>();
    }
  }
}