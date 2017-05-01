using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Caliburn.Micro;
using FotoApp.Interface;

namespace FotoApp.ViewModels.ViewModelBase
{
    public abstract class ValidateModelBase : Screen, IDataErrorInfo, IValidationExceptionHandler
    {
        private readonly Dictionary<string, Func<ValidateModelBase, object>> _properytyGet;
        private readonly Dictionary<string, ValidationAttribute[]> _validatorValues;
        private int _validationExceptionCount;
        public int TotalPropertiesWithValidationCount => _validatorValues.Count();

        public string this[string columnName]
        {
            get
            {
                var properytyVal = _properytyGet[columnName](this);
                var errorMessage = _validatorValues[columnName]
                    .Where(v => !v.IsValid(properytyVal))
                    .Select(v => v.ErrorMessage)
                    .ToArray();
                return string.Join(Environment.NewLine, errorMessage);
            }
        }

        public string Error
        {
            get
            {
                var errors = _validatorValues
                    .SelectMany(v => v.Value, (v, a) => new {validator = v, attribute = a})
                    .Where(t => !t.attribute.IsValid(_properytyGet[t.validator.Key](this)))
                    .Select(t => t.attribute.ErrorMessage);
                return string.Join(Environment.NewLine, errors.ToArray());
            }
        }

        public int ValidPropertiesCount
        {
            get
            {
                var query = from validator in _validatorValues
                    where validator.Value.All(attribute => attribute.IsValid(_properytyGet[validator.Key](this)))
                    select validator;

                var count = query.Count() - _validationExceptionCount;
                return count;
            }
        }

        protected ValidateModelBase()
        {
            _validatorValues = GetType()
                .GetProperties()
                .Where(p => GetValidations(p).Length != 0)
                .ToDictionary(p => p.Name, p => GetValidations(p));

            _properytyGet = GetType()
                .GetProperties()
                .Where(p => GetValidations(p).Length != 0)
                .ToDictionary(p => p.Name, p => GetValueGetter(p));
        }

        private ValidationAttribute[] GetValidations(PropertyInfo property)
        {
            return (ValidationAttribute[]) property.GetCustomAttributes(typeof(ValidationAttribute), true);
        }

        private Func<ValidateModelBase, object> GetValueGetter(PropertyInfo property)
        {
            return viewmodel => property.GetValue(viewmodel, null);
        }

        public void ValidationExceptionChanged(int index)
        {
            _validationExceptionCount = index;
            NotifyOfPropertyChange(() => ValidPropertiesCount);
        }
    }
}
