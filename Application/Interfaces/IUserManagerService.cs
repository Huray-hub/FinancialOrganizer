using Application.User;
using System.Threading.Tasks;
using Application.Models;

namespace Application.Interfaces
{
    public interface IUserManagerService
    {
        Task<LoggedUserModel> GetCurrentUser();      
        Task<LoggedUserModel> Login(LoginQuery request);
        Task<LoggedUserModel> Register(RegisterCommand request);
    }
}
