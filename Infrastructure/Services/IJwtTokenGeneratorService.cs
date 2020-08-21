using Infrastructure.Identity;

namespace Infrastructure.Services
{
    public interface IJwtTokenGeneratorService
    {
        public string CreateToken(ApplicationUser user, string roleName);
    }
}