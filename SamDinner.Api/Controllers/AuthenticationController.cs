using Microsoft.AspNetCore.Mvc;
using SamDinner.Application.Services.Authentication;
using SamDinner.Contracts.Authentication;

namespace SamDinner.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
            var response = new AuthenticationResponse(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email, authResult.Token);
            return Ok(response);
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var authResult = _authenticationService.Login(request.Email, request.Password);
            var response = new AuthenticationResponse(authResult.Id, authResult.FirstName, authResult.LastName, authResult.Email, authResult.Token);
            return Ok(response);
        }
    }
}
