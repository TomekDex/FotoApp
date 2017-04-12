using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoApp.ViewModels.Validation
{
    public class ExekuteCharacter : ValidationAttribute
    {
        private string _characters;

        public ExekuteCharacter(string characters)
        {
            this._characters = characters;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                for (int i = 0; i < _characters.Length; i++)
                {
                    var tmpString = value.ToString();
                    if (tmpString.Contains(_characters[i]))
                    {
                        var errorMessage = validationContext.DisplayName;
                        return new ValidationResult(errorMessage);
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
