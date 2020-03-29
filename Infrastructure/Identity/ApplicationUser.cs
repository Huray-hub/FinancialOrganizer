using Application.User;
using Microsoft.AspNetCore.Identity;
using System;

namespace Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }
        public ApplicationUser(RegisterCommand request)
        {
            UserName = request.FirstName;
            DisplayName = $"{request.FirstName} {request.LastName}";
            FirstName = request.FirstName;
            LastName = request.LastName;
            DateOfBirth = request.DateOfBirth;
            Country = request.Country;
            Email = request.Email;
        }

        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
    }
}
