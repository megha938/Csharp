using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectValidationLib
{
    public class RequiredValidatorAttribute: ValidationAttribute
    {
        public RequiredValidatorAttribute()
        {
            ValidationName = "Value Required Validation";
        }
        public override bool Validate(object data)
        {
            string value = data.ToString();
            return string.IsNullOrEmpty(value);
        }
    }
}
