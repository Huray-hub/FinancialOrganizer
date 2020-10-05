

using Application.Common.Adapters;
using Application.Common.Exceptions;
using Application.Common.Models;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User
{
    public class CurrentUser : IRequest<LoggedUser> { }

    public class CurrentUserHandler : IRequestHandler<CurrentUser, LoggedUser>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserManagerService _userManagerService;

        public CurrentUserHandler(ICurrentUserService currentUserService, IUserManagerService userManagerService)
        {
            _currentUserService = currentUserService;
            _userManagerService = userManagerService;
        }

        public async Task<LoggedUser> Handle(CurrentUser request, CancellationToken cancellationToken)
        {
            if (_currentUserService.IsAuthenticated)                       
                return await _userManagerService.RefreshUser();
            
            throw new RestException(HttpStatusCode.Unauthorized);
        }
    }
}