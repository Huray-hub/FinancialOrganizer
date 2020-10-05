using Application.Common.Models;
using Application.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    
    public class AuthenticationController : MediatorBaseController
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<LoggedUser>> Login(LoginQuery query) =>
            await Mediator.Send(query);

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<LoggedUser>> Register(RegisterCommand command) =>
            await Mediator.Send(command);


        [HttpGet]
        public async Task<ActionResult<LoggedUser>> CurrentUser() => await Mediator.Send(new CurrentUser());
    }
}
