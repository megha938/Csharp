using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectValidationLib
{
    public class ValidationRule
    {
        public ValidationStatus Status { get; set; }
        public string ErrorMessage { get; set; }

        public string ValidationType { get; set; }

    }

    public enum ValidationStatus
    {
        VALID,
        INVALID
    }
}
