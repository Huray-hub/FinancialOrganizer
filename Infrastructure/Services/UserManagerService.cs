using Application.Exceptions;
using Application.Interfaces;
using Application.Models;
using Application.User;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenGeneratorService _jwtGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserManagerService(
            IJwtTokenGeneratorService jwtGenerator,
            IHttpContextAccessor httpContextAccessor,
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUsername() =>
            _httpContextAccessor.HttpContext.User?.Claims?
                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        public Task Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<UserObject> Register(RegisterCommand request)
        {
            if (await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
                throw new BadRequestException("Email already exists");

            var username = $"{request.FirstName} {request.LastName}";
            if (await _context.Users.Where(x => x.UserName == username).AnyAsync())
                throw new BadRequestException("Username already exists");

            var user = new ApplicationUser(request);

            

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");

                return new UserObject
                {
                    Username = user.UserName,
                    Token = _jwtGenerator.CreateToken(user, "User")
                };
            }

            throw new Exception("Problem creating user");
        }
    }
}
