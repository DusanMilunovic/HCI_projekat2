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
using static emlekmu.TypeSection;
using Type = emlekmu.models.Type;


namespace emlekmu
{
    /// <summary>
    /// Interaction logic for TypeRow.xaml
    /// </summary>

    public partial class TypeRow : UserControl
    {

        public ObservableCollection<int> EnlargenedTypes
        {
            get { return (ObservableCollection<int>)GetValue(EnlargenedTagsProperty); }
            set { SetValue(EnlargenedTagsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnlargenedTags.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnlargenedTagsProperty =
            DependencyProperty.Register("EnlargenedTypes", typeof(ObservableCollection<int>), typeof(TypeRow), new PropertyMetadata(new ObservableCollection<int>()));



        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(TypeRow), new PropertyMetadata(0));





        public string TypeName
        {
            get { return (string)GetValue(TypeNameProperty); }
            set { SetValue(TypeNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TypeName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeNameProperty =
            DependencyProperty.Register("TypeName", typeof(string), typeof(TypeRow), new PropertyMetadata(""));





        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Descripton.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(TypeRow), new PropertyMetadata(""));



        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(TypeRow), new PropertyMetadata(""));


        public onTypeClicked TypeClickedCallback
        {
            get { return (onTypeClicked)GetValue(TagClickedCallbackProperty); }
            set { SetValue(TagClickedCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TagClickedCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagClickedCallbackProperty =
            DependencyProperty.Register("TypeClickedCallback", typeof(onTypeClicked), typeof(TypeRow), new PropertyMetadata(null));

        // Edit type function DependencyProperty


        public onEditType EditTypeCallback
        {
            get { return (onEditType)GetValue(EditTypeCallbackProperty); }
            set { SetValue(EditTypeCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditTypeCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditTypeCallbackProperty =
            DependencyProperty.Register("EditTypeCallback", typeof(onEditType), typeof(TypeRow), new PropertyMetadata(null));





        public onRemoveType RemoveTypeCallback
        {
            get { return (onRemoveType)GetValue(RemoveTypeCallbackProperty); }
            set { SetValue(RemoveTypeCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemoveTypeCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemoveTypeCallbackProperty =
            DependencyProperty.Register("RemoveTypeCallback", typeof(onRemoveType), typeof(TypeRow), new PropertyMetadata(null));




        private void onRigthClick(object sender, MouseButtonEventArgs e)
        {
            // open context menu
            ContextMenu cm = this.FindResource("cmTypeRow") as ContextMenu;
            cm.IsOpen = true;
        }

        private void editMenuAction(object sender, RoutedEventArgs e)
        {
            EditType editTypeDialog = new EditType(new Type(Id, TypeName, Icon, Description), EditTypeCallback);
            editTypeDialog.Height = 600;
            editTypeDialog.Width = 400;
            editTypeDialog.ShowDialog();
        }

        private void deleteMenuAction(object s, RoutedEventArgs ea)
        {
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
                this.RemoveTypeCallback(this.Id);
            };
            sb.Begin();
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            TypeClickedCallback(Id);
        }
        public TypeRow()
        {
            InitializeComponent();
            Root.DataContext = this;
        }
    }
}
