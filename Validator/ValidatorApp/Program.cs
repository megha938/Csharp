using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using static ObjectValidationLib.ObjectValidator;

namespace ValidatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PatientInfo objPatient = new PatientInfo() {Name = "Megha Sharma", Age = 25};
            var results = Validate(objPatient);
            foreach (var result in results)
            {
                Console.WriteLine(result.PropertyName);
                foreach (var rule in result.ValidationRules)
                {
                    Console.WriteLine($"{rule.ValidationType}: {rule.Status}: {rule.ErrorMessage}");
                }
            }
            Console.Read();
        }
    }
}
