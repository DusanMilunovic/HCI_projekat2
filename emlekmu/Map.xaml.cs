﻿using System;
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

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for Map.xaml
    /// </summary>
    public partial class Map : UserControl, INotifyPropertyChanged
    {
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


        public ObservableCollection<MonumentPosition> positions;

        public ObservableCollection<MonumentPosition> Positions
        {
            get
            {
                return positions;
            }
            set
            {
                if (value != positions)
                {
                    positions = value;
                    OnPropertyChanged("Positions");
                }
            }
        }



        public ObservableCollection<Monument> Monuments
        {
            get { return (ObservableCollection<Monument>)GetValue(MonumentsProperty); }
            set { SetValue(MonumentsProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Monuments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentsProperty =
            DependencyProperty.Register("Monuments", typeof(ObservableCollection<Monument>), typeof(Map), new PropertyMetadata(new ObservableCollection<Monument>()));



        public Map()
        {
            InitializeComponent();
            Root.DataContext = this;
            EWidth = 20;
            EHeight = 20;
            Positions = new ObservableCollection<MonumentPosition>();
            Positions.Add(new MonumentPosition(10, 10, new Monument()));
            Positions.Add(new MonumentPosition(500, 100));
            Positions.Add(new MonumentPosition(700, 1000));
            Positions.Add(new MonumentPosition(100, 100));
            Positions.Add(new MonumentPosition(150, 200));
            Positions.Add(new MonumentPosition(111, 122));
            Positions.Add(new MonumentPosition(550, 300));
            Positions.Add(new MonumentPosition(700, 100));
        }

        const double ScaleRate = 2;
        const double Diff = ScaleRate - 1;
        double ai = 1;
        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double scaleDeltaX;
            double scaleDeltaY;
            var a = e.GetPosition((IInputElement)sender);
            if (e.Delta > 0)
            {
                //double ww = 500;
                //double wh = 300;
                //double tw = 500 - a.X;
                //double th = a.Y;
                //double v1 = Math.Sqrt(tw * tw + th * th);
                //double v2 = Math.Sqrt((ww - tw) * (ww - tw) + (wh - th) * (wh - th));
                //double wr = ww / ScaleRate;
                //double hr = wh / ScaleRate;
                //double md = Math.Sqrt(wr * wr + hr * hr);

                //double m1 = md / ((v2 / v1) + 1);
                //double m2 = (v2 / v1) * m1;

                //double c = th / tw;

                //double maliwidth = Math.Sqrt((md * md) / (c * c + 1));
                //double maliheight = maliwidth * c;


                //double actualX = tw + maliwidth - wr;
                //double actualY = maliheight + th;

                //st.ScaleX *= ScaleRate;
                //st.ScaleY *= ScaleRate;
                //st.CenterX = actualX;
                //st.CenterY = actualY;
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

                EWidth *= 2;
                EHeight *= 2;
            }
        }

        Point startPoint = new Point();

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

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
                DragDrop.DoDragDrop(a, dragData, DragDropEffects.Move);
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
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
                e.Effects = DragDropEffects.None;
            }
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Monument monument = e.Data.GetData("myFormat") as Monument;
            }
        }
    }
}