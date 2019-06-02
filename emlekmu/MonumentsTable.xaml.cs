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
using static emlekmu.MainContent;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for MonumentsTable.xaml
    /// </summary>
    public partial class MonumentsTable : UserControl, INotifyPropertyChanged
    {


        public onRemoveMonument RemoveMonumentCallback
        {
            get { return (onRemoveMonument)GetValue(RemoveMonumentCallbackProperty); }
            set { SetValue(RemoveMonumentCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemoveMonumentCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemoveMonumentCallbackProperty =
            DependencyProperty.Register("RemoveMonumentCallback", typeof(onRemoveMonument), typeof(MonumentsTable), new PropertyMetadata(null));




        public onEditMonument EditMonumentCallback
        {
            get { return (onEditMonument)GetValue(EditMonumentCallbackProperty); }
            set { SetValue(EditMonumentCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditMonumentCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditMonumentCallbackProperty =
            DependencyProperty.Register("EditMonumentCallback", typeof(onEditMonument), typeof(MonumentsTable), new PropertyMetadata(null));




        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public delegate void onMonumentClicked(int id);
        public onMonumentClicked monumentClickedCallback;
        public onMonumentClicked MonumentClickedCallback
        {
            get
            {
                return monumentClickedCallback;
            }
            set
            {
                if (value != monumentClickedCallback)
                {
                    monumentClickedCallback = value;
                    OnPropertyChanged("MonumentClickedCallback");
                }
            }
        }




        public ObservableCollection<Monument> SearchedMonuments
        {
            get { return (ObservableCollection<Monument>)GetValue(SearchedMonumentsProperty); }
            set { SetValue(SearchedMonumentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SearchedMonuments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchedMonumentsProperty =
            DependencyProperty.Register("SearchedMonuments", typeof(ObservableCollection<Monument>), typeof(MonumentsTable), new PropertyMetadata(new ObservableCollection<Monument>()));



        public ObservableCollection<Monument> AllMonuments
        {
            get { return (ObservableCollection<Monument>)GetValue(AllMonumentsProperty); }
            set { SetValue(AllMonumentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AllMonuments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllMonumentsProperty =
            DependencyProperty.Register("AllMonuments", typeof(ObservableCollection<Monument>), typeof(MonumentsTable), new PropertyMetadata(new ObservableCollection<Monument>()));




        public ObservableCollection<Monument> FilteredMonuments
        {
            get { return (ObservableCollection<Monument>)GetValue(FilteredMonumentsProperty); }
            set { SetValue(FilteredMonumentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilteredMonuments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilteredMonumentsProperty =
            DependencyProperty.Register("FilteredMonuments", typeof(ObservableCollection<Monument>), typeof(MonumentsTable), new PropertyMetadata(new ObservableCollection<Monument>()));


        public ObservableCollection<Monument> Monuments
        {
            get { return (ObservableCollection<Monument>)GetValue(MonumentsProperty); }
            set { SetValue(MonumentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Monuments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentsProperty =
            DependencyProperty.Register("Monuments", typeof(ObservableCollection<Monument>), typeof(MonumentsTable), new PropertyMetadata(new ObservableCollection<Monument>()));



        public MonumentsTable()
        {
            InitializeComponent();
            EnlargenedMonuments = new ObservableCollection<int>();
            Root.DataContext = this;
            RootWoot.DataContext = this;
            MonumentClickedCallback = new onMonumentClicked(monumentClicked);
        }

        private void AddMonumentButton_Click(object sender, RoutedEventArgs e)
        {
            Console.Write("KURAC");
        }



        public ObservableCollection<int> enMon
        {
            get { return (ObservableCollection<int>)GetValue(enMonProperty); }
            set { SetValue(enMonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for enMon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty enMonProperty =
            DependencyProperty.Register("enMon", typeof(ObservableCollection<int>), typeof(MonumentsTable), new PropertyMetadata(new ObservableCollection<int>()));





        public onMonumentSelectionChanged MonumentSelectionChangedCallback
        {
            get { return (onMonumentSelectionChanged)GetValue(MonumentSelectionChangedCallbackProperty); }
            set { SetValue(MonumentSelectionChangedCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentSelectionChangedCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentSelectionChangedCallbackProperty =
            DependencyProperty.Register("MonumentSelectionChangedCallback", typeof(onMonumentSelectionChanged), typeof(MonumentsTable), new PropertyMetadata(null));






        ObservableCollection<int> enlargenedMonuments;
        public ObservableCollection<int> EnlargenedMonuments
        {
            get
            {
                return enlargenedMonuments;
            }
            set
            {
                if (value != enlargenedMonuments)
                {
                    enlargenedMonuments = value;
                    enMon = enlargenedMonuments;
                    OnPropertyChanged("EnlargenedMonuments");
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

        public void monumentClicked(int id)
        {
            MonumentRow myMonumentUC = null;
            MonumentRowDetail myMonumentDUC = null;
            foreach (MonumentRow tb in FindVisualChildren<MonumentRow>(RootWoot))
            {
                tb.Visibility = Visibility.Visible;
                if (tb.Tag.Equals(id))
                    myMonumentUC = tb;
                else
                    this.EnlargenedMonuments.Remove(tb.MonumentId);
            }
            foreach (MonumentRowDetail tb in FindVisualChildren<MonumentRowDetail>(RootWoot))
            {
                tb.Visibility = Visibility.Collapsed;
                if (tb.Tag.Equals(id))
                    myMonumentDUC = tb;
                else
                    this.EnlargenedMonuments.Remove(tb.MonumentId);
            }

            if (this.EnlargenedMonuments.IndexOf(id) == -1)
            {
                myMonumentUC.Visibility = Visibility.Collapsed;
                myMonumentDUC.Visibility = Visibility.Visible;
                this.EnlargenedMonuments.Add(id);
            }
            else
            {
                myMonumentDUC.Visibility = Visibility.Collapsed;
                myMonumentUC.Visibility = Visibility.Visible;
                this.EnlargenedMonuments.Remove(id);
            }
            MonumentSelectionChangedCallback();
        }

        public void ScrollToSelected()
        {
            if (EnlargenedMonuments.Count == 0)
            {
                return;
            }
            int Id = EnlargenedMonuments[0];
            Monument selectedMonument = Monuments.SingleOrDefault(x => x.Id == Id);
            if (selectedMonument != null)
            {
                int idx = Monuments.IndexOf(selectedMonument);
                Scroller.ScrollToVerticalOffset(idx * 84);
            }
        }
        
        Point startPoint = new Point();
        private void Root2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void Root2_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            e.Handled = true;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ItemsControl itemControl = sender as ItemsControl;
                MonumentRow itemControlItem1 =
                    Map.FindAncestor<MonumentRow>((DependencyObject)e.OriginalSource);
                Monument monument;
                if (itemControlItem1 == null)
                {
                    MonumentRowDetail itemControlItem2 =
                        Map.FindAncestor<MonumentRowDetail>((DependencyObject)e.OriginalSource);
                    monument = (Monument)itemControlItem2.DataContext;
                }
                else
                {
                    monument = (Monument)itemControlItem1.DataContext;
                }
                // Find the data behind the ListViewItem

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", monument);
                DragDrop.DoDragDrop((DependencyObject)e.OriginalSource, dragData, DragDropEffects.Move);
            }
        }
    }
}
