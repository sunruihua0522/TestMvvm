using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestBindingValid.Rules
{
    public class MustBeDouble : ValidationRule
    {
        public string CheckType { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            switch (CheckType.ToLower())
            {
                case "double":
                    if (double.TryParse(value.ToString(), out double d))
                    {
                        if (d > Min && d < Max)
                            return new ValidationResult(true, "");
                        return new ValidationResult(false, $"请输入{Min}-{Max}之内的数字");
                    }
                    return new ValidationResult(false, "请输入正确的数字");
                case "int":
                    if (double.TryParse(value.ToString(), out double i))
                    {
                        if (i > Min && i < Max)
                            return new ValidationResult(true, "");
                        return new ValidationResult(false, $"请输入{Min}-{Max}之内的数字");
                    }
                    return new ValidationResult(false, "请输入正确的数字");
            }
            return new ValidationResult(false, "");
        }
        
    }
}
