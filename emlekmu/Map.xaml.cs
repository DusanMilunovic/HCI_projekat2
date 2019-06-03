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
using emlekmu.models;
using static emlekmu.MainContent;
using System.Windows.Threading;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : UserControl, INotifyPropertyChanged
    {



        public ObservableCollection<int> EnlargenedMonuments
        {
            get { return (ObservableCollection<int>)GetValue(EnlargenedMonumentsProperty); }
            set { SetValue(EnlargenedMonumentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnlargenedMonuments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnlargenedMonumentsProperty =
            DependencyProperty.Register("EnlargenedMonuments", typeof(ObservableCollection<int>), typeof(Map), new PropertyMetadata(new ObservableCollection<int>()));



        public string MapName
        {
            get { return (string)GetValue(MapNameProperty); }
            set { SetValue(MapNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MapName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MapNameProperty =
            DependencyProperty.Register("MapName", typeof(string), typeof(Map), new PropertyMetadata(""));


        public int MyMapHeight
        {
            get { return (int)GetValue(MyMapHeightProperty); }
            set { SetValue(MyMapHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyMapHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyMapHeightProperty =
            DependencyProperty.Register("MyMapHeight", typeof(int), typeof(Map), new PropertyMetadata(800));



        public int MyMapWidth
        {
            get { return (int)GetValue(MyMapWidthProperty); }
            set { SetValue(MyMapWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyMapWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyMapWidthProperty =
            DependencyProperty.Register("MyMapWidth", typeof(int), typeof(Map), new PropertyMetadata(1200));






        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double eWidth;

        public double EWidth
        {
            get
            {
                return eWidth;
            }
            set
            {
                if (value != eWidth)
                {
                    eWidth = value;
                    OnPropertyChanged("EWidth");
                }
            }
        }

        public double eHeight;

        public double EHeight
        {
            get
            {
                return eHeight;
            }
            set
            {
                if (value != eHeight)
                {
                    eHeight = value;
                    OnPropertyChanged("EHeight");
                }
            }
        }

        public double scrollWidth;

        public double ScrollWidth
        {
            get
            {
                return scrollWidth;
            }
            set
            {
                if (value != scrollWidth)
                {
                    scrollWidth = value;
                    OnPropertyChanged("ScrollWidth");
                }
            }
        }

        public double scrollHeight;

        public double ScrollHeight
        {
            get
            {
                return scrollHeight;
            }
            set
            {
                if (value != scrollHeight)
                {
                    scrollHeight = value;
                    OnPropertyChanged("ScrollHeight");
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
        
        public void updateSelection()
        {
            int id = -1;
            if (EnlargenedMonuments.Count() == 1)
                id = EnlargenedMonuments[0];
            foreach (MonumentPin tb in FindVisualChildren<MonumentPin>(Root))
            {
                tb.UpdateColor(null, null);
            }
            
        }
        public Point currentMousePoint;

        public Point CurrentMousePoint
        {
            get
            {
                return currentMousePoint;
            }
            set
            {
                if (value != currentMousePoint)
                {
                    currentMousePoint = value;
                    OnPropertyChanged("CurrentMousePoint");
                }
            }
        }



        public onMapSave saveMapData
        {
            get { return (onMapSave)GetValue(saveMapDataProperty); }
            set { SetValue(saveMapDataProperty, value); }
        }

        // Using a DependencyProperty as the backing store for saveMapData.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty saveMapDataProperty =
            DependencyProperty.Register("saveMapData", typeof(onMapSave), typeof(Map), new PropertyMetadata(null));



        public delegate void onRemovePin(Monument m);
        public onRemovePin RemovePinCallback { get; set; }

        public void RemovePinFromMap(Monument monument)
        {
            MonumentPosition mp = Positions.SingleOrDefault(x => x.Monument.Id == monument.Id);
            if (mp != null)
            {
                Positions.Remove(mp);
                saveMapData();
            }
        } 


        public ObservableCollection<MonumentPosition> Positions
        {
            get { return (ObservableCollection<MonumentPosition>)GetValue(PositionsProperty); }
            set { SetValue(PositionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Positions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositionsProperty =
            DependencyProperty.Register("Positions", typeof(ObservableCollection<MonumentPosition>), typeof(Map), new PropertyMetadata(new ObservableCollection<MonumentPosition>()));



        public onOpenEditMonument OpenEditMonumentCallback
        {
            get { return (onOpenEditMonument)GetValue(OpenEditMonumentCallbackProperty); }
            set { SetValue(OpenEditMonumentCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenEditMonumentDialogCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenEditMonumentCallbackProperty =
            DependencyProperty.Register("OpenEditMonumentCallback", typeof(onOpenEditMonument), typeof(Map), new PropertyMetadata(null));



        public onOpenMonumentDetail OpenMonumentDetailCallback
        {
            get { return (onOpenMonumentDetail)GetValue(OpenMonumentDetailCallbackProperty); }
            set { SetValue(OpenMonumentDetailCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenMonumentDetailsCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenMonumentDetailCallbackProperty =
            DependencyProperty.Register("OpenMonumentDetailCallback", typeof(onOpenMonumentDetail), typeof(Map), new PropertyMetadata(null));



        public onRemoveMonument RemoveMonumentCallback
        {
            get { return (onRemoveMonument)GetValue(RemoveMonumentCallbackProperty); }
            set { SetValue(RemoveMonumentCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemoveMonumentCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemoveMonumentCallbackProperty =
            DependencyProperty.Register("RemoveMonumentCallback", typeof(onRemoveMonument), typeof(Map), new PropertyMetadata(null));




        public onPinClicked PinClickedCallback
        {
            get { return (onPinClicked)GetValue(PinClickedCallbackProperty); }
            set { SetValue(PinClickedCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PinClickedCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PinClickedCallbackProperty =
            DependencyProperty.Register("PinClickedCallback", typeof(onPinClicked), typeof(Map), new PropertyMetadata(null));

        public double PinContainerWidth { get; set; }
        public double PinContainerHeight { get; set; }

        public onOpenAddMonument OpenAddMonumentCallback
        {
            get { return (onOpenAddMonument)GetValue(OpenAddMonumentCallbackProperty); }
            set { SetValue(OpenAddMonumentCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenAddMonumentCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenAddMonumentCallbackProperty =
            DependencyProperty.Register("OpenAddMonumentCallback", typeof(onOpenAddMonument), typeof(Map), new PropertyMetadata(null));



        public string MousePositionXText
        {
            get { return (string)GetValue(MousePositionXTextProperty); }
            set { SetValue(MousePositionXTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MousePositionText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MousePositionXTextProperty =
            DependencyProperty.Register("MousePositionXText", typeof(string), typeof(Map), new PropertyMetadata(""));


        public string MousePositionYText
        {
            get { return (string)GetValue(MousePositionYTextProperty); }
            set { SetValue(MousePositionYTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MousePositionText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MousePositionYTextProperty =
            DependencyProperty.Register("MousePositionYText", typeof(string), typeof(Map), new PropertyMetadata(""));


        public Map()
        {
            InitializeComponent();

            RemovePinCallback = new onRemovePin(RemovePinFromMap);
            Root.DataContext = this;
            EWidth = 160;
            EHeight = 160;
            //ova dva namestiti na polovinu velicine grida koji sadrzi monument pinove. nisam uspeo da izvucem iz xamla
            PinContainerWidth = 80;
            PinContainerHeight = 80;

        }


        const double ScaleRate = 2;
        const double Diff = ScaleRate - 1;
        double ai = 1;
        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            double scaleDeltaX;
            double scaleDeltaY;
            var a = e.GetPosition((IInputElement)sender);
            if (e.Delta > 0)
            {
                if (ai > 10)
                {
                    return;
                }
                scaleDeltaX = (1 / (st.ScaleX * ScaleRate) - 1 / st.ScaleX);
                scaleDeltaY = (1 / (st.ScaleY * ScaleRate) - 1 / st.ScaleY);

                st.ScaleX *= ScaleRate;
                st.ScaleY *= ScaleRate;
                if (ai <= 2)
                {
                    st.CenterX = (st.CenterX - 4 * scaleDeltaX * a.X) / 2;
                    st.CenterY = (st.CenterY - 4 * scaleDeltaY * a.Y) / 2;
                }
                else
                {
                    st.CenterX = (st.CenterX - Math.Pow(2, ai) * scaleDeltaX * a.X) / 2;
                    st.CenterY = (st.CenterY - Math.Pow(2, ai) * scaleDeltaY * a.Y) / 2;
                }

                ai++;
                ScrollHeight *= 2;
                ScrollWidth *= 2;
                EWidth /= 2;
                EHeight /= 2;
            }
            else
            {
                //if (st.ScaleX < 1)
                //{
                //    return;
                //}
                //scaleDeltaX = -st.ScaleX / ScaleRate + st.ScaleX;
                //scaleDeltaY = -st.ScaleY / ScaleRate + st.ScaleY;
                //st.ScaleX /= ScaleRate;
                //st.ScaleY /= ScaleRate;
                //st.CenterX = (a.X) - scaleDeltaX * a.X;
                //st.CenterY = (a.Y) - scaleDeltaY * a.Y;
                if (ai <= 1)
                {
                    return;
                }
                scaleDeltaX = (1 / (st.ScaleX / ScaleRate) - 1 / st.ScaleX);
                scaleDeltaY = (1 / (st.ScaleY / ScaleRate) - 1 / st.ScaleY);

                st.ScaleX /= ScaleRate;
                st.ScaleY /= ScaleRate;
                if (ai == 2)
                {
                    st.CenterX = (st.CenterX - 2 * scaleDeltaX * a.X) / 2;
                    st.CenterY = (st.CenterY - 2 * scaleDeltaY * a.Y) / 2;
                }
                else
                {
                    st.CenterX = (st.CenterX + Math.Pow(2, ai - 1) * scaleDeltaX * a.X) / 2;
                    st.CenterY = (st.CenterY + Math.Pow(2, ai - 1) * scaleDeltaY * a.Y) / 2;
                }

                ai--;

                ScrollHeight /= 2;
                ScrollWidth /= 2;
                EWidth *= 2;
                EHeight *= 2;
            }
        }

        Point startPoint = new Point();

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition((IInputElement)sender);
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.Cursor != ((TextBlock)((ResourceDictionary)Resources["resourceDictionary"])["CursorGrabbing"]).Cursor)
            {
                Point mousePos = e.GetPosition(null);
                Vector diff = startPoint - mousePos;
                e.Handled = true;

                if (e.LeftButton == MouseButtonState.Pressed &&
                    (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
                {
                    // Get the dragged ListViewItem
                    MonumentPin monumentPin = sender as MonumentPin;
                    Canvas listViewItem =
                        FindAncestor<Canvas>((DependencyObject)e.OriginalSource);
                    Grid a = (Grid)monumentPin.Parent;
                    var b = a.Parent;
                    // Find the data behind the ListViewItem
                    Monument monument = monumentPin.MyMonument;

                    // Initialize the drag & drop operation
                    DataObject dragData = new DataObject("myFormat", monument);
                    DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
                }
            }
        }

        public static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.Move;
                
            }
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                var a = e.GetPosition((IInputElement)sender);
                Monument monument = e.Data.GetData("myFormat") as Monument;
                bool positionConflict = true;
                int i = 0;
                while (positionConflict)
                {
                    i++;
                    positionConflict = false;
                    foreach (MonumentPosition position in Positions)
                    {
                        if (position.Monument.Id != monument.Id)
                        {
                            double diffX = position.Top - (a.X - PinContainerWidth);
                            double diffY = position.Left - (a.Y - PinContainerHeight);
                            if (Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2)) < 0.1)
                            {
                                a.X -= Math.Sign(diffX) * 0.1 * i;
                                a.Y -= Math.Sign(diffY) * 0.1 * i;
                            }
                        }
                    }
                }
                foreach (MonumentPosition position in Positions)
                {
                    if (position.Monument != null && position.Monument.Id == monument.Id)
                    {
                        
                        position.Left = (a.Y - PinContainerWidth);
                        position.Top = (a.X - PinContainerHeight);
                        return;
                    }
                }
                MonumentPosition mp = new MonumentPosition(a.X - PinContainerHeight, a.Y - PinContainerWidth, monument);
                var tmp = new List<MonumentPosition>(Positions);
                tmp.Add(mp);

                Positions = new ObservableCollection<MonumentPosition>(tmp);
                saveMapData();
            }
        }

        private void Kartocka_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(Kartocka);
            this.Cursor = ((TextBlock)((ResourceDictionary)Resources["resourceDictionary"])["CursorGrabbing"]).Cursor;
        }

        private void Kartocka_MouseMove(object sender, MouseEventArgs e)
       {
            Point mousePos = e.GetPosition(Kartocka);
            MousePositionXText = "X: " + Convert.ToString(mousePos.X);
            MousePositionYText = "Y: " + Convert.ToString(mousePos.Y);
            Vector diff = startPoint - mousePos;
            e.Handled = true;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > 20/ai/ai ||
                Math.Abs(diff.Y) > 20/ai/ai))
            {
                st.CenterX = Math.Max(0, st.CenterX + diff.X / 10 * ai);
                st.CenterY = Math.Max(0, st.CenterY +  diff.Y / 10 * ai);
                double maxWidth = Kartocka.Width;
                double maxHeight = Kartocka.Height - Kartocka.Height / st.ScaleY + 50;
                if (st.CenterX > maxWidth - diff.X / 20 / ai)
                {
                    st.CenterX = maxWidth;
                }
                if (st.CenterY > Kartocka.Height - diff.Y / 20 / ai)
                {
                    st.CenterY = Kartocka.Height;
                }
            }
        }

        private void Kartocka_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void MonumentPin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
        private void onRightClick(object sender, MouseButtonEventArgs e)
        {
            if (e.Source.GetType().Name.Equals("MapWorld"))
            {
                CurrentMousePoint = e.GetPosition((IInputElement)sender);

                // open context menu

                ContextMenu cm = this.FindResource("cmMap") as ContextMenu;
                cm.IsOpen = true;
            }
            
        }

        private void AddMonumentAction(object sender, RoutedEventArgs e)
        {
            var monument = OpenAddMonumentCallback();
            if (monument != null)
            {
                PinClickedCallback(monument.Id);
                var tmp = new List<MonumentPosition>(Positions);
                tmp.Add(new MonumentPosition(Convert.ToInt32(CurrentMousePoint.X - PinContainerWidth),
                    Convert.ToInt32(CurrentMousePoint.Y - PinContainerWidth), monument));
                Positions = new ObservableCollection<MonumentPosition>(tmp);
                saveMapData();
            }
        }

        private void ZoomInAction(object sender, RoutedEventArgs e)
        {
            double scaleDeltaX;
            double scaleDeltaY;

            if (ai > 10)
            {
                return;
            }
            scaleDeltaX = (1 / (st.ScaleX * ScaleRate) - 1 / st.ScaleX);
            scaleDeltaY = (1 / (st.ScaleY * ScaleRate) - 1 / st.ScaleY);

            st.ScaleX *= ScaleRate;
            st.ScaleY *= ScaleRate;
            if (ai <= 2)
            {
                st.CenterX = (st.CenterX - 4 * scaleDeltaX * CurrentMousePoint.X) / 2;
                st.CenterY = (st.CenterY - 4 * scaleDeltaY * CurrentMousePoint.Y) / 2;
            }
            else
            {
                st.CenterX = (st.CenterX - Math.Pow(2, ai) * scaleDeltaX * CurrentMousePoint.X) / 2;
                st.CenterY = (st.CenterY - Math.Pow(2, ai) * scaleDeltaY * CurrentMousePoint.Y) / 2;
            }

            ai++;

            EWidth /= 2;
            EHeight /= 2;

        }

        private void ZoomOutAction(object sender, RoutedEventArgs e)
        {
            double scaleDeltaX;
            double scaleDeltaY;

            if (ai <= 1)
            {
                return;
            }
            scaleDeltaX = (1 / (st.ScaleX / ScaleRate) - 1 / st.ScaleX);
            scaleDeltaY = (1 / (st.ScaleY / ScaleRate) - 1 / st.ScaleY);

            st.ScaleX /= ScaleRate;
            st.ScaleY /= ScaleRate;
            if (ai == 2)
            {
                st.CenterX = (st.CenterX - 2 * scaleDeltaX * CurrentMousePoint.X) / 2;
                st.CenterY = (st.CenterY - 2 * scaleDeltaY * CurrentMousePoint.Y) / 2;
            }
            else
            {
                st.CenterX = (st.CenterX + Math.Pow(2, ai - 1) * scaleDeltaX * CurrentMousePoint.X) / 2;
                st.CenterY = (st.CenterY + Math.Pow(2, ai - 1) * scaleDeltaY * CurrentMousePoint.Y) / 2;
            }

            ai--;

            EWidth *= 2;
            EHeight *= 2;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!(Kartocka.Children[0] is MapEurope || Kartocka.Children[0] is MapWorld || Kartocka.Children[0] is SerbiaMap))
            {

                UIElement map = null;
                if (MapName == "World")
                {
                    map = new MapWorld();
                    ((MapWorld)map).Width = 1200;
                    ((MapWorld)map).Height = 800;
                }
                else if (MapName == "Europe")
                {
                    map = new MapEurope();
                    ((MapEurope)map).Width = 800;
                    ((MapEurope)map).Height = 800;
                }
                else if (MapName == "Serbia")
                {
                    map = new SerbiaMap();
                    ((SerbiaMap)map).Width = 800;
                    ((SerbiaMap)map).Height = 500;
                }
                else if (MapName == "Africa")
                {
                    map = new MapAfrica();
                    ((MapAfrica)map).Width = 800;
                    ((MapAfrica)map).Height = 500;
                }
                Kartocka.Children.Insert(0, map);
            }
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                e.Handled = true;
                HelpProvider.ShowHelpTopic("Maps");
            }
        }
    }
}
