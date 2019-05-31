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
using static emlekmu.TagSection;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for TagRow.xaml
    /// </summary>
    public partial class TagRow : UserControl
    {


        public ObservableCollection<string> EnlargenedTags
        {
            get { return (ObservableCollection<string>)GetValue(EnlargenedTagsProperty); }
            set { SetValue(EnlargenedTagsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnlargenedTags.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnlargenedTagsProperty =
            DependencyProperty.Register("EnlargenedTags", typeof(ObservableCollection<string>), typeof(TagRow), new PropertyMetadata(new ObservableCollection<string>()));



        public string Id
        {
            get { return (string)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(string), typeof(TagRow), new PropertyMetadata(""));





        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(TagRow), new PropertyMetadata(""));




        public models.Color Color
        {
            get { return (models.Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(models.Color), typeof(TagRow), new PropertyMetadata(new models.Color(0,0,0)));


        public onTagClicked TagClickedCallback
        {
            get { return (onTagClicked)GetValue(TagClickedCallbackProperty); }
            set { SetValue(TagClickedCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TagClickedCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagClickedCallbackProperty =
            DependencyProperty.Register("TagClickedCallback", typeof(onTagClicked), typeof(TagRow), new PropertyMetadata(null));





        public onEditTag EditTagCallback
        {
            get { return (onEditTag)GetValue(EditTagCallbackProperty); }
            set { SetValue(EditTagCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditTagCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditTagCallbackProperty =
            DependencyProperty.Register("EditTagCallback", typeof(onEditTag), typeof(TagRow), new PropertyMetadata(null));




        public onRemoveTag RemoveTagCallback
        {
            get { return (onRemoveTag)GetValue(RemoveTagCallbackProperty); }
            set { SetValue(RemoveTagCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemoveTagCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemoveTagCallbackProperty =
            DependencyProperty.Register("RemoveTagCallback", typeof(onRemoveTag), typeof(TagRow), new PropertyMetadata(null));






        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            TagClickedCallback(Id);
        }

        public TagRow()
        {
            InitializeComponent();
            Root.DataContext = this;
        }

        private void onRigthClick(object sender, MouseButtonEventArgs e)
        {
            // open context menu
            ContextMenu cm = this.FindResource("cmTagRow") as ContextMenu;
            cm.IsOpen = true;
        }

        private void EditAction_Click(object sender, RoutedEventArgs e)
        {
            EditTag editTagDialog = new EditTag(new Tag(Id, Color, Description), EditTagCallback);
            editTagDialog.Height = 600;
            editTagDialog.Width = 400;
            editTagDialog.ShowDialog();
        }

        private void DeleteAction_Click(object s, RoutedEventArgs ea)
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
                this.RemoveTagCallback(this.Id);
            };
            sb.Begin();
        }

    }
}
