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
using System.Collections.ObjectModel;
using emlekmu.models;
using static emlekmu.MainContent;
using System.Globalization;
using Xceed.Wpf.Toolkit;
using System.Threading;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for AddTag.xaml
    /// </summary>
    public partial class AddTag : Window, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public Thread Demon { get; set; }
        public bool DemonAlive { get; set; }

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


        public ObservableCollection<Tag> Tags
        {
            get { return (ObservableCollection<Tag>)GetValue(TagsProperty); }
            set { SetValue(TagsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tags.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagsProperty =
            DependencyProperty.Register("Tags", typeof(ObservableCollection<Tag>), typeof(AddTag), new PropertyMetadata(null));



        public onAddTag AddTagCallback
        {
            get { return (onAddTag)GetValue(AddTagCallbackProperty); }
            set { SetValue(AddTagCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddTagCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddTagCallbackProperty =
            DependencyProperty.Register("AddTagCallback", typeof(onAddTag), typeof(AddTag), new PropertyMetadata(null));

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

        public AddTag()
        {
            InitializeComponent();
            Root.DataContext = this;
        }

        public AddTag(onAddTag addTagCallback, ObservableCollection<Tag> tags)
        {
            this.AddTagCallback = addTagCallback;
            this.Tags = tags;
            NewTag = new models.Tag();
            InitializeComponent();
            Root.DataContext = this;
            TextCompositionManager.AddTextInputHandler(this,
               new TextCompositionEventHandler(OnTextComposition));

        }

        

        private void AddTagButton_Click(object sender, RoutedEventArgs e)
        {
            newTag.Description = DescriptionTextBox.Text;
            TagColor = ColorPickerCP.SelectedColor.Value;
            newTag.Id = IdTextBox.Text;
            IdTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            DescriptionTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            ColorPickerCP.GetBindingExpression(ColorPicker.SelectedColorProperty).UpdateSource();
            bool validation = ValidateForm();
            if (validation == false)
            {
                return;
            }
            newTag.Color = new models.Color(TagColor);
            AddTagCallback(newTag);
            this.DialogResult = true;
            this.Close();
        }

        private bool ValidateForm()
        {
            Dictionary<ValidationRule, Object> rules = new Dictionary<ValidationRule, object>();
            rules.Add(TagIdValidation, newTag.Id);
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

        private void OnTextComposition(object sender, TextCompositionEventArgs e)
        {
            if (this.DemonAlive)
            {
                this.Demon.Abort();
                this.DemonAlive = false;
            }
        }

    }

    public class TagIdValidationWrapper : DependencyObject
    {
        public ObservableCollection<Tag> Tags
        {
            get { return (ObservableCollection<Tag>)GetValue(TagsProperty); }
            set { SetValue(TagsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tags.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagsProperty =
            DependencyProperty.Register("Tags", typeof(ObservableCollection<Tag>), typeof(TagIdValidationWrapper), new FrameworkPropertyMetadata(new ObservableCollection<Tag>()));
    }
}
