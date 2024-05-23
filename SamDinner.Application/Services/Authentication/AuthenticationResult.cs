using SamDinner.Domain.Entities;

namespace SamDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);
