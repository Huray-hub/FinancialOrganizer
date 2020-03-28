using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure
{
    public interface IJwtTokenGeneratorService
    {
        public string CreateToken(ApplicationUser user, IdentityRole role);
    }
}