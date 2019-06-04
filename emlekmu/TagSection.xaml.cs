using emlekmu.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using static emlekmu.MainContent;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for TagSection.xaml
    /// </summary>
    /// 
    

    public partial class TagSection : Window, INotifyPropertyChanged
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

        public ObservableCollection<Tag> Tags
        {
            get { return (ObservableCollection<Tag>)GetValue(TagsProperty); }
            set { SetValue(TagsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tags.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagsProperty =
            DependencyProperty.Register("Tags", typeof(ObservableCollection<Tag>), typeof(TagSection), new PropertyMetadata(new ObservableCollection<Tag>()));





        public onAddTag AddTagCallback
        {
            get { return (onAddTag)GetValue(AddTagCallbackProperty); }
            set { SetValue(AddTagCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddTagCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddTagCallbackProperty =
            DependencyProperty.Register("AddTagCallback", typeof(onAddTag), typeof(TagSection), new PropertyMetadata(null));




        public onEditTag EditTagCallback
        {
            get { return (onEditTag)GetValue(EditTagCallbackProperty); }
            set { SetValue(EditTagCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditTagCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditTagCallbackProperty =
            DependencyProperty.Register("EditTagCallback", typeof(onEditTag), typeof(TagSection), new PropertyMetadata(null));




        public onRemoveTag RemoveTagCallback
        {
            get { return (onRemoveTag)GetValue(RemoveTagCallbackProperty); }
            set { SetValue(RemoveTagCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemoveTagCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemoveTagCallbackProperty =
            DependencyProperty.Register("RemoveTagCallback", typeof(onRemoveTag), typeof(TagSection), new PropertyMetadata(null));





        public TagSection()
        {
            InitializeComponent();
            EnlargenedTags = new ObservableCollection<string>();
            Root.DataContext = this;
            TagClickedCallback = new onTagClicked(tagClicked);

        }

        public TagSection(ObservableCollection<Tag> tags, onAddTag addTagCallback, onEditTag editTagCallback, onRemoveTag removeTagCallback)
        {
            InitializeComponent();
            EnlargenedTags = new ObservableCollection<string>();
            Root.DataContext = this;
            TagClickedCallback = new onTagClicked(tagClicked);
            Tags = tags;
            AddTagCallback = addTagCallback;
            EditTagCallback = editTagCallback;
            RemoveTagCallback = removeTagCallback;

            TextCompositionManager.AddTextInputHandler(this,
                new TextCompositionEventHandler(OnTextComposition));

        }

        private void OnTextComposition(object sender, TextCompositionEventArgs e)
        {
            MainContent content = ((MainWindow)Application.Current.MainWindow).MainContent;
            if (content.DemonAlive)
            {
                content.Demon.Abort();
                content.DemonAlive = false;
            }
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
        

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.Write("aha");
        }

        private void TagRow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddTagButton_Click(object sender, RoutedEventArgs e)
        {
            AddTag addTagDialog = new emlekmu.AddTag(AddTagCallback, Tags);
            addTagDialog.Owner = Application.Current.MainWindow;
            addTagDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addTagDialog.Height = 490;
            addTagDialog.Width = 350;
            addTagDialog.MinHeight = 420;
            addTagDialog.MinWidth = 280;

            addTagDialog.ShowDialog();

            if (addTagDialog.DialogResult.HasValue && addTagDialog.DialogResult.Value)
            {
                this.Scroller.ScrollToBottom();
                this.UpdateLayout();
                this.tagClicked(addTagDialog.NewTag.Id);
            }

        }

     
        private void onRigthClick(object sender, MouseButtonEventArgs e)
        {
            // open context menu
            if (((UIElement)sender).IsMouseDirectlyOver)
            {
                ContextMenu cm = this.FindResource("cmTagSection") as ContextMenu;
                cm.IsOpen = true;
            }
        }

        public void CloseAction_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void EditTagCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.EnlargenedTags.Count > 0;
        }

        private void EditTagCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string toEdit = EnlargenedTags.First();
            Tag t = this.Tags.SingleOrDefault(x => x.Id == toEdit);
            EditTag dialog = new EditTag(t, this.EditTagCallback);
            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.Height = 490;
            dialog.Width = 350;
            dialog.MinHeight = 420;
            dialog.MinWidth = 280;
            dialog.ShowDialog();
        }

        private void AddTagCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AddTagCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddTag dialog = new AddTag(this.AddTagCallback, this.Tags);
            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.Height = 490;
            dialog.Width = 350;
            dialog.MinHeight = 420;
            dialog.MinWidth = 280;
            dialog.ShowDialog();
        }

        private void DeleteTagCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

            e.CanExecute = this.EnlargenedTags.Count > 0;
        }

        private void DeleteTagCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string toRemove = this.EnlargenedTags.First();

            MainContent mc = ((MainWindow)Application.Current.MainWindow).MainContent;

            List<Monument> conflicting = mc.tagConflictingMonuments(toRemove);
            if (conflicting == null)
            {

                AreYouSure ars = new AreYouSure("Are you sure you want to delete this tag?");
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

                DeleteTagDialog dtDialog = new DeleteTagDialog(new ObservableCollection<Monument>(conflicting));

                dtDialog.Owner = Application.Current.MainWindow;
                dtDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                dtDialog.ShowDialog();
                if (dtDialog.DialogResult.HasValue && dtDialog.DialogResult.Value)
                {
                    mc.removeTagFromMonuments(toRemove);
                }
                else
                {
                    return;
                }
            }

            Tag t = this.Tags.SingleOrDefault(x => x.Id == toRemove);
            this.RemoveTagCallback(toRemove);
            this.EnlargenedTags.Remove(toRemove);
        }
    }
}
