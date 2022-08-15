using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ObjectValidationLib
{
    public static class ObjectValidator
    {
        public static IEnumerable<ValidationResult> Validate(object source)
        {
            List<ValidationResult> validateResult = new List<ValidationResult>();
            if (source != null)
            {
                Type classRef = source.GetType();
                var properties = classRef.GetProperties();
                foreach (var prop in properties)
                {
                    ValidationResult results = new ValidationResult { PropertyName = prop.Name, ValidationRules = new List<ValidationRule>()};

                    List<ValidationRule> validationRule = new List<ValidationRule>();

                    var reqAttribute = prop.GetCustomAttributes(typeof(ValidationAttribute), true) as ValidationAttribute[];
                    if (reqAttribute !=null)
                    {
                        foreach (var attribute in reqAttribute)
                        {
                            ValidationRule attributeRule = new ValidationRule();
                            attributeRule.ValidationType = attribute.ValidationName;
                            if (attribute.Validate(prop.GetValue(source)))
                            {
                                attributeRule.Status = ValidationStatus.INVALID;
                                attributeRule.ErrorMessage = attribute.Error;
                            }
                            else
                            {
                                attributeRule.Status = ValidationStatus.VALID;
                            }

                            validationRule.Add(attributeRule);
                        }
                        results.ValidationRules = validationRule;
                        validateResult.Add(results);
                    }
                }
            }

            return validateResult;
        }

    }
}

