using System.ComponentModel.DataAnnotations;
using AssessmentAddressAPI.Validation;

namespace AssessmentAddressAPI.Boundary.Validation
{
    public class PostcodeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var postCode = value as string;

            if (!PostCodeValidator.IsValidPostcode(postCode))
            {
                return new ValidationResult("Invalid postcode.");
            }

            return ValidationResult.Success;
        }
    }
}
