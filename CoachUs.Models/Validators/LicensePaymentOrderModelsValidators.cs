using FluentValidation;

namespace CoachUs.Models.Validators
{
    internal class LicensePaymentOrderPayModelValidator : AbstractValidator<LicensePaymentOrderPayModel>
    {
        public LicensePaymentOrderPayModelValidator()
        {
            RuleFor(r => r.Id).NotEmpty()
                .WithMessage("Invalid Id");

            RuleFor(r => r.PaymentType).IsInEnum()
                .WithMessage("Invalid Payment Type");
        }
    }
}