using Application.Models;
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
        public async Task<ActionResult<UserObject>> Register(RegisterCommand command) =>
            await Mediator.Send(command);
    }
}
