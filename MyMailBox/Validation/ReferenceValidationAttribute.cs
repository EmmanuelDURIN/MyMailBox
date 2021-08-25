using System;
using System.ComponentModel.DataAnnotations;

namespace MyMailBox.Validation
{
  public class ReferenceValidationAttribute : ValidationAttribute
  {
    public char Letter { get; set; }

    protected override ValidationResult IsValid(object value,
                                                ValidationContext validationContext)
    {
      if (value != null)
      {
        var valueAsString = value.ToString();
        if (!string.IsNullOrEmpty(valueAsString))
        {
          if (!valueAsString.StartsWith(Letter))
          {
            return new ValidationResult(String.Format("Reference doesn't start with {0}", Letter));
          }
        }
      }
      return ValidationResult.Success;
    }
  }
}
