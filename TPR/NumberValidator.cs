using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TPR
{
    public class NumberValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string str && int.TryParse(str, out _))
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Введите целое значение.");
        }
    }
}
