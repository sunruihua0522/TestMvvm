using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ObjectDataProviderBinding
{
    public class ValidRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if(double.TryParse(value.ToString(),out double x) && x>0 && x<100)
                return new ValidationResult(true, null);
            else
                return new ValidationResult(false, "范围需要在0-100之间");
        }
    }
}
