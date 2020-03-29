using Application.User;
using System.Threading.Tasks;
using Application.Models;

namespace Application.Interfaces
{
    public interface IUserManagerService
    {
        Task<UserObject> Register(RegisterCommand request);

        Task Login(string userName, string password);

        string GetCurrentUsername();
    }
}
