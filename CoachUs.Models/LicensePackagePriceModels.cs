using CoachUs.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CoachUs.Models
{
    public class LicensePackagePriceBaseModel
    {
        public int Months { get; set; }
        public decimal Price{ get; set; }
        public bool Active { get; set; }
    }

    public class LicensePackagePriceCreateRequestModel : LicensePackagePriceBaseModel, IValidatableObject
    {
        public int LicensePackageId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new LicensePackagePriceCreateRequestModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }

    public class LicensePackagePriceUpdateRequestModel : IValidatableObject
    {
        public int Id { get; set; }
        public bool Active { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new LicensePackagePriceUpdateRequestModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }

    public class LicensePackagePriceResponseModel : LicensePackagePriceBaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
