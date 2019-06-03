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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Type = emlekmu.models.Type;
using static emlekmu.MainContent;
using static emlekmu.TypeSection;
using static emlekmu.MonumentsTable;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for MonumentRowDetail.xaml
    /// </summary>
    public partial class MonumentRowDetail : UserControl
    {



        public onRemoveMonument removeMonumentCallbackFun
        {
            get { return (onRemoveMonument)GetValue(removeMonumentCallbackFunProperty); }
            set { SetValue(removeMonumentCallbackFunProperty, value); }
        }

        // Using a DependencyProperty as the backing store for removeMonumentCallbackFun.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty removeMonumentCallbackFunProperty =
            DependencyProperty.Register("removeMonumentCallbackFun", typeof(onRemoveMonument), typeof(MonumentRowDetail), new PropertyMetadata(null));




        public onOpenEditMonument editMonumentCallbackFun
        {
            get { return (onOpenEditMonument)GetValue(editMonumentCallbackFunProperty); }
            set { SetValue(editMonumentCallbackFunProperty, value); }
        }

        // Using a DependencyProperty as the backing store for editMonumentCallbackFun.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty editMonumentCallbackFunProperty =
            DependencyProperty.Register("editMonumentCallbackFun", typeof(onOpenEditMonument), typeof(MonumentRowDetail), new PropertyMetadata(null));


        public onOpenMonumentDetail OpenMonumentDetailCallback
        {
            get { return (onOpenMonumentDetail)GetValue(OpenMonumentDetailCallbackProperty); }
            set { SetValue(OpenMonumentDetailCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenMonumentDetailCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenMonumentDetailCallbackProperty =
            DependencyProperty.Register("OpenMonumentDetailCallback", typeof(onOpenMonumentDetail), typeof(MonumentRowDetail), new PropertyMetadata(null));




        public ObservableCollection<int> EnlargenedMonuments
        {
            get { return (ObservableCollection<int>)GetValue(EnlargenedMonumentsProperty); }
            set { SetValue(EnlargenedMonumentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnlargenedMonuments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnlargenedMonumentsProperty =
            DependencyProperty.Register("EnlargenedMonuments", typeof(ObservableCollection<int>), typeof(MonumentRowDetail), new PropertyMetadata(new ObservableCollection<int>()));



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




        public onMonumentClicked MonumentClickedCallback
        {
            get { return (onMonumentClicked)GetValue(MonumentClickedCallbackProperty); }
            set { SetValue(MonumentClickedCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentClickedCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentClickedCallbackProperty =
            DependencyProperty.Register("MonumentClickedCallback", typeof(onMonumentClicked), typeof(MonumentRowDetail), new PropertyMetadata(null));



        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            MonumentClickedCallback(MonumentId);
        }

        public MonumentRowDetail()
        {
            InitializeComponent();
            Root.DataContext = this;
        }

        private void DeleteBtn_Click(object s, RoutedEventArgs ea)
        {
            MessageBoxResult result = MessageBox.Show("Delete Monument?", "delete", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.Cancel)
            {
                return;
            }
            DoubleAnimation animation = new DoubleAnimation();
            animation.To = 0;
            //animation.From = 1;
            animation.Duration = TimeSpan.FromMilliseconds(300);
            animation.EasingFunction = new QuadraticEase();

            Storyboard sb = new Storyboard();
            sb.Children.Add(animation);

            Root.Opacity = 1;
            Root.Visibility = Visibility.Visible;

            Storyboard.SetTarget(sb, Root);
            Storyboard.SetTargetProperty(sb, new PropertyPath(Control.OpacityProperty));

            sb.Completed += delegate (object sender, EventArgs e)
            {
                Root.Visibility = Visibility.Collapsed;
                this.removeMonumentCallbackFun(this.MonumentId);
            };
            sb.Begin();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            editMonumentCallbackFun(MonumentId);
        }

        private void onRigthClick(object sender, MouseButtonEventArgs e)
        {
            // open context menus

            ContextMenu cm = this.FindResource("cmMonumentRowDetail") as ContextMenu;
            cm.IsOpen = true;
            e.Handled = true;
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            OpenMonumentDetailCallback(MonumentId);
        }
    }
}
