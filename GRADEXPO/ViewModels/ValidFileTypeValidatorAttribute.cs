using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace GRADEXPO.ViewModels
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    internal class ValidFileTypeValidatorAttribute : ValidationAttribute, IClientValidatable
    {
        private const string _DefaultErrorMessage = "Поддерживаются только файлы формата: {0}";
        private IEnumerable<string> _ValidTypes { get; set; }

        public ValidFileTypeValidatorAttribute(string validTypes)
        {
            _ValidTypes = validTypes.Split(',').Select(s => s.Trim().ToLower());
            ErrorMessage = string.Format(_DefaultErrorMessage, string.Join(" или ", _ValidTypes));
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            HttpPostedFileBase file = value as HttpPostedFileBase;
            if (file != null)
            {
                var isValid = _ValidTypes.Any(e => file.FileName.EndsWith(e));
                if (!isValid)
                {
                    return new ValidationResult(ErrorMessageString);
                }
            }
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "filetype",
                ErrorMessage = ErrorMessageString
            };
            rule.ValidationParameters.Add("validtypes", string.Join(",", _ValidTypes));
            yield return rule;
        }
    }
}
