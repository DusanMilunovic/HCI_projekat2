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
using Type = emlekmu.models.Type;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for MonumentRowDetail.xaml
    /// </summary>
    public partial class MonumentRowDetail : UserControl
    {
        public int MonumentId
        {
            get { return (int)GetValue(MonumentIdProperty); }
            set { SetValue(MonumentIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentIdProperty =
            DependencyProperty.Register("MonumentId", typeof(int), typeof(MonumentRowDetail), new PropertyMetadata(0));



        public string MonumentName
        {
            get { return (string)GetValue(MonumentNameProperty); }
            set { SetValue(MonumentNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentNameProperty =
            DependencyProperty.Register("MonumentName", typeof(string), typeof(MonumentRowDetail), new PropertyMetadata(""));



        public Type MonumentType
        {
            get { return (Type)GetValue(MonumentTypeProperty); }
            set { SetValue(MonumentTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentTypeProperty =
            DependencyProperty.Register("MonumentType", typeof(Type), typeof(MonumentRowDetail), new PropertyMetadata(null));





        public ObservableCollection<Tag> MonumentTags
        {
            get { return (ObservableCollection<Tag>)GetValue(MonumentTagsProperty); }
            set { SetValue(MonumentTagsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentTags.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentTagsProperty =
            DependencyProperty.Register("MonumentTags", typeof(ObservableCollection<Tag>), typeof(MonumentRowDetail), new PropertyMetadata(new ObservableCollection<Tag>()));




        public string MonumentDescription
        {
            get { return (string)GetValue(MonumentDescriptionProperty); }
            set { SetValue(MonumentDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentDescription.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentDescriptionProperty =
            DependencyProperty.Register("MonumentDescription", typeof(string), typeof(MonumentRowDetail), new PropertyMetadata(""));





        public string MonumentImage
        {
            get { return (string)GetValue(MonumentImageProperty); }
            set { SetValue(MonumentImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentImageProperty =
            DependencyProperty.Register("MonumentImage", typeof(string), typeof(MonumentRowDetail), new PropertyMetadata(""));

        public MonumentRowDetail()
        {
            InitializeComponent();
            Root.DataContext = this;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
