using Application;
using Application.IdentityServices;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly IJwtTokenGeneratorService _jwtGeneratorService;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagerService(
            IJwtTokenGeneratorService jwtGeneratorService, 
            ApplicationDbContext applicationDbContext,
            UserManager<ApplicationUser> userManager)
        {
            _jwtGeneratorService = jwtGeneratorService;
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
        }

        //public async Task<(Result, string UserId)> CreateUserAsync(ApplicationUser model, string password)
        //{
        //    var user = new ApplicationUser
        //    {
        //        UserName = model.UserName,
        //        FirstName = model.FirstName,
        //        LastName = model.LastName,
        //        Email = model.Email,
        //        DateOfBirth = model.DateOfBirth,
        //        Country = model.Country                          
        //    };

        //    var result = await _userManager.CreateAsync(user, password);


        //    if (result.Succeeded)
        //    {

        //    }
        //}

        public Task<Result> DeleteUserAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
