﻿using SamDinner.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamDinner.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        AuthenticationResult Register(string firstName, string lastName, string email, string password);
        AuthenticationResult Login(string email, string password);
    }
}
