using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PhoneCat.Validators
{
    public class DoubleValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid
        (object value, ValidationContext validationContext)
        {
            try
            {
                double a = Convert.ToDouble(value, CultureInfo.InvariantCulture);
                return ValidationResult.Success;
            }
            catch
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }
        }
    }
}