using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emlekmu.models
{
    public class Color : INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        int red;
        public int Red
        {
            get
            {
                return red;
            }
            set
            {
                if (value != red)
                {
                    red = value;
                    this.Hex = this.ToString();
                    OnPropertyChanged("Red");
                }
            }
        }
        int green;
        public int Green
        {
            get
            {
                return green;
            }
            set
            {
                if (value != green)
                {
                    green = value;
                    this.Hex = this.ToString();
                    OnPropertyChanged("Green");
                }
            }
        }
        int blue;
        public int Blue
        {
            get
            {
                return blue;
            }
            set
            {
                if (value != blue)
                {
                    blue = value;
                    this.Hex = this.ToString();
                    OnPropertyChanged("Blue");
                }
            }
        }

        string hex;
        public string Hex
        {
            get
            {
                return hex;
            }
            set
            {
                if (value != hex)
                {
                    hex = value;
                    OnPropertyChanged("Hex");
                }
            }
        }

        public Color()
        {

        }

        public Color(int Red, int Green, int Blue)
        {
            this.Red = Red;
            this.Green = Green;
            this.Blue = Blue;
            this.Hex = this.ToString();
        }
        public override string ToString()
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", Red, Green, Blue);
        }

        public Color(System.Windows.Media.Color color)
        {
            Red = color.R;
            Green = color.G;
            Blue = color.B;
            Hex = ToString();
        }

        public Color(string hex)
        {
            Red = int.Parse(hex.Substring(1, 2), System.Globalization.NumberStyles.HexNumber);
            Green = int.Parse(hex.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
            Blue = int.Parse(hex.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);
            Hex = ToString();
        }
    }
}
