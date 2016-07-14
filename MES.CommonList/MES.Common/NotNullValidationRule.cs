using System.Globalization;
using System.Windows.Controls;

namespace MES.Common
{
  public  class NotNullValidationRule : ValidationRule
    {
      public override ValidationResult Validate(object value, CultureInfo cultureInfo)
      {

          if (value == null || string.IsNullOrWhiteSpace(value as string))
          {

              return new ValidationResult(false, "value cannot benull");

          }



          return ValidationResult.ValidResult;

      }

    }
}
