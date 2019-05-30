using System;
using System.Collections.Generic;
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
using emlekmu.models;
using static emlekmu.MainContent;
using System.ComponentModel;
using Xceed.Wpf.Toolkit;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for EditTag.xaml
    /// </summary>
    public partial class EditTag : Window, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Tag newTag;

        public Tag NewTag
        {
            get
            {
                return newTag;
            }
            set
            {
                if (value != newTag)
                {
                    newTag = value;
                    OnPropertyChanged("NewTag");
                }
            }
        }


        public onEditTag EditTagCallback
        {
            get { return (onEditTag)GetValue(EditTagCallbackProperty); }
            set { SetValue(EditTagCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditTagCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditTagCallbackProperty =
            DependencyProperty.Register("EditTagCallback", typeof(onEditTag), typeof(EditTag), new PropertyMetadata(null));

        public System.Windows.Media.Color tagColor;

        public System.Windows.Media.Color TagColor
        {
            get
            {
                return tagColor;
            }
            set
            {
                if (value != tagColor)
                {
                    tagColor = value;
                    OnPropertyChanged("TagColor");
                }
            }
        }


        public EditTag(Tag tagToEdit, onEditTag editTagCallback)
        {
            InitializeComponent();
            Root.DataContext = this;
            EditTagCallback = editTagCallback;
            NewTag = new models.Tag();
            NewTag.Id = tagToEdit.Id;
            NewTag.Description = tagToEdit.Description;
            NewTag.Color = tagToEdit.Color;
            TagColor = System.Windows.Media.Color.FromRgb((byte)newTag.Color.Red, (byte)newTag.Color.Green, (byte)newTag.Color.Blue);
        }

        private void EditTagButton_Click(object sender, RoutedEventArgs e)
        {
            newTag.Description = DescriptionTextBox.Text;
            TagColor = ColorPickerCP.SelectedColor.Value;
            IdTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            DescriptionTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            ColorPickerCP.GetBindingExpression(ColorPicker.SelectedColorProperty).UpdateSource();
            bool validation = ValidateForm();
            if (validation == false)
            {
                return;
            }
            newTag.Color = new models.Color(TagColor);
            EditTagCallback(newTag);
            EditTagButton.IsCancel = true;
        }

        private bool ValidateForm()
        {
            Dictionary<ValidationRule, Object> rules = new Dictionary<ValidationRule, object>();
            rules.Add(DescriptionValidation, newTag.Description);
            rules.Add(ColorValidation, TagColor);
            foreach (var validation in rules.Keys)
            {
                var result = validation.Validate(rules[validation], null);
                if (!result.IsValid)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
