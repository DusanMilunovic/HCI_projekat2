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

        public Monument monument;
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

        public int top;
        public int Top {
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

        public int left;
        public int Left {
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

        public MonumentPosition(int top, int left)
        {
            Top = top;
            Left = left;
        }

        public MonumentPosition(int top, int left, Monument monument)
        {
            Top = top;
            Left = left;
            Monument = monument;
        }
    }
}
