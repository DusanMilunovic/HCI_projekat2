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

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for TagSection.xaml
    /// </summary>
    /// 

    public partial class TagSection : UserControl, INotifyPropertyChanged
    {

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public delegate void onTagClicked(string id);
        public onTagClicked tagClickedCallback;
        public onTagClicked TagClickedCallback {
            get
            {
                return tagClickedCallback;
            }
            set
            {
                if (value != tagClickedCallback)
                {
                    tagClickedCallback = value;
                    OnPropertyChanged("TagClickedCallback");
                }
            }
        }

        public delegate void updateTag();
        public event updateTag updateTagEvent;


        public TagSection()
        {
            InitializeComponent();
            EnlargenedTags = new ObservableCollection<string>();
            Root.DataContext = this;
            TagClickedCallback = new onTagClicked(tagClicked);

        }

        ObservableCollection<string> enlargenedTags;
        public ObservableCollection<string> EnlargenedTags
        {
            get
            {
                return enlargenedTags;
            }
            set
            {
                if (value != enlargenedTags)
                {
                    enlargenedTags = value;
                    OnPropertyChanged("EnlargenedTags");
                }
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public void tagClicked(string id)
        {
            TagRow myTagUC = null;
            TagRowDetail myTagDUC = null;
            foreach (TagRow tb in FindVisualChildren<TagRow>(RootWoot))
            {
                tb.Visibility = Visibility.Visible;
                if (tb.Tag.ToString().Equals(id))
                    myTagUC = tb;
                else
                    this.EnlargenedTags.Remove(tb.Id);
            }
            foreach (TagRowDetail tb in FindVisualChildren<TagRowDetail>(RootWoot))
            {
                tb.Visibility = Visibility.Collapsed;
                if (tb.Tag.ToString().Equals(id))
                    myTagDUC = tb;
                else
                    this.EnlargenedTags.Remove(tb.Id);
            }

            if (this.EnlargenedTags.IndexOf(id) == -1)
            {
                myTagUC.Visibility = Visibility.Collapsed;
                myTagDUC.Visibility = Visibility.Visible;
                this.EnlargenedTags.Add(id);
            }
            else
            {
                myTagDUC.Visibility = Visibility.Collapsed;
                myTagUC.Visibility = Visibility.Visible;
                this.EnlargenedTags.Remove(id);
            }
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

        private void TagRow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
