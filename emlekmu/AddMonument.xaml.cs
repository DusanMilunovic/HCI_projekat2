using emlekmu.models;
using emlekmu.models.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Type = emlekmu.models.Type;
using System.Globalization;
using System.Text.RegularExpressions;
using static emlekmu.MainContent;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for AddMonument.xaml
    /// </summary>
    public partial class AddMonument : Window, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public ObservableCollection<Type> Types
        {
            get { return (ObservableCollection<Type>)GetValue(TypesProperty); }
            set { SetValue(TypesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Types.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypesProperty =
            DependencyProperty.Register("Types", typeof(ObservableCollection<Type>), typeof(AddMonument), new PropertyMetadata(new ObservableCollection<Type>()));



        public ObservableCollection<Monument> Monuments
        {
            get { return (ObservableCollection<Monument>)GetValue(MonumentsProperty); }
            set { SetValue(MonumentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Monuments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentsProperty =
            DependencyProperty.Register("Monuments", typeof(ObservableCollection<Monument>), typeof(AddMonument), new PropertyMetadata(new ObservableCollection<Monument>()));



        public ObservableCollection<Tag> Tags
        {
            get { return (ObservableCollection<Tag>)GetValue(TagsProperty); }
            set { SetValue(TagsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tags.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagsProperty =
            DependencyProperty.Register("Tags", typeof(ObservableCollection<Tag>), typeof(AddMonument), new PropertyMetadata(null));



        public onAddMonument AddMonumentCallback
        {
            get { return (onAddMonument)GetValue(AddMonumentCallbackProperty); }
            set { SetValue(AddMonumentCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddMonumentCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddMonumentCallbackProperty =
            DependencyProperty.Register("AddMonumentCallback", typeof(onAddMonument), typeof(AddMonument), new PropertyMetadata(null));



        public onAddType AddTypeCallBack
        {
            get { return (onAddType)GetValue(AddTypeCallBackProperty); }
            set { SetValue(AddTypeCallBackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddTypeCallBack.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddTypeCallBackProperty =
            DependencyProperty.Register("AddTypeCallBack", typeof(onAddType), typeof(AddMonument), new PropertyMetadata(null));



        public event PropertyChangedEventHandler PropertyChanged;

        public Monument monument;

        public Monument Monument
        {
            get
            {
                return monument;
            }
            set
            {
                if (value != monument)
                {
                    monument = value;
                    OnPropertyChanged("Monument");
                }
            }
        }

        public string era;
        
        public string Era
        {
            get
            {
                return era;
            }
            set
            {
                if (value != era)
                {
                    era = value;
                    OnPropertyChanged("Era");
                }
            }
        }

        public string dateEra;

        public string DateEra
        {
            get
            {
                return dateEra;
            }
            set
            {
                if (value != era)
                {
                    era = value;
                    OnPropertyChanged("DateEra");
                }
            }
        }

        public string touristic;

        public string Touristic
        {
            get
            {
                return touristic;
            }
            set
            {
                if (value != touristic)
                {
                    touristic = value;
                    OnPropertyChanged("Touristic");
                }
            }
        }

        public ObservableCollection<string> eras;

        public ObservableCollection<string> Eras
        {
            get
            {
                return eras;
            }
            set
            {
                if (value != eras)
                {
                    eras = value;
                    OnPropertyChanged("Eras");
                }
            }
        }

        public ObservableCollection<string> touristics;

        public ObservableCollection<string> Touristics
        {
            get
            {
                return touristics;
            }
            set
            {
                if (value != touristics)
                {
                    touristics = value;
                    OnPropertyChanged("Touristics");
                }
            }
        }

        public ObservableCollection<string> dateCollection;

        public ObservableCollection<string> DateCollection
        {
            get
            {
                return dateCollection;
            }
            set
            {
                if (value != dateCollection)
                {
                    dateCollection = value;
                    OnPropertyChanged("DateCollection");
                }
            }
        }

        public ObservableCollection<TagListBoxItem> tagListBoxItems;

        public ObservableCollection<TagListBoxItem> TagListBoxItems
        {
            get
            {
                return tagListBoxItems;
            }
            set
            {
                if (value != tagListBoxItems)
                {
                    tagListBoxItems = value;
                    OnPropertyChanged("TagListBoxItems");
                }
            }
        }

        public string dateString;

        public string DateString
        {
            get
            {
                return dateString;
            }
            set
            {
                if (value != dateString)
                {
                    dateString = value;
                    OnPropertyChanged("DateString");
                }
            }
        }

        public AddMonument()
        {
            InitializeComponent();
            Root.DataContext = this;
            initializeEraList();
            initializeTouristicList();
            this.dateCollection = getDateCollection();
            this.Monument = new Monument();
        }

        public AddMonument(
            ObservableCollection<Monument> monuments,
            ObservableCollection<Type> types,
            ObservableCollection<Tag> tags,
            onAddMonument addMonumentCallback,
            onAddType addTypeCallback)
        {
            InitializeComponent();
            Root.DataContext = this;
            initializeEraList();
            initializeTouristicList();
            this.dateCollection = getDateCollection();
            this.Monument = new Monument();
            this.Monuments = monuments;
            this.Monument.Id = findNextId();
            this.Types = types;
            this.Tags = tags;
            this.AddMonumentCallback = addMonumentCallback;
            this.AddTypeCallBack = addTypeCallback;
            this.TagListBoxItems = TagListBoxItem.initTagListBox();
            this.TagListBox.ItemsSource = this.TagListBoxItems;


        }

        public int findNextId()
        {
            int i = 1;
            loop: while (true)
            {
                foreach (var t in this.Monuments)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //debug button method
            DescriptionTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            IdTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            NameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            ImageTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            TypesComboBox.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            EraComboBox.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            IconTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            TouristicComboBox.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();
            IncomeTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            DateTextBox.GetBindingExpression(Xceed.Wpf.Toolkit.MaskedTextBox.TextProperty).UpdateSource();
            DateComboBox.GetBindingExpression(ComboBox.SelectedValueProperty).UpdateSource();

            int a = 3;
            a = a + 1;
        }

        public static ObservableCollection<string> getDateCollection()
        {
            var retVal = new ObservableCollection<string>();
            retVal.Add("BCE");
            retVal.Add("CE");
            return retVal;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
                Monument.Image = dlg.FileName;
                ImageTextBox.Text = dlg.FileName;
            }
        }

        private void AddType_Click(object sender, RoutedEventArgs e)
        {
            emlekmu.AddType dialog = new emlekmu.AddType(this.AddTypeCallBack, this.Types);
            dialog.Height = 750;
            dialog.Width = 400;
            dialog.ShowDialog();
        }

        public void initializeEraList()
        {
            this.Eras = new ObservableCollection<string>();
            this.Eras.Add("Paleolith");
            this.Eras.Add("Neolithic");
            this.Eras.Add("Ancient");
            this.Eras.Add("Medieval");
            this.Eras.Add("Renaissance");
            this.Eras.Add("Modern");
        }

        public void initializeTouristicList()
        {
            this.Touristics = new ObservableCollection<string>();
            this.Touristics.Add("Exploited");
            this.Touristics.Add("Available");
            this.Touristics.Add("Unavailable");
        }

        private void AddMonumentButton_Click(object sender, RoutedEventArgs e)
        {
            this.Monument.Era = (Era)Enum.Parse(typeof(Era), Era);
            this.Monument.TouristicStatus = (TouristicStatus)Enum.Parse(typeof(TouristicStatus), Touristic);
        }
    }

    public class TagListBoxItem
    {
        public bool Checked { get; set; }
        public string Name { get; set; }
        public models.Color Color { get; set; }

        public TagListBoxItem()
        {

        }

        public TagListBoxItem(string __name, models.Color color)
        {
            this.Checked = false;
            this.Name = __name;
            this.Color = color;
        }

        public static ObservableCollection<TagListBoxItem> initTagListBox()
        {
            var retVal = new ObservableCollection<TagListBoxItem>();
            retVal.Add(new TagListBoxItem("Name 1", new models.Color(20, 50, 100)));
            retVal.Add(new TagListBoxItem("Name 2", new models.Color(30, 40, 50)));
            retVal.Add(new TagListBoxItem("Name 3", new models.Color(40, 20, 30)));
            retVal.Add(new TagListBoxItem("Name 4", new models.Color(40, 20, 30)));
            retVal.Add(new TagListBoxItem("Name 5", new models.Color(40, 20, 30)));
            retVal.Add(new TagListBoxItem("Name 6", new models.Color(40, 20, 30)));
            return retVal;
        }
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
                date  = new DateTime(year, month, day);
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

    public class MonumentNameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == "")
            {
                return new ValidationResult(false, "Name property has to be filled.");
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
                return new ValidationResult(false, "Income has to be a positivine number");
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

}
