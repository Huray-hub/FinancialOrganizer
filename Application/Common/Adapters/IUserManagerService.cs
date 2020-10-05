using Application.Common.Models;
using Application.User;
using System.Threading.Tasks;

namespace Application.Common.Adapters
{
    public interface IUserManagerService
    {
        Task<LoggedUser> Login(LoginQuery request);
        Task<LoggedUser> Register(RegisterCommand command);
        Task<LoggedUser> RefreshUser();
    }
}
