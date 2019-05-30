using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static emlekmu.MainContent;
using Type = emlekmu.models.Type;
using System.IO;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for AddType.xaml
    /// </summary>
    public partial class AddType : Window, INotifyPropertyChanged
    {
        

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Type newType;

        public Type NewType
        {
            get
            {
                return newType;
            }
            set
            {
                if (value != newType)
                {
                    newType = value;
                    OnPropertyChanged("NewType");
                }
            }
        }

        public ObservableCollection<Type> Types
        {
            get { return (ObservableCollection<Type>)GetValue(TypesProperty); }
            set { SetValue(TypesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Types.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypesProperty =
            DependencyProperty.Register("Types", typeof(ObservableCollection<Type>), typeof(AddType), new PropertyMetadata(new ObservableCollection<Type>()));

        public onAddType AddTypeCallback
        {
            get { return (onAddType)GetValue(AddTypeCallbackProperty); }
            set { SetValue(AddTypeCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddTypeCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddTypeCallbackProperty =
            DependencyProperty.Register("AddTypeCallback", typeof(onAddType), typeof(AddType), new PropertyMetadata(null));



        public AddType()
        {
            InitializeComponent();
            this.NewType = new Type();
            Root.DataContext = this;
        }

        public AddType(onAddType addTypeCallback, ObservableCollection<Type> types)
        {
            InitializeComponent();
            this.NewType = new Type();
            this.AddTypeCallback = addTypeCallback;
            this.Types = types;
            this.NewType.Id = findNextId();
            
            Root.DataContext = this;
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Icon"; // Default file name
            dlg.DefaultExt = ".png"; // Default file extension
            dlg.Filter = "Text documents (.png)|*.png"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                NewType.Icon = dlg.FileName;
            }
        }

        private void AddTypeButton_Click(object sender, RoutedEventArgs e)
        {
            string validationMessage = ValidateForm();
            if (validationMessage != "") {
                ValidationLabel.Content = validationMessage;
                return;
            }
            AddTypeCallback(newType);
            AddTypeButton.IsCancel = true;
        }

        private int findNextId()
        {
            int i = 0;
            loop:  while (true)
            {
                foreach (var t in this.Types)
                {
                    if (t.Id == i)
                    {
                        i++;
                        goto loop;
                    }
                }
                return i;
            }
        }

        private string ValidateForm()
        {
            foreach (var t in Types)
            {
                if (t.Id == newType.Id)
                {
                    return "Id is not unique";
                }
            }
            Dictionary<ValidationRule, Object> rules = new Dictionary<ValidationRule, object>();
            rules.Add(IdValidation, newType.Id);
            rules.Add(NameValidation, newType.Name);
            rules.Add(DescriptionValidation, newType.Description);
            rules.Add(IconValidation, newType.Icon);
            foreach (var validation in rules.Keys)
            {
                var result = validation.Validate(rules[validation], null);
                if (!result.IsValid)
                {
                    return result.ErrorContent.ToString();
                }
            }
            return "";
        }
    }

    public class IdValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

        int _value;
            if (!int.TryParse(value.ToString(), out _value)) {
                return new ValidationResult(false, "Id has to be a number");
            }
            if (_value < 0)
            {
                return new ValidationResult(false, "Id can not be positive");
            }
            return new ValidationResult(true, "");
        }
    }

    public class NameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString() == "")
            {
                return new ValidationResult(false, "Name can not be empty");
            }
            return new ValidationResult(true, null);
        }
    }

    public class DescriptionValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString() == "")
            {
                return new ValidationResult(false, "Description can not be empty");
            }
            return new ValidationResult(true, null);
        }
    }

    public class IconValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString() == "")
            {
                return new ValidationResult(false, "File can not be empty");
            }
            if (!File.Exists(value.ToString())) {
                return new ValidationResult(false, "File does not exist");
            }
            return new ValidationResult(true, null);
        }
    }
}
