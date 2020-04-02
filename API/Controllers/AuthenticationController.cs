using Application.Models;
using Application.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{  
    public class AuthenticationController : MediatorBaseController
    {
        [HttpGet]
        public async Task<ActionResult<LoggedUserModel>> CurrentUser() =>
            await Mediator.Send(new CurrentUserQuery());

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<LoggedUserModel>> Login(LoginQuery query) =>
            await Mediator.Send(query);

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<LoggedUserModel>> Register(RegisterCommand command) =>
            await Mediator.Send(command);
    }
}
