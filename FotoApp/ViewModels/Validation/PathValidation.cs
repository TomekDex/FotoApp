using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FotoApp.ViewModels.Validation
{
    public class PathValidation
    { 
        public PathValidation()
        {
            
        }
        public static ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!Regex.IsMatch(value.ToString(), @"^[D]:\\d"))
                return new ValidationResult("Nie prawidłowa ścierzka");
            return ValidationResult.Success;
        }
    }
}
