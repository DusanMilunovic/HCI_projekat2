using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
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
using emlekmu.models;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for DeleteTypeDialog.xaml
    /// </summary>
    public partial class DeleteTypeDialog : Window
    {



        public ObservableCollection<Monument> Monuments
        {
            get { return (ObservableCollection<Monument>)GetValue(MonumentsProperty); }
            set { SetValue(MonumentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Monuments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentsProperty =
            DependencyProperty.Register("Monuments", typeof(ObservableCollection<Monument>), typeof(DeleteTypeDialog), new PropertyMetadata(new ObservableCollection<Monument>()));


        public DeleteTypeDialog()
        {
            InitializeComponent();
        }

        public DeleteTypeDialog(ObservableCollection<Monument> monuments)
        {
            InitializeComponent();
        Root.DataContext = this;
            Monuments = monuments;
        }

        private void DeleteMonuments_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
