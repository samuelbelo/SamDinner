using Microsoft.AspNetCore.Mvc;
using OneOf;
using OneOf.Types;
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
        OneOf<AuthenticationResult, DuplicateEmailException> registerResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

        return registerResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            duplicateEmailException => Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exists")
        );

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
