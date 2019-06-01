using emlekmu;
using emlekmu.models;
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
using System.Windows.Shapes;
using static emlekmu.MainContent;
using Type = emlekmu.models.Type;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for EditMonument.xaml
    /// </summary>
    public partial class EditMonument : Window, INotifyPropertyChanged
    {

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public ObservableCollection<emlekmu.models.Type> Types
        {
            get { return (ObservableCollection<emlekmu.models.Type>)GetValue(TypesProperty); }
            set { SetValue(TypesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Types.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypesProperty =
            DependencyProperty.Register("Types", typeof(ObservableCollection<emlekmu.models.Type>), typeof(EditMonument), new PropertyMetadata(new ObservableCollection<Type>()));

        public ObservableCollection<Tag> Tags
        {
            get { return (ObservableCollection<Tag>)GetValue(TagsProperty); }
            set { SetValue(TagsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tags.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagsProperty =
            DependencyProperty.Register("Tags", typeof(ObservableCollection<Tag>), typeof(EditMonument), new PropertyMetadata(null));


        public onAddType AddTypeCallBack
        {
            get { return (onAddType)GetValue(AddTypeCallBackProperty); }
            set { SetValue(AddTypeCallBackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddTypeCallBack.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddTypeCallBackProperty =
            DependencyProperty.Register("AddTypeCallBack", typeof(onAddType), typeof(EditMonument), new PropertyMetadata(null));




        public onAddTag AddTagCallback
        {
            get { return (onAddTag)GetValue(AddTagCallbackProperty); }
            set { SetValue(AddTagCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddTagCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddTagCallbackProperty =
            DependencyProperty.Register("AddTagCallback", typeof(onAddTag), typeof(EditMonument), new PropertyMetadata(null));



        public onEditMonument EditMonumentCallback
        {
            get { return (onEditMonument)GetValue(EditMonumentCallbackProperty); }
            set { SetValue(EditMonumentCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditMonumentCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditMonumentCallbackProperty =
            DependencyProperty.Register("EditMonumentCallback", typeof(onEditMonument), typeof(EditMonument), new PropertyMetadata(null));



        public EditMonument()
        {
            InitializeComponent();
            Root.DataContext = this;
        }

        public EditMonument(ObservableCollection<Type> types, ObservableCollection<Tag> tags,
            onEditMonument editMonumentCallback, Monument oldMonument,
            onAddType addTypeCallback, onAddTag addTagCallback)
        {
            InitializeComponent();
            Root.DataContext = this;
            this.OldMonument = oldMonument;
            this.NewMonument = new Monument();
            this.copyOldMonument();
            this.initializeEraList();
            this.initializeTouristicList();
            this.DateCollection = getDateCollection();
            this.Tags = tags;
            this.TagListBox.ItemsSource = this.Tags;
            this.Types = types;
            this.AddTypeCallBack = addTypeCallback;
            this.AddTagCallback = addTagCallback;
            this.EditMonumentCallback = editMonumentCallback;
            resetTagFlags();
            setTagFlags();
            setEraComboBoxValue();
            setTouristicComboBoxValue();
            setDiscoveryDate();
            
        }

        private void copyOldMonument()
        {
            this.NewMonument.ArcheologicallyExplored = this.oldMonument.archeologicallyExplored;
            this.NewMonument.Description = this.oldMonument.description;
            this.NewMonument.DiscoveryDate = this.oldMonument.discoveryDate;
            this.NewMonument.Era = this.oldMonument.era;
            this.NewMonument.Icon = this.oldMonument.icon;
            this.NewMonument.Id = this.oldMonument.id;
            this.NewMonument.Image = this.oldMonument.image;
            this.NewMonument.Income = this.oldMonument.income;
            this.NewMonument.Name = this.OldMonument.name;
            this.NewMonument.PopulatedRegion = this.oldMonument.populatedRegion;
            this.NewMonument.Tags = new ObservableCollection<emlekmu.models.Tag>();
            foreach(Tag t in this.oldMonument.Tags)
            {
                this.NewMonument.Tags.Add(t);
            }
            this.NewMonument.TouristicStatus = this.oldMonument.touristicStatus;
            this.NewMonument.Type = this.oldMonument.type;
            this.NewMonument.Unesco = this.oldMonument.unesco;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Monument oldMonument;

        public Monument OldMonument
        {
            get
            {
                return oldMonument;
            }
            set
            {
                if (value != oldMonument)
                {
                    oldMonument = value;
                    OnPropertyChanged("OldMonument");
                }
            }
        }

        public Monument newMonument;

        public Monument NewMonument
        {
            get
            {
                return newMonument;
            }
            set
            {
                if (value != newMonument)
                {
                    newMonument = value;
                    OnPropertyChanged("NewMonument");
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
       

        public void setTagFlags()
        {
            foreach (Tag t1 in newMonument.Tags)
            {
                foreach (Tag t2 in this.Tags)
                {
                    if (t1.Id == t2.Id)
                    {
                        t2.Selected = true;
                        break;
                    }
                }
            }
        }

        public void resetTagFlags()
        {
            foreach (Tag t in this.Tags)
            {
                t.Selected = false;
            }
        }

        public static ObservableCollection<string> getDateCollection()
        {
            var retVal = new ObservableCollection<string>();
            retVal.Add("BCE");
            retVal.Add("CE");
            return retVal;
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

        public void setEraComboBoxValue()
        {
            string toSet = this.NewMonument.Era.ToString();
            foreach(string era in this.Eras)
            {
                if (toSet == era)
                {
                    this.Era = era;
                    break;
                }
            }
        }

        public void setTouristicComboBoxValue()
        {
            string toSet = this.NewMonument.TouristicStatus.ToString();
            foreach (string touristic in this.Touristics)
            {
                if (toSet == touristic)
                {
                    this.Touristic = touristic;
                    break;
                }
            }
        }

        public void setDiscoveryDate()
        {
            var parts = newMonument.DiscoveryDate.Split(' ');
            foreach(string era in this.DateCollection)
            {
                if (parts[1] == era)
                {
                    this.DateEra = era;
                    break;
                }
            }
            var dateParts = parts[0].Split('.');
            if (dateParts[0].Length == 1)
            {
                dateParts[0] = "0" + dateParts[0];
            }
            if (dateParts[1].Length == 1)
            {
                dateParts[1] = "0" + dateParts[1];
            }
            string dateString = dateParts[0] + "/" + dateParts[1] + "/" + dateParts[2];
            while (dateString.Length != 10)
            {
                dateString += '_';
            }
            this.DateString = dateString;
        }

        public void initializeTouristicList()
        {
            this.Touristics = new ObservableCollection<string>();
            this.Touristics.Add("Exploited");
            this.Touristics.Add("Available");
            this.Touristics.Add("Unavailable");
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
                NewMonument.Image = dlg.FileName;
                ImageTextBox.Text = dlg.FileName;
            }
        }

        private void AddType_Click(object sender, RoutedEventArgs e)
        {
            emlekmu.AddType dialog = new emlekmu.AddType(this.AddTypeCallBack, this.Types);
            dialog.Height = 750;
            dialog.Width = 400;
            dialog.Show();
        }

        private void AddTag_Click(object sender, RoutedEventArgs e)
        {
            emlekmu.AddTag dialog = new emlekmu.AddTag(this.AddTagCallback, this.Tags);
            dialog.Height = 750;
            dialog.Width = 400;
            dialog.Show();
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
                NewMonument.Icon = dlg.FileName;
                IconTextBox.Text = dlg.FileName;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditMonumentButton_Click(object sender, RoutedEventArgs e)
        {
            displayValidation();
            if (validateInputs())
            {
                this.NewMonument.Era = (Era)Enum.Parse(typeof(Era), this.Era);
                this.newMonument.TouristicStatus = (TouristicStatus)Enum.Parse(typeof(TouristicStatus), this.Touristic);
                this.formatDate();
                this.connectTags();
                this.EditMonumentCallback(this.NewMonument);
                this.Close();
            }
        }

        private void connectTags()
        {
            this.NewMonument.Tags = new ObservableCollection<models.Tag>();
            foreach (Tag t in this.Tags)
            {
                if (t.Selected)
                {
                    this.NewMonument.Tags.Add(t);
                }
            }
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
            this.NewMonument.DiscoveryDate = dateString;
        }

        private void displayValidation()
        {
            DescriptionTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
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
    }
}
