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

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for AddType.xaml
    /// </summary>
    public partial class AddType : UserControl, INotifyPropertyChanged
    {
        

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string iconText;

        public string IconText
        {
            get
            {
                return iconText;
            }
            set
            {
                if (value != iconText)
                {
                    iconText = value;
                    OnPropertyChanged("IconText");
                }
            }
        }

        public AddType()
        {
            InitializeComponent();
            Root.DataContext = this;
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
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
                this.IconText = dlg.FileName;
            }
        }
    }
}
