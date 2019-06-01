using emlekmu.models;
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

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for MonumentPin.xaml
    /// </summary>
    public partial class MonumentPin : UserControl
    {



        public Monument MyMonument
        {
            get { return (Monument)GetValue(MyMonumentProperty); }
            set { SetValue(MyMonumentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyMonument.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyMonumentProperty =
            DependencyProperty.Register("MyMonument", typeof(Monument), typeof(MonumentPin), new PropertyMetadata(null));



        public void MouseClicked(object sender, MouseButtonEventArgs e)
        {
            Ellipsey.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb((byte)100, (byte)150, (byte)200));
        }
        public MonumentPin()
        {
            InitializeComponent();
        }
    }
}
