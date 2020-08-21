using Application.User;
using System.Threading.Tasks;
using Application.Common.Models;

namespace Application.Common.Adapters
{
    public interface IUserManagerService
    {
        Task<LoggedUserModel> Login(LoginQuery request);
        Task<LoggedUserModel> Register(RegisterCommand command);
    }
}
