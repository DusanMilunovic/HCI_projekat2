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
using static emlekmu.TypeSection;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for TypeRowDetail.xaml
    /// </summary>
    public partial class TypeRowDetail : UserControl
    {


        public onRemoveType removeTypeCallbackFun
        {
            get { return (onRemoveType)GetValue(removeTypeCallbackFunProperty); }
            set { SetValue(removeTypeCallbackFunProperty, value); }
        }

        // Using a DependencyProperty as the backing store for removeTypeCallbackFun.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty removeTypeCallbackFunProperty =
            DependencyProperty.Register("removeTypeCallbackFun", typeof(onRemoveType), typeof(TypeRowDetail), new PropertyMetadata(null));





        public onEditType editTypeCallbackFun
        {
            get { return (onEditType)GetValue(editTypeCallbackFunProperty); }
            set { SetValue(editTypeCallbackFunProperty, value); }
        }

        // Using a DependencyProperty as the backing store for editTypeCallbackFun.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty editTypeCallbackFunProperty =
            DependencyProperty.Register("editTypeCallbackFun", typeof(onEditType), typeof(TypeRowDetail), new PropertyMetadata(null));
        
        public ObservableCollection<int> EnlargenedTypes
        {
            get { return (ObservableCollection<int>)GetValue(EnlargenedTagsProperty); }
            set { SetValue(EnlargenedTagsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnlargenedTags.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnlargenedTagsProperty =
            DependencyProperty.Register("EnlargenedTypes", typeof(ObservableCollection<int>), typeof(TypeRowDetail), new PropertyMetadata(new ObservableCollection<int>()));



        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(TypeRowDetail), new PropertyMetadata(0));





        public string TypeName
        {
            get { return (string)GetValue(TypeNameProperty); }
            set { SetValue(TypeNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TypeName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeNameProperty =
            DependencyProperty.Register("TypeName", typeof(string), typeof(TypeRowDetail), new PropertyMetadata(""));





        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Descripton.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(TypeRowDetail), new PropertyMetadata(""));



        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(TypeRowDetail), new PropertyMetadata(""));


        public onTypeClicked TypeClickedCallback
        {
            get { return (onTypeClicked)GetValue(TagClickedCallbackProperty); }
            set { SetValue(TagClickedCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TagClickedCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagClickedCallbackProperty =
            DependencyProperty.Register("TypeClickedCallback", typeof(onTypeClicked), typeof(TypeRowDetail), new PropertyMetadata(null));



        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            TypeClickedCallback(Id);
        }
        public TypeRowDetail()
        {
            InitializeComponent();
            Root.DataContext = this;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var obj = new models.Type(this.Id, this.TypeName, this.Icon, this.Description);
            EditType editTypeDialog = new emlekmu.EditType(obj, this.editTypeCallbackFun);

            editTypeDialog.Height = 590;
            editTypeDialog.Width = 450;
            editTypeDialog.Owner = Application.Current.MainWindow;
            editTypeDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            editTypeDialog.ShowDialog();
        }

        
        private void DeleteBtn_Click(object s, RoutedEventArgs ea)
        {
            MainContent mc = ((MainWindow)Application.Current.MainWindow).MainContent;

            List<Monument> conflicting = mc.typeConflictingMonuments(Id);
            if (conflicting == null)
            {

                AreYouSure ars = new AreYouSure("Are you sure you want to delete this type?");
                ars.Owner = Application.Current.MainWindow;
                ars.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                ars.ShowDialog();

                if (ars.DialogResult.HasValue && !ars.DialogResult.Value)
                {
                    return;
                }
            }
            else
            {

                DeleteTypeDialog dtDialog = new DeleteTypeDialog(new ObservableCollection<Monument>(conflicting));

                dtDialog.Owner = Application.Current.MainWindow;
                dtDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                dtDialog.ShowDialog();
                if (dtDialog.DialogResult.HasValue && dtDialog.DialogResult.Value)
                {
                    mc.removeTypeAndMonuments(Id);
                }
                else
                {
                    return;
                }
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
                this.removeTypeCallbackFun(this.Id);
            };
            sb.Begin();

        }
        private void onRigthClick(object sender, MouseButtonEventArgs e)
        {
            // open context menu
            ContextMenu cm = this.FindResource("cmTypeRowDetail") as ContextMenu;
            cm.IsOpen = true;
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }

    


}
