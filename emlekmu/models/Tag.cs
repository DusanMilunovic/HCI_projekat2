using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emlekmu.models
{
    public class Tag: INotifyPropertyChanged
    {
        string description;
        public string Description {
            get
            {
                return this.description;
            }
            set
            {
                if (value != description)
                {
                    
                    this.description = value;
                    if (this.description.Length > 30)
                        this.DescriptionShort = this.description.Substring(0, 30) + "...";
                    else
                        this.DescriptionShort = this.description;
                    OnPropertyChanged("Description");
                }
            }
        }

        public string descriptionShort;
        public string DescriptionShort
        {
            get
            {
                return descriptionShort;
            }
            set
            {
                if (value != descriptionShort)
                {
                    descriptionShort = value;
                    OnPropertyChanged("DescriptionShort");
                }
            }
        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string id;
        public string Id {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public Color color;
        public Color Color {
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
        public Tag()
        {

        }

        public Tag(string Id, Color Color, string Description)
        {
            this.Id = Id;
            this.Color = Color;
            this.Description = Description;
            if (this.Description.Length > 30)
                this.DescriptionShort = this.Description.Substring(0, 30) + "...";
            else
                this.DescriptionShort = this.Description;
        }
        

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (this.Id == ((Tag)obj).Id)
            {
                return true;
            }
            return false;

        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
