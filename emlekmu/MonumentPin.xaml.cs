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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static emlekmu.MainContent;
using static emlekmu.Map;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for MonumentPin.xaml
    /// </summary>
    public partial class MonumentPin : UserControl, INotifyPropertyChanged
    {

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;


        public string color;

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                if (value != color)
                {
                    color = value;
                    OnPropertyChanged("Color");
                }
            }
        }

        public Monument MyMonument
        {
            get { return (Monument)GetValue(MyMonumentProperty); }
            set { SetValue(MyMonumentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyMonument.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyMonumentProperty =
            DependencyProperty.Register("MyMonument", typeof(Monument), typeof(MonumentPin), new PropertyMetadata(null));






        public onOpenEditMonument OpenEditMonumentCallback
        {
            get { return (onOpenEditMonument)GetValue(OpenEditMonumentCallbackProperty); }
            set { SetValue(OpenEditMonumentCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenEditMonumentDialogCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenEditMonumentCallbackProperty =
            DependencyProperty.Register("OpenEditMonumentCallback", typeof(onOpenEditMonument), typeof(MonumentPin), new PropertyMetadata(null));




        public onRemoveMonument RemoveMonumentCallback
        {
            get { return (onRemoveMonument)GetValue(RemoveMonumentCallbackProperty); }
            set { SetValue(RemoveMonumentCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemoveMonumentCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemoveMonumentCallbackProperty =
            DependencyProperty.Register("RemoveMonumentCallback", typeof(onRemoveMonument), typeof(MonumentPin), new PropertyMetadata(null));

        public onPinClicked PinClickedCallback
        {
            get { return (onPinClicked)GetValue(PinClickedCallbackProperty); }
            set { SetValue(PinClickedCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PinClickedCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PinClickedCallbackProperty =
            DependencyProperty.Register("PinClickedCallback", typeof(onPinClicked), typeof(MonumentPin), new PropertyMetadata(null));



        public ObservableCollection<int> EnlargenedMonuments
        {
            get { return (ObservableCollection<int>)GetValue(EnlargenedMonumentsProperty); }
            set { SetValue(EnlargenedMonumentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnlargenedMonuments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnlargenedMonumentsProperty =
            DependencyProperty.Register("EnlargenedMonuments", typeof(ObservableCollection<int>), typeof(MonumentPin), new PropertyMetadata(new ObservableCollection<int>()));




        public onRemovePin RemovePinCallback
        {
            get { return (onRemovePin)GetValue(RemovePinCallbackProperty); }
            set { SetValue(RemovePinCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemovePinCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemovePinCallbackProperty =
            DependencyProperty.Register("RemovePinCallback", typeof(onRemovePin), typeof(MonumentPin), new PropertyMetadata(null));




        public MonumentPin()
        {
            InitializeComponent();
            Root.DataContext = this;
            this.Color = "#FFFFFF";
        }

        private void onRightClick(object sender, MouseButtonEventArgs e)
        {
            // open context menu
            ContextMenu cm = this.FindResource("cmMonumentPin") as ContextMenu;
            cm.IsOpen = true;
            e.Handled = true;
        }

        private void EditAction(object sender, RoutedEventArgs e)
        {
            OpenEditMonumentCallback(MyMonument);

        }

        private void DeleteAction(object sender, RoutedEventArgs e)
        {
            RemoveMonumentCallback(MyMonument.Id);
        }

        private void onLeftClick(object sender, MouseButtonEventArgs e)
        {
            PinClickedCallback(MyMonument.Id);
        }

        public void UpdateColor(object sender, MouseButtonEventArgs e)
        {
            if (!(this.EnlargenedMonuments.IndexOf(this.MyMonument.Id) == -1))
            {
                Selected.Visibility = Visibility.Visible;
                NotSelected.Visibility = Visibility.Collapsed;
            }
            else
            {
                Selected.Visibility = Visibility.Collapsed;
                NotSelected.Visibility = Visibility.Visible;
            }
        }

        public void RemoveFromMapAction(object sender, RoutedEventArgs e)
        {
            RemovePinCallback(MyMonument);
        }
    }
}
