using CoachUs.Common.Enums;
using FluentValidation;

namespace CoachUs.Models.Validators
{
    internal class UserDetailModelValidator : AbstractValidator<UserDetailModel>
    {
        public UserDetailModelValidator()
        {
            RuleFor(r => r.UserId).NotEmpty()
                .WithMessage("Invalid Id");

            RuleFor(r => r.Name).NotEmpty()
                .WithMessage("Invalid Name");

            RuleFor(r => r.LastName).NotEmpty()
                .WithMessage("Invalid LastName");

            RuleFor(r => r.BirthDate).NotEmpty()
                .WithMessage("Invalid BirthDate");

            RuleFor(r => r.Gender).IsInEnum()
                .WithMessage("Invalid Gender");

            RuleFor(r => r.Laterality).IsInEnum()
                .WithMessage("Invalid Laterality");

            RuleFor(r => r.Country).NotEmpty()
                .WithMessage("Invalid Country");

            RuleFor(r => r.Address).NotEmpty()
                .WithMessage("Invalid Address");
        }
    }
}