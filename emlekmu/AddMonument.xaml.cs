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
using System.Threading;

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




        public onAddTag AddTagCallback
        {
            get { return (onAddTag)GetValue(AddTagCallbackProperty); }
            set { SetValue(AddTagCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddTagCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddTagCallbackProperty =
            DependencyProperty.Register("AddTagCallback", typeof(onAddTag), typeof(AddMonument), new PropertyMetadata(null));




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
                if (value != dateEra)
                {
                    dateEra = value;
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
            onAddType addTypeCallback,
            onAddTag addTagCallback)
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
            this.AddTagCallback = addTagCallback;
            TextCompositionManager.AddTextInputHandler(this,
                new TextCompositionEventHandler(OnTextComposition));
        }

        private void OnTextComposition(object sender, TextCompositionEventArgs e)
        {
            MainContent content = ((MainWindow)Application.Current.MainWindow).MainContent;
            if (content.DemonAlive)
            {
                content.Demon.Abort();
                content.DemonAlive = false;
            }
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

        public static ObservableCollection<string> getDateCollection()
        {
            var retVal = new ObservableCollection<string>();
            retVal.Add("BCE");
            retVal.Add("CE");
            return retVal;
        }

        private void AddType_Click(object sender, RoutedEventArgs e)
        {
            emlekmu.AddType dialog = new emlekmu.AddType(this.AddTypeCallBack, this.Types);
            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.Height = 490;
            dialog.Width = 350;
            dialog.MinHeight = 420;
            dialog.MinWidth = 280;
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

        private void displayValidation()
        {
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
        }

        private bool validateInputs()
        {
            Dictionary<ValidationRule, Object> rules = new Dictionary<ValidationRule, object>();
            rules.Add(this.MonumentIdValidation, IdTextBox.Text);
            rules.Add(this.MonumentNameValidation, NameTextBox.Text);
            rules.Add(this.MonumentDescriptionValidation, DescriptionTextBox.Text);
            rules.Add(this.MonumentImageValidation, ImageTextBox.Text);
            rules.Add(this.MonumentTypeValidation, TypesComboBox.SelectedValue);
            rules.Add(this.MonumentEraValidation, EraComboBox.SelectedValue);
            rules.Add(this.MonumentIconValidation, IconTextBox.Text);
            rules.Add(this.MonumentTouristicValidation, TouristicComboBox.SelectedValue);
            rules.Add(this.MonumentIncomeValidation, IncomeTextBox.Text);
            rules.Add(this.MonumentDateValidation, DateTextBox.Text);
            rules.Add(this.MonumentDateEraValidation, DateComboBox.SelectedValue);
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

        private void formatDate()
        {
            var parts = this.DateTextBox.Text.ToString().Split('/');
            int day;
            int month;
            int year;
            day = Convert.ToInt32(parts[0].Trim(new char[] { '_' }));
            month = Convert.ToInt32(parts[1].Trim(new char[] { '_' }));
            year = Convert.ToInt32(parts[2].Trim(new char[] { '_' }));
            DateTime tempTime = new DateTime(year, month, day);
            string dateString = tempTime.Day.ToString() + "." + tempTime.Month.ToString() + "." + tempTime.Year;
            dateString += " " + DateComboBox.SelectedValue;
            this.Monument.DiscoveryDate = dateString;
        }

        private void connectTags()
        {
            this.Monument.Tags = new ObservableCollection<models.Tag>();

            foreach (Tag t in this.TagListBox.SelectedItems)
            {
                this.Monument.Tags.Add(t);
            }
        }

        private void AddMonumentButton_Click(object sender, RoutedEventArgs e)
        {
            displayValidation();
            validateInputs();
            if (validateInputs())
            {
                this.Monument.Era = (Era)Enum.Parse(typeof(Era), Era);
                this.Monument.TouristicStatus = (TouristicStatus)Enum.Parse(typeof(TouristicStatus), Touristic);
                this.formatDate();
                this.connectTags();
                fixIcon();
                this.AddMonumentCallback(this.Monument);
                this.DialogResult = true;
                this.Close();
            }
            
        }

        private void fixIcon()
        {
            if (this.Monument.Icon == null || this.Monument.Icon == "")
            {
                this.Monument.Icon = this.Monument.Type.Icon;
            }
        }

        private void AddTag_Click(object sender, RoutedEventArgs e)
        {
            emlekmu.AddTag dialog = new emlekmu.AddTag(this.AddTagCallback, this.Tags);
            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.Height = 490;
            dialog.Width = 350;
            dialog.MinHeight = 420;
            dialog.MinWidth = 280;
            dialog.Show();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SelectIcon_Click(object sender, RoutedEventArgs e)
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
                Monument.Icon = dlg.FileName;
                IconTextBox.Text = dlg.FileName;
            }
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
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
    }


}
