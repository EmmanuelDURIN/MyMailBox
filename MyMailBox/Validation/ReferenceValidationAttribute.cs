using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace MyMailBox.Validation
{
  public class ReferenceValidationAttribute : ValidationAttribute, IClientModelValidator
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
    public void AddValidation(ClientModelValidationContext context)
    {
      if (context == null)
      {
        throw new ArgumentNullException(nameof(context));
      }

      context.Attributes["data-val"]= "true";
      context.Attributes["data-val-mailboxreference"] = "Invalid reference";
      context.Attributes["data-val-mailboxreference-letter"] = Letter.ToString();
    }
  }
}
