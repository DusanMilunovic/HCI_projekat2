using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for EditType.xaml
    /// </summary>
    public partial class EditType : Window, INotifyPropertyChanged
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



        public onEditType EditTypeCallback
        {
            get { return (onEditType)GetValue(EditTypeCallbackProperty); }
            set { SetValue(EditTypeCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditTypeCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditTypeCallbackProperty =
            DependencyProperty.Register("EditTypeCallback", typeof(onEditType), typeof(EditType), new PropertyMetadata(null));



        public Type TypeToEdit
        {
            get { return (Type)GetValue(TypeToEditProperty); }
            set { SetValue(TypeToEditProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TypeToEdit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeToEditProperty =
            DependencyProperty.Register("TypeToEdit", typeof(Type), typeof(EditType), new PropertyMetadata(null));



        public EditType()
        {
            InitializeComponent();
            this.NewType = new Type();
            Root.DataContext = this;
        }

        public EditType(Type typeToEdit, onEditType editTypeCallback)
        {
            InitializeComponent();
            this.NewType = new Type();
            this.newType.Id = typeToEdit.Id;
            this.newType.Name = typeToEdit.Name;
            this.NewType.Description = typeToEdit.Description;
            this.NewType.Icon = typeToEdit.Icon;

            Root.DataContext = this;
            EditTypeCallback = editTypeCallback;
        }

        private void EditTypeButton_Click(object sender, RoutedEventArgs e)
        {
            NewType.Name = NameTextBox.Text;
            NewType.Description = DescriptionTextBox.Text;
            NewType.Icon = IconTextBox.Text;
            string validationMessage = ValidateForm();
            if (validationMessage != "")
            {
                ValidationLabel.Content = validationMessage;
                return;
            }
            EditTypeCallback(newType);
            this.DialogResult = true;
            this.Close();
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

        private string ValidateForm()
        {
            Dictionary<ValidationRule, Object> rules = new Dictionary<ValidationRule, object>();
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
}
