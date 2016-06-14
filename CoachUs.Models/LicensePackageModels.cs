using CoachUs.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CoachUs.Models
{
    public class LicensePackageBaseModel
    {
        public string Name { get; set; }
        public int Users { get; set; }
        public int MinUsers { get; set; }
        public int MaxUsers { get; set; }
        public bool Active { get; set; }
    }

    public class LicensePackageCreateRequestModel : LicensePackageBaseModel, IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new LicensePackageCreateRequestModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }

    public class LicensePackageUpdateRequestModel : IValidatableObject
    {
        public int Id { get; set; }
        public bool Active { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new LicensePackageUpdateRequestModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }

    public class LicensePackageResponseModel : LicensePackageBaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
