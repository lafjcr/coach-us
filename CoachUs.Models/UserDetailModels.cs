﻿using CoachUs.Common.Enums;
using CoachUs.Models.Validators;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CoachUs.Models
{
    public class UserDetailBaseModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }
        public string Country { get; set; }
    }

    public class UserDetailModel : UserDetailBaseModel, IValidatableObject
    {
        public System.DateTime BirthDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Laterality Laterality { get; set; }
        public string Address { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new UserDetailModelValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }

    public class UserDetailReferenceResponseModel : UserDetailBaseModel
    {
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
