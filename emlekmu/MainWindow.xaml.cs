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
using emlekmu.models.IO;


namespace emlekmu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddMonumentCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AddMonumentCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddMonument dialog = new AddMonument(MainContent.Monuments, MainContent.Types, MainContent.Tags,
                MainContent.addMonumentCallback, MainContent.addTypeCallback, MainContent.addTagCallback);
            dialog.Height = 900;
            dialog.Width = 400;
            dialog.Show();
        }

        private void AddTypeCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AddTypeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddType dialog = new AddType(MainContent.addTypeCallback, MainContent.Types);
            dialog.Height = 400;
            dialog.Width = 400;
            dialog.Show();
        }

        private void AddTagCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AddTagCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddTag dialog = new emlekmu.AddTag(MainContent.addTagCallback, MainContent.Tags);
            dialog.Height = 400;
            dialog.Width = 400;
            dialog.Show();
        }
    }
}
