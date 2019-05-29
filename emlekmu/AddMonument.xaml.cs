﻿using emlekmu.models;
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



        public AddMonument()
        {
            InitializeComponent();
            Root.DataContext = this;
            this.eras = ErasComboItem.initializeEraList();
            this.touristic = TouristicStatusComboItem.initializeTouristicList();
            this.Monument = new Monument();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //debug button method
            int a = 3;
            a = a + 1;
        }
    }

    public class TouristicStatusComboItem
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public TouristicStatusComboItem(string Name, int Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

        public static ObservableCollection<TouristicStatusComboItem> initializeTouristicList()
        {
            var retVal = new ObservableCollection<TouristicStatusComboItem>();
            retVal.Add(new TouristicStatusComboItem("Exploited", 0));
            retVal.Add(new TouristicStatusComboItem("Available", 1));
            retVal.Add(new TouristicStatusComboItem("Unavailable", 2));
            return retVal;
        }
    }

    public class ErasComboItem
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public ErasComboItem(string Name, int Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

        public static ObservableCollection<ErasComboItem> initializeEraList()
        {
            var retVal = new ObservableCollection<ErasComboItem>();
            retVal.Add(new ErasComboItem("Paleolith", 0));
            retVal.Add(new ErasComboItem("Neolithic", 1));
            retVal.Add(new ErasComboItem("Ancient", 2));
            retVal.Add(new ErasComboItem("Medieval", 3));
            retVal.Add(new ErasComboItem("Renaissance", 4));
            retVal.Add(new ErasComboItem("Modern", 5));
            return retVal;
        }
    }
}
