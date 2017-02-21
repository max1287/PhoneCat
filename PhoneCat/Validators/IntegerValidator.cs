using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneCat.Validators
{
    public class IntegerValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid
        (object value, ValidationContext validationContext)
        {
            try
            {
                int a = Convert.ToInt32(value);
                return ValidationResult.Success;
            }
            catch
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }
        }
    }
}