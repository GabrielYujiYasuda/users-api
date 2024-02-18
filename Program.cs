using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Context;
using UsersApi.Model;
using UsersApi.Services;
using Microsoft.EntityFrameworkCore;
using UsersApi.Services.User;
using UsersApi.Services.Token;
using UsersApi.Auth;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddSingleton<IAuthorizationHandler, AgeAuth>();

builder.Services.AddAuthorization(options =>
{
  options.AddPolicy("MinimumAge",
    policy => policy.AddRequirements(new MinimumAge(18)));
});

builder.Services.AddDbContext<UserDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<UserModel, IdentityRole>()
  .AddEntityFrameworkStores<UserDbContext>()
  .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
