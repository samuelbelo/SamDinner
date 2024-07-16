using SamDinner.Application.Common.Errors;
using SamDinner.Application.Common.Interfaces.Authentication;
using SamDinner.Application.Common.Interfaces.Persistence;
using SamDinner.Domain.Entities;

namespace SamDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //1. validate the user doesn't exist
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new DuplicateEmailException();
        }

        //2. create user (generate unique ID) and persist to database

        var user = new User {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.Add(user);

        //3. create jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(
            user,
            token);

    }

    public AuthenticationResult Login(string email, string password)
    {
        //1. validate the user exists
        if(_userRepository.GetUserByEmail(email) is not User user){
            throw new UserNotExistentException();
        }
        //2. validate the password
        if(user.Password != password){
            throw new InvalidPasswordException();
        }

        //3. create jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}