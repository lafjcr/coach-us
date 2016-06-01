using FluentValidation;

namespace CoachUs.Models.Validators
{
    internal class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            RuleFor(r => r.Id).NotEmpty()
                .WithMessage("Invalid Id");

            RuleFor(r => r.UserName).NotEmpty()
                .WithMessage("Invalid Username");
        }
    }
}