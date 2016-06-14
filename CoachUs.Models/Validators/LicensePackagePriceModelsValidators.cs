using FluentValidation;

namespace CoachUs.Models.Validators
{
    internal class LicensePackagePriceCreateRequestModelValidator : AbstractValidator<LicensePackagePriceCreateRequestModel>
    {
        public LicensePackagePriceCreateRequestModelValidator()
        {
            RuleFor(r => r.LicensePackageId).NotEmpty().GreaterThan(0)
                .WithMessage("Invalid License Package Id");

            RuleFor(r => r.Months).NotEmpty().GreaterThan(0)
                .WithMessage("Invalid Months");

            RuleFor(r => r.Price).NotEmpty()
                .WithMessage("Invalid Price");

            RuleFor(r => r.Active).NotEmpty()
                .WithMessage("Invalid Active");
        }
    }

    internal class LicensePackagePriceUpdateRequestModelValidator : AbstractValidator<LicensePackagePriceUpdateRequestModel>
    {
        public LicensePackagePriceUpdateRequestModelValidator()
        {
            RuleFor(r => r.Id).NotEmpty().GreaterThan(0)
                .WithMessage("Invalid Id");

            RuleFor(r => r.Active).NotEmpty()
                .WithMessage("Invalid Active");
        }
    }
}