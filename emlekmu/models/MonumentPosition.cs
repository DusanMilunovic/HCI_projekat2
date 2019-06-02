using emlekmu.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
