using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCxGridViewDataBinding.Models
{
    [AttributeUsage(AttributeTargets.Property |
      AttributeTargets.Field, AllowMultiple = false)]
    sealed public class CustomAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            MyModel m = validationContext.ObjectInstance as MyModel;
            if (m.ModelNameValidationState == "No")
                return ValidationResult.Success;
            string s = value as string;
            if (s.Contains("Name"))
                return new ValidationResult("ModelName contains invalid sequence");
            return ValidationResult.Success;
        }
    }
}
