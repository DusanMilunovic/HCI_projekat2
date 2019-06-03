using emlekmu.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DeleteTagDialog.xaml
    /// </summary>
    public partial class DeleteTagDialog : Window
    {


        public ObservableCollection<Monument> Monuments
        {
            get { return (ObservableCollection<Monument>)GetValue(MonumentsProperty); }
            set { SetValue(MonumentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Monuments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentsProperty =
            DependencyProperty.Register("Monuments", typeof(ObservableCollection<Monument>), typeof(DeleteTagDialog), new PropertyMetadata(new ObservableCollection<Monument>()));



        public DeleteTagDialog()
        {
            InitializeComponent();
        }

        public DeleteTagDialog(ObservableCollection<Monument> monuments)
        {
            InitializeComponent();
            Root.DataContext = this;
            Monuments = monuments;
        }

        private void RemoveTags_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
