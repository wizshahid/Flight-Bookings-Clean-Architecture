using AutoMapper;
using FlightBookings.Application.Interfaces;
using FlightBookings.Application.Models.Request;
using FlightBookings.Application.Models.Response;
using FlightBookings.Domain.Entities;
using FlightBookings.Domain.Enums;
using FlightBookings.Domain.Exceptions;
using FlightBookings.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Crypt = BCrypt.Net.BCrypt;

namespace FlightBookings.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;
    private readonly string key;

    public UserService(IUserRepository repository, IMapper mapper, IConfiguration configuration)
    {
        this.repository = repository;
        this.mapper = mapper;
        key = configuration["JWT:Secret"];
    }

    public AuthResponse Login(LoginRequest model)
    {
        var user = repository.GetAll().FirstOrDefault(x => x.Username.Equals(model.Username));

        if (user == null)
            throw new AppException("Username does not exist");

        if (Crypt.HashPassword(model.Password, user.Salt) != user.PasswordHash)
            throw new AppException("Password is incorrect");

        return GenerateToken(user);
    }

    public void SignUp(SignUpRequest model)
    {
        var user = mapper.Map<User>(model);
        user.Salt = Crypt.GenerateSalt();
        user.PasswordHash = Crypt.HashPassword(model.Password, user.Salt);
        repository.Add(user);
    }

    private AuthResponse GenerateToken(User user)
    {
        var tokenHandlder = new JwtSecurityTokenHandler();

        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            }),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha256)
        };

        var securityToken = tokenHandlder.CreateToken(descriptor);
        var token = tokenHandlder.WriteToken(securityToken);
        return new AuthResponse
        {
            Token = token,
            Id = user.Id,
            UserRole = UserRole.Admin,
        };
    }
}
