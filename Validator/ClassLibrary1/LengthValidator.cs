using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectValidationLib
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class LengthValidator : ValidationAttribute
    {
        public LengthValidator()
        {
            ValidationName = " Length Valid";
        }
        public int MaxLength { get; set; }

        public override bool Validate(object data)
        {            
            string datastr = data.ToString();
            if (datastr.Length > MaxLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
