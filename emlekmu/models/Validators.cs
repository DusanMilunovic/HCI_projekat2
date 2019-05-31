using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;
using System.Windows;

namespace emlekmu
{
    class Validators
    {
    }

    public class IdValidation : ValidationRule
    {

        public IdValidationWrapper Wrapper { get;set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            int _value;
            if (!int.TryParse(value.ToString(), out _value))
            {
                return new ValidationResult(false, "Id has to be a number");
            }
            if (_value < 0)
            {
                return new ValidationResult(false, "Id can not be positive");
            }
            foreach (var type in Wrapper.Types)
            {
                if (type.Id == _value)
                {
                    return new ValidationResult(false, "Id is not unique");
                }
            }
            return new ValidationResult(true, "");
        }
    }

    public class NameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "")
            {
                return new ValidationResult(false, "Name can not be empty");
            }
            string _value = value.ToString();
            if (_value.Length > 50)
            {
                return new ValidationResult(false, "Name has to be shorter than 50 characters");
            }
            return new ValidationResult(true, null);
        }
    }

    public class DescriptionValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "")
            {
                return new ValidationResult(false, "Description can not be empty");
            }
            string _value = value.ToString();
            if (_value.Length > 1000)
            {
                return new ValidationResult(false, "Description has to be shorter than 1000 characters");
            }
            return new ValidationResult(true, null);
        }
    }

    public class ColorValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string _value = value.ToString();
            if (_value == "#00000000" || _value == "#00FFFFFF")
            {
                return new ValidationResult(false, "Color can not be empty");
            }
            return new ValidationResult(true, null);
        }
    }

    public class IconValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "")
            {
                return new ValidationResult(false, "File can not be empty");
            }
            if (!File.Exists(value.ToString()))
            {
                return new ValidationResult(false, "File does not exist");
            }
            return new ValidationResult(true, null);
        }
    }

    public class TagIdValidation : ValidationRule
    {
        public TagIdValidationWrapper Wrapper { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "")
            {
                return new ValidationResult(false, "Tag id can not be empty");
            }
            string _value = value.ToString();
            foreach(var tag in Wrapper.Tags)
            {
                if (_value == tag.Id)
                {
                    return new ValidationResult(false, "Tag id is not unique");
                }
            }
            if (_value.Length > 50)
            {
                return new ValidationResult(false, "Tag id has to be shorter than 50 characters");
            }
            return new ValidationResult(true, null);
        }
    }

    public class BindingProxy : System.Windows.Freezable
    {
        protected override Freezable CreateInstanceCore()
        {
            return new BindingProxy();
        }

        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new PropertyMetadata(null));
    }
}
