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
using static emlekmu.TagSection;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for TagRowDetail.xaml
    /// </summary>
    public partial class TagRowDetail : UserControl
    {

        public ObservableCollection<string> EnlargenedTags
        {
            get { return (ObservableCollection<string>)GetValue(EnlargenedTagsProperty); }
            set { SetValue(EnlargenedTagsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnlargenedTags.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnlargenedTagsProperty =
            DependencyProperty.Register("EnlargenedTags", typeof(ObservableCollection<string>), typeof(TagRowDetail), new PropertyMetadata(new ObservableCollection<string>()));




        public string Id
        {
            get { return (string)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(string), typeof(TagRowDetail), new PropertyMetadata(""));



        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(TagRowDetail), new PropertyMetadata(""));




        public string Color
        {
            get { return (string)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(string), typeof(TagRowDetail), new PropertyMetadata("#000000"));




        public onTagClicked TagClickedCallback
        {
            get { return (onTagClicked)GetValue(TagClickedCallbackProperty); }
            set { SetValue(TagClickedCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TagClickedCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagClickedCallbackProperty =
            DependencyProperty.Register("TagClickedCallback", typeof(onTagClicked), typeof(TagRowDetail), new PropertyMetadata(null));



        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            TagClickedCallback(Id);
        }


        public TagRowDetail()
        {
            InitializeComponent();
            Root.DataContext = this;
        }
    }
}
