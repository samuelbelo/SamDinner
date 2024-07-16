using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SamDinner.Application.Common.Errors;
using SamDinner.Application.Services.Authentication;
using SamDinner.Contracts.Authentication;

namespace SamDinner.Api.Controllers;


[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        Result<AuthenticationResult> registerResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        if(registerResult.IsSuccess)
        {
            return Ok(MapAuthResult(registerResult.Value));
        }

        var firstError = registerResult.Errors[0];
        if (firstError is DuplicateEmailException)
        {
            return Conflict("Email already exists");
        }

        return Problem();

    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _authenticationService.Login(request.Email, request.Password);
        var response = new AuthenticationResponse(
            result.User.Id,
            result.User.FirstName,
            result.User.LastName,
            result.User.Email,
            result.Token);
        return Ok(response);
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
    }
}
