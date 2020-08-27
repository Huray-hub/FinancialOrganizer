using Application.Common.Models;
using Application.User;
using System.Threading.Tasks;

namespace Application.Common.Adapters
{
    public interface IUserManagerService
    {
        Task<LoggedUserModel> Login(LoginQuery request);
        Task<LoggedUserModel> Register(RegisterCommand command);
    }
}
