using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectValidationLib
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class ValidationAttribute : Attribute
    {
        public string Error { get; set; }

        public abstract bool Validate(object value);

        public string ValidationName { get; set; }
    }

}
