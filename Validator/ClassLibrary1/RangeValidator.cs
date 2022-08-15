using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectValidationLib

{
    
    public class RangeValidator : ValidationAttribute 
    {
        public RangeValidator(int min, int max)
        {
            this.max = max;
            this.min = min;
            ValidationName = "Range Validation";
        }
        public int min { get; set; }
        public int max { get; set; }
        
        public override bool Validate(object data)
        {
            int value = Convert.ToInt32(data);
            if (value < max && value > min)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
