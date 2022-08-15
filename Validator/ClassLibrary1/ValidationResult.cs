using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectValidationLib
{
    public class ValidationResult
    {

        public string PropertyName { get; set; }

        public IEnumerable<ValidationRule> ValidationRules { get; set; }

    }
}
