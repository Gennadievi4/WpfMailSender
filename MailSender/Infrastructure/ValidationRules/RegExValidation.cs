using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MailSender.Infrastructure.ValidationRules
{
    public class RegExValidation : ValidationRule
    {
        private Regex _regEx;

        public string Pattern
        {
            get => _regEx.ToString();
            set => _regEx = string.IsNullOrWhiteSpace(value) ? null : new Regex(value);
        }

        public bool AllowNull { get; set; }
        public string Message { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is null)
                return AllowNull
                    ? ValidationResult.ValidResult
                    : new ValidationResult(false, Message ?? "Отсутствует ссылка на строку.");
            if (_regEx is null) return ValidationResult.ValidResult;

            if (!(value is string str))
                str = value.ToString();

            return _regEx.IsMatch(str)
                ? ValidationResult.ValidResult
                : new ValidationResult(false, Message ?? $"Строка не удовлетворяет регулярному выражению{_regEx}");
        }
    }
}
