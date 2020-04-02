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
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly IJwtTokenGeneratorService _jwtGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _identityContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        #region Constructor
        public UserManagerService(
            IJwtTokenGeneratorService jwtGenerator,
            IHttpContextAccessor httpContextAccessor,
            ApplicationDbContext identityContext,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _identityContext = identityContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtGenerator = jwtGenerator;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Methods
        public async Task<LoggedUserModel> GetCurrentUser()
        {
            var userName =_httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var user = await _userManager.FindByNameAsync(userName);
            var roleName = GetRoleNameByUserIdAsync(user.Id);
           
            return new LoggedUserModel
            {
                Username = user.DisplayName,
                Token = _jwtGenerator.CreateToken(user, roleName)
            };
        }

        public async Task<LoggedUserModel> Login(LoginQuery request)
        {
            var user = _userManager.FindByEmailAsync(request.Email).Result;
            var roleName = GetRoleNameByUserIdAsync(user.Id);

            if (user == null)
                throw new RestException(HttpStatusCode.Unauthorized);

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (result.Succeeded)
            {
                return new LoggedUserModel
                {
                    Username = user.UserName,
                    Token = _jwtGenerator.CreateToken(user, roleName)
                };
            };

            throw new RestException(HttpStatusCode.Unauthorized);
        }

        public async Task<LoggedUserModel> Register(RegisterCommand request)
        {
            if (await _identityContext.Users.Where(x => x.Email == request.Email).AnyAsync())
                throw new BadRequestException("Email already exists");

            var username = $"{request.FirstName} {request.LastName}";
            if (await _identityContext.Users.Where(x => x.UserName == username).AnyAsync())
                throw new BadRequestException("Username already exists");

            var user = new ApplicationUser(request);

            

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");

                return new LoggedUserModel
                {
                    Username = user.UserName,
                    Token = _jwtGenerator.CreateToken(user, "User")
                };
            }

            throw new Exception("Problem creating user");
        }

        private string GetRoleNameByUserIdAsync(string userId)
        {
            var roleId = _identityContext.UserRoles.Where(x => x.UserId == userId).Select(x => x.RoleId).FirstOrDefault();
            var role = _roleManager.FindByIdAsync(roleId).Result;
            
            return role?.Name ??
                throw new BadRequestException("Role not found");
        }
        #endregion
    }
}
