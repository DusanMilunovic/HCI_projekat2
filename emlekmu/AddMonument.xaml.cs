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

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for AddMonument.xaml
    /// </summary>
    public partial class AddMonument : UserControl, INotifyPropertyChanged
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

        public ObservableCollection<ErasComboItem> eras;

        public ObservableCollection<ErasComboItem> Eras
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

        public ObservableCollection<TouristicStatusComboItem> touristic;

        public ObservableCollection<TouristicStatusComboItem> Touristic
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

        public string testString;

        public string TestString
        {
            get
            {
                return testString;
            }
            set
            {
                if (value != testString)
                {
                    testString = value;
                    OnPropertyChanged("TestString");
                }
            }
        }

        public AddMonument()
        {
            InitializeComponent();
            Root.DataContext = this;
            this.eras = ErasComboItem.initializeEraList();
            this.touristic = TouristicStatusComboItem.initializeTouristicList();
            this.dateCollection = getDateCollection();
            this.Monument = new Monument();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //debug button method
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
    }

    public class TouristicStatusComboItem
    {
        public string Name { get; set; }

        public TouristicStatus Value { get; set; }

        public TouristicStatusComboItem(string Name, TouristicStatus Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

        public static ObservableCollection<TouristicStatusComboItem> initializeTouristicList()
        {
            var retVal = new ObservableCollection<TouristicStatusComboItem>();
            retVal.Add(new TouristicStatusComboItem("Exploited", TouristicStatus.Exploited));
            retVal.Add(new TouristicStatusComboItem("Available", TouristicStatus.Available));
            retVal.Add(new TouristicStatusComboItem("Unavailable", TouristicStatus.Unavailable));
            return retVal;
        }
    }

    public class ErasComboItem
    {
        public string Name { get; set; }

        public Era Value { get; set; }

        public ErasComboItem(string Name, Era Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

        public static ObservableCollection<ErasComboItem> initializeEraList()
        {
            var retVal = new ObservableCollection<ErasComboItem>();
            retVal.Add(new ErasComboItem("Paleolith", Era.Paleolith));
            retVal.Add(new ErasComboItem("Neolithic", Era.Neolithic));
            retVal.Add(new ErasComboItem("Ancient", Era.Ancient));
            retVal.Add(new ErasComboItem("Medieval", Era.Medieval));
            retVal.Add(new ErasComboItem("Renaissance", Era.Renaissance));
            retVal.Add(new ErasComboItem("Modern", Era.Modern));
            return retVal;
        }
    }

    public class DateValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
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

}
