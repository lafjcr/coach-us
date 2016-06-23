using CoachUs.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CoachUs.Models
{
    public class LicenseCreateRequestModel : IValidatableObject
    {
        public string OwnerId { get; set; }
        public bool Active { get; set; }
        public int LicensePackagePriceId { get; set; }
        public int Users { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new LicenseCreateRequestModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }

    public class LicenseUpdateRequestModel : IValidatableObject
    {
        public int Id { get; set; }
        public bool Active { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new LicenseUpdateRequestModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }

    public class LicenseBaseResponseModel
    {
        public int Id { get; set; }
        public bool Active{ get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class LicenseResponseModel : LicenseBaseResponseModel
    {
        public UserDetailReferenceResponseModel Owner { get; set; }
    }

    public class LicenseCreatedResponseModel : LicenseBaseResponseModel
    {
        public LicensePaymentOrderResponseModel PaymentOrder { get; set; }
    }

    public class LicenseGroupedResponseModel
    {
        public UserDetailReferenceResponseModel Owner { get; set; }
        public IEnumerable<LicenseBaseResponseModel> Licenses { get; set; }
    }
}
