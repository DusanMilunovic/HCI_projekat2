using emlekmu.copy_service;
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
using static emlekmu.MainContent;
using static emlekmu.MonumentsTable;
using Type = emlekmu.models.Type;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for MonumentRow.xaml
    /// </summary>
    public partial class MonumentRow : UserControl
    {



        public string BorderColor
        {
            get { return (string)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.Register("BorderColor", typeof(string), typeof(MonumentRow), new PropertyMetadata("#006699"));


        public ObservableCollection<int> EnlargenedMonuments
        {
            get { return (ObservableCollection<int>)GetValue(EnlargenedMonumentsProperty); }
            set { SetValue(EnlargenedMonumentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnlargenedMonuments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnlargenedMonumentsProperty =
            DependencyProperty.Register("EnlargenedMonuments", typeof(ObservableCollection<int>), typeof(MonumentRow), new PropertyMetadata(new ObservableCollection<int>()));

    
        public int MonumentId
        {
            get { return (int)GetValue(MonumentIdProperty); }
            set { SetValue(MonumentIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentIdProperty =
            DependencyProperty.Register("MonumentId", typeof(int), typeof(MonumentRow), new PropertyMetadata(0));



        public string MonumentName
        {
            get { return (string)GetValue(MonumentNameProperty); }
            set { SetValue(MonumentNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentNameProperty =
            DependencyProperty.Register("MonumentName", typeof(string), typeof(MonumentRow), new PropertyMetadata(""));



        public Type MonumentType
        {
            get { return (Type)GetValue(MonumentTypeProperty); }
            set { SetValue(MonumentTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentTypeProperty =
            DependencyProperty.Register("MonumentType", typeof(Type), typeof(MonumentRow), new PropertyMetadata(null));





        public ObservableCollection<Tag> MonumentTags
        {
            get { return (ObservableCollection<Tag>)GetValue(MonumentTagsProperty); }
            set { SetValue(MonumentTagsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentTags.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentTagsProperty =
            DependencyProperty.Register("MonumentTags", typeof(ObservableCollection<Tag>), typeof(MonumentRow), new PropertyMetadata(new ObservableCollection<Tag>()));






        public string MonumentImage
        {
            get { return (string)GetValue(MonumentImageProperty); }
            set { SetValue(MonumentImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentImageProperty =
            DependencyProperty.Register("MonumentImage", typeof(string), typeof(MonumentRow), new PropertyMetadata(""));

        
        public onMonumentClicked MonumentClickedCallback
        {
            get { return (onMonumentClicked)GetValue(MonumentClickedCallbackProperty); }
            set { SetValue(MonumentClickedCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentClickedCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentClickedCallbackProperty =
            DependencyProperty.Register("MonumentClickedCallback", typeof(onMonumentClicked), typeof(MonumentRow), new PropertyMetadata(null));




        public onOpenEditMonument EditMonumentCallback
        {
            get { return (onOpenEditMonument)GetValue(EditMonumentCallbackProperty); }
            set { SetValue(EditMonumentCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditMonumentCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditMonumentCallbackProperty =
            DependencyProperty.Register("EditMonumentCallback", typeof(onOpenEditMonument), typeof(MonumentRow), new PropertyMetadata(null));


        public onOpenMonumentDetail OpenMonumentDetailCallback
        {
            get { return (onOpenMonumentDetail)GetValue(OpenMonumentDetailCallbackProperty); }
            set { SetValue(OpenMonumentDetailCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenMonumentDetailsCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenMonumentDetailCallbackProperty =
            DependencyProperty.Register("OpenMonumentDetailCallback", typeof(onOpenMonumentDetail), typeof(MonumentRow), new PropertyMetadata(null));


        public onRemoveMonument RemoveMonumentCallback
        {
            get { return (onRemoveMonument)GetValue(RemoveMonumentCallbackProperty); }
            set { SetValue(RemoveMonumentCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemoveMonumentCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemoveMonumentCallbackProperty =
            DependencyProperty.Register("RemoveMonumentCallback", typeof(onRemoveMonument), typeof(MonumentRow), new PropertyMetadata(null));




        public int BorderThiccness
        {
            get { return (int)GetValue(BorderThiccnessProperty); }
            set { SetValue(BorderThiccnessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderThiccness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderThiccnessProperty =
            DependencyProperty.Register("BorderThiccness", typeof(int), typeof(MonumentRow), new PropertyMetadata(2));




        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            MonumentClickedCallback(MonumentId);
        }

        private void onRigthClick(object sender, MouseButtonEventArgs e)
        {
            // open context menus

            ContextMenu cm = this.FindResource("cmMonumentRow") as ContextMenu;
            cm.IsOpen = true;
            e.Handled = true;
        }

        private void editMenuAction(object sender, RoutedEventArgs e)
        {
            Monument m = EditMonumentCallback(MonumentId);
            if (m != null)
            {
                MonumentClickedCallback(m.Id);
            }
        }

        private void deleteMenuAction(object s, RoutedEventArgs ea)
        {
            AreYouSure ars = new AreYouSure("Are you sure you want to delete this monument?");
            ars.Owner = Application.Current.MainWindow;
            ars.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ars.ShowDialog();

            if (ars.DialogResult.HasValue && !ars.DialogResult.Value)
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
                RemoveMonumentCallback(MonumentId);
            };
            sb.Begin();
        }

        public MonumentRow()
        {
            InitializeComponent();
            Root.DataContext = this;
        }
        private void copyMenuAction(object s, RoutedEventArgs ea)
        {
            CopyService cs = CopyService.Instance;
            cs.Copied = ((MainWindow)Application.Current.MainWindow).MainContent.findMonumentCallback(MonumentId);
        }
        public void DetailsAction(object sender, RoutedEventArgs e)
        {
            OpenMonumentDetailCallback(MonumentId);
        }
    }
}
