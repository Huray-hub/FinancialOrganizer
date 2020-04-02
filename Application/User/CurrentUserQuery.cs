using Application.Interfaces;
using Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User
{
    public class CurrentUserQuery : IRequest<LoggedUserModel> { }

    public class Handler : IRequestHandler<CurrentUserQuery, LoggedUserModel>
    {
        private readonly IUserManagerService _userManagerService;

        public Handler(IUserManagerService userManagerService) => 
            _userManagerService = userManagerService;

        public async Task<LoggedUserModel> Handle(CurrentUserQuery request, CancellationToken cancellationToken) => 
            await _userManagerService.GetCurrentUser();
    }
}
