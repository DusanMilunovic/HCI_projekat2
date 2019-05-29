using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emlekmu.models
{
    public class Color
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        

        public string Hex { get; set; }

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
    }
}
