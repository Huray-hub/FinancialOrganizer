using Application.Models;
using FluentValidation;

namespace Application.Validators
{
    public class RegisterInputValidator : AbstractValidator<RegisterInput>
    {
        public RegisterInputValidator()
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
}
