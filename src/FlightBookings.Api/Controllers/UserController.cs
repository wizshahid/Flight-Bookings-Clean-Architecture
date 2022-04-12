using FlightBookings.Application.Interfaces;
using FlightBookings.Application.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookings.Api.Controllers;

[Route("api")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("register")]
    public IActionResult SignUp(SignUpRequest request)
    {
        userService.SignUp(request);
        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        return Ok(userService.Login(request));
    }
}
