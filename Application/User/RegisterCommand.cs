using Application.Common.Adapters;
using Application.Common.Models;
using Application.Common.ValidatorExtensions;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace Application.User
{
    public class RegisterCommand : IRequest<LoggedUserModel>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address cannot be empty.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email adress is not valid.");

            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.Password).IsPassword().NotEmpty();

            RuleFor(x => x.ConfirmPassword).NotEmpty();
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);
        }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, LoggedUserModel>
    {
        private readonly IUserManagerService _userManagerService;

        public RegisterCommandHandler(IUserManagerService userManagerService) =>
            _userManagerService = userManagerService;

        public async Task<LoggedUserModel> Handle(RegisterCommand request, CancellationToken cancellationToken) =>
            await _userManagerService.Register(request);
    }
}
