using emlekmu.models;
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


        public void MouseClicked(object sender, MouseButtonEventArgs e)
        {
            this.Color = "#5577CC";
        }
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
    }
}
