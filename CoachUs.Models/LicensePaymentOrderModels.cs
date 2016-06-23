using CoachUs.Common.Enums;
using CoachUs.Models.Validators;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CoachUs.Models
{
    public class LicensePaymentOrderPayModel : IValidatableObject
    {
        public int Id { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentType PaymentType { get; set; }
        public string PaymentReference { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new LicensePaymentOrderPayModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }

//public class LicensePackagePriceCreateRequestModel : LicensePackagePriceBaseModel, IValidatableObject
//{
//    public int LicensePackageId { get; set; }

//    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
//    {
//        var validator = new LicensePackagePriceCreateRequestModelValidator();
//        var result = validator.Validate(this);
//        return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
//    }
//}

//public class LicensePackagePriceUpdateRequestModel : IValidatableObject
//{
//    public int Id { get; set; }
//    public bool Active { get; set; }

//    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
//    {
//        var validator = new LicensePackagePriceUpdateRequestModelValidator();
//        var result = validator.Validate(this);
//        return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
//    }
//}

public class LicensePaymentOrderResponseModel//: LicensePackagePriceBaseModel
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string LicensePackage { get; set; }
        public int Qty { get; set; }
        public int Users { get; set; }
        public decimal UnitAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime PaidDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentType PaymentType { get; set; }
        public string PaymentReference { get; set; }
        public bool PaymentConfirmed { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
