using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KnockKnock.Validators
{
    public class FibonacciInputValidator: ValidationAttribute
    {
        private long _max = 0; 
        public FibonacciInputValidator(int max)
        {
            _max = max;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}
