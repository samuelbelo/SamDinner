using FluentResults;
using SamDinner.Application.Common.Errors;

namespace SamDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    AuthenticationResult Login(string email, string password);
}