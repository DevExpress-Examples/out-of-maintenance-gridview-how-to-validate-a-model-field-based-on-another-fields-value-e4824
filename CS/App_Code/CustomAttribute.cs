// Developer Express Code Central Example:
// GridView - How to validate a model field based on another field's value
// 
// This example demonstrates how to implement custom model validation for one field
// based on a another field's value. To accomplish this task, create a
// ValidationAttribute class descendant and override the IsValid method.
// You can
// learn more about this in the How to: Customize Data Field Validation in the Data
// Model Using Custom Attributes
// (http://msdn.microsoft.com/en-us/library/cc668224(v=vs.98).aspx) article.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4824

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
            string s = value as string;
                         
            if (!String.IsNullOrWhiteSpace(s) && m.ModelNameValidationState == "Yes" &&  s.Contains("Name"))
                return new ValidationResult("ModelName contains invalid sequence");
            else
                return ValidationResult.Success;
           
        }
    }
}
