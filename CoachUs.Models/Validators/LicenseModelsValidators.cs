using FluentValidation;

namespace CoachUs.Models.Validators
{
    internal class LicenseCreateRequestModelValidator : AbstractValidator<LicenseCreateRequestModel>
    {
        public LicenseCreateRequestModelValidator()
        {
            RuleFor(r => r.OwnerId).NotEmpty()
                .WithMessage("Invalid Owner Id");

            RuleFor(r => r.Active).NotEmpty()
                .WithMessage("Invalid Active");

            RuleFor(r => r.LicensePackagePriceId).NotEmpty().GreaterThan(0)
                .WithMessage("Invalid License Package Price Id");

            RuleFor(r => r.Users).NotEmpty().GreaterThan(0)
                .WithMessage("Invalid Users");
        }
    }

    internal class LicenseUpdateRequestModelValidator : AbstractValidator<LicenseUpdateRequestModel>
    {
        public LicenseUpdateRequestModelValidator()
        {
            RuleFor(r => r.Id).NotEmpty().GreaterThan(0)
                .WithMessage("Invalid Id");

            RuleFor(r => r.Active).NotEmpty()
                .WithMessage("Invalid Active");
        }
    }
}