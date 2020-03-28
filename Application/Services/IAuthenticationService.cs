using Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public interface IAuthenticationService
    {
        void Login();

        void Register(RegisterInput model);
    }
}
