using Application.Common.Models;
using Application.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : MediatorBaseController
    {         
        [HttpPost]
        public async Task<ActionResult<LoggedUserModel>> Login(LoginQuery query) =>
            await Mediator.Send(query);
    
        [HttpPost]
        public async Task<ActionResult<LoggedUserModel>> Register(RegisterCommand command) =>
            await Mediator.Send(command);
    }
}
