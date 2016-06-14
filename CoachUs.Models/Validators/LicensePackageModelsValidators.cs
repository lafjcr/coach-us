using FluentValidation;

namespace CoachUs.Models.Validators
{
    internal class LicensePackageCreateRequestModelValidator : AbstractValidator<LicensePackageCreateRequestModel>
    {
        public LicensePackageCreateRequestModelValidator()
        {
            RuleFor(r => r.Name).NotEmpty()
                .WithMessage("Invalid Name");

            RuleFor(r => r.Users).NotEmpty().GreaterThan(0)
                .WithMessage("Invalid Users");

            RuleFor(r => r.MinUsers).NotEmpty().GreaterThan(0)
                .WithMessage("Invalid MinUsers");

            RuleFor(r => r.MaxUsers).NotEmpty().GreaterThan(r => r.MinUsers)
                .WithMessage("Invalid MaxUsers");

            RuleFor(r => r.Active).NotEmpty()
                .WithMessage("Invalid Active");
        }
    }

    internal class LicensePackageUpdateRequestModelValidator : AbstractValidator<LicensePackageUpdateRequestModel>
    {
        public LicensePackageUpdateRequestModelValidator()
        {
            RuleFor(r => r.Id).NotEmpty().GreaterThan(0)
                .WithMessage("Invalid Id");

            RuleFor(r => r.Active).NotEmpty()
                .WithMessage("Invalid Active");
        }
    }
}