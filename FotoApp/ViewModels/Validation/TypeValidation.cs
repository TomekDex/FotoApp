using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FotoApp.ViewModels.Validation
{
    public class TypeValidation
    {
        public TypeValidation()
        {
            
        }

        public static  ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var tmp = Regex.Split(value.ToString(), "/");
            if (tmp.Length > 4)
                return  new ValidationResult(@"Za durzo typów/n Maksymalnie more być cztery przedielone '/'");
            foreach (var v in  tmp)
            {
                if (v.Length != 3)
                   return new ValidationResult("Nie prawidłowa długośc typu/n Typ musi mieć trzy litery");
            }
            return ValidationResult.Success;

        }
    }
}
