using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.IO;
using System.Windows;
using System.Collections.ObjectModel;
using emlekmu.models;
using Type = emlekmu.models.Type;

namespace emlekmu
{
    class Validators
    {
    }

    public class DateValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Discovery date has to be entered");
            }
            var temp = value.ToString();
            string[] parts = temp.Split('/');
            int day;
            int month;
            int year;
            try
            {
                day = Convert.ToInt32(parts[0].Trim(new char[] { '_' }));
                month = Convert.ToInt32(parts[1].Trim(new char[] { '_' }));
                year = Convert.ToInt32(parts[2].Trim(new char[] { '_' }));
            }
            catch
            {
                return new ValidationResult(false, "Date has to consist of three numbers");
            }
            DateTime date;
            try
            {
                date = new DateTime(year, month, day);
            }
            catch
            {
                return new ValidationResult(false, "Date has to be a valid combination of day/month/year");
            }
            return new ValidationResult(true, null);
        }
    }

    public class MonumentIdValidationWrapper : DependencyObject
    {


        public ObservableCollection<Monument> Monuments
        {
            get { return (ObservableCollection<Monument>)GetValue(MonumentsProperty); }
            set { SetValue(MonumentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Monuments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentsProperty =
            DependencyProperty.Register("Monuments", typeof(ObservableCollection<Monument>), typeof(MonumentIdValidationWrapper), new FrameworkPropertyMetadata(new ObservableCollection<Monument>()));


    }

    public class MonumentIdValidation : ValidationRule
    {

        public MonumentIdValidationWrapper Wrapper { get; set; }



        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var temp = value.ToString();
            int new_id;
            try
            {
                new_id = Convert.ToInt32(value);
            }
            catch
            {
                return new ValidationResult(false, "Id has to be a number");
            }
            if (new_id < 0)
            {
                return new ValidationResult(false, "Id has to be a positive number");
            }
            Monument m = new List<Monument>(this.Wrapper.Monuments).Find(x => x.Id == new_id);
            if (m != null)
            {
                return new ValidationResult(false, "This id is already taken.");
            }
            return new ValidationResult(true, null);
        }


    }

    public class MonumentNameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "")
            {
                return new ValidationResult(false, "Name property has to be filled.");
            }
            if (value.ToString().Length > 50)
            {
                return new ValidationResult(false, "Name property can not be longer than 50 characters");
            }
            return new ValidationResult(true, null);
        }
    }

    public class MonumentDescriptionValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "")
            {
                return new ValidationResult(false, "Description property has to be filled.");
            }
            if (value.ToString().Length > 1000)
            {
                return new ValidationResult(false, "Name property can not be longer than 1000 characters");
            }
            return new ValidationResult(true, null);
        }
    }

    public class MonumentTypeValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Type t = (Type)value;
            if (t == null)
            {
                return new ValidationResult(false, "Type has to be selected");

            }
            return new ValidationResult(true, null);
        }
    }

    public class MonumentEraValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "An era must be selected");
            }
            return new ValidationResult(true, null);
        }
    }

    public class MonumentTouristicValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "A touristic status must be selected");
            }
            return new ValidationResult(true, null);
        }
    }

    public class MonumentIncomeValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Income must be filled in");
            }
            var temp = value.ToString();
            int temp_val;
            try
            {
                temp_val = Convert.ToInt32(temp);
            }
            catch
            {
                return new ValidationResult(false, "Income has to be a number");
            }
            if (temp_val < 0)
            {
                return new ValidationResult(false, "Income has to be a positive number");
            }
            return new ValidationResult(true, null);
        }
    }

    public class MonumentDateEraValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "An era must be selected for input date");
            }
            return new ValidationResult(true, null);
        }
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

    public class MonumentIconValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "")
            {
                return new ValidationResult(true, null);
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
