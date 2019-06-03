using emlekmu.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace emlekmu.models
{
    public class MonumentPosition : INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Visibility showable;
        public Visibility Showable
        {
            get
            {
                return showable;
            }
            set
            {
                if (value != showable)
                {
                    showable = value;
                    OnPropertyChanged("Showable");
                }
            }
        }

        private models.Color color;
        public models.Color Color
        {
            get
            {
                return color;
            }
            set
            {
                if (value != color)
                {
                    color = value;
                    OnPropertyChanged("Color");
                }
            }
        }

        private Monument monument;
        public Monument Monument
        {
            get
            {
                return monument;
            }
            set
            {
                if (value != monument)
                {
                    monument = value;
                    OnPropertyChanged("Monument");
                }
            }
        }

        private double top;
        public double Top {
            get
            {
                return top;
            }
            set
            {
                if (value != top)
                {
                    top = value;
                    OnPropertyChanged("Top");
                }
            }
        }

        private double left;
        public double Left {
           get
            {
                return left;
            }

           set
            {
                if (value != left)
                {
                    left = value;
                    OnPropertyChanged("Left");
                }
            }
        }

        public MonumentPosition()
        {

        }

        public MonumentPosition(double top, double left)
        {
            Top = top;
            Left = left;
        }

        public MonumentPosition(double top, double left, Monument monument)
        {
            Top = top;
            Left = left;
            Monument = monument;
        }
    }
}
