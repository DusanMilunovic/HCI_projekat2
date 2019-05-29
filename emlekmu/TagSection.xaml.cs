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
    /// Interaction logic for TagSection.xaml
    /// </summary>
    /// 

    public partial class TagSection : UserControl
    {
        public TagSection()
        {
            InitializeComponent();
            Root.DataContext = this;

        }
        
        public ObservableCollection<Tag> Tags
        {
            get { return (ObservableCollection<Tag>)GetValue(TagsProperty); }
            set { SetValue(TagsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tags.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagsProperty =
            DependencyProperty.Register("Tags", typeof(ObservableCollection<Tag>), typeof(TagSection), new PropertyMetadata(new ObservableCollection<Tag>()));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.Write("aha");
        }
    }
}
