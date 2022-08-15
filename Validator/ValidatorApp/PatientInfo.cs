using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ValidatorApp
{
    class PatientInfo
    {
        public PatientInfo()
        {

        }
        [ObjectValidationLib.RequiredValidator(Error ="MRN requires value")]
        public string MRN { get; } = Guid.NewGuid().ToString();

        [ObjectValidationLib.RequiredValidator(Error = "Name requires value")]
        [ObjectValidationLib.LengthValidator(MaxLength = 12,Error = "Length of the name exceeds the limit of 12 characters")]
        public string Name { get; set; }

        [ObjectValidationLib.RangeValidator(12,85, Error = "Age Value Must be with in range 12-85")]
        public int Age { get; set; }
    }
}
