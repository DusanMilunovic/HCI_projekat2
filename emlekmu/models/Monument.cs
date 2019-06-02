using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace emlekmu.models
{
    public class Monument : INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        public int Id
        {
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

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value != description)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        private string image;
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                if (value != image)
                {
                    image = value;
                    OnPropertyChanged("Image");
                }
            }
        }

        private Type type;
        public Type Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value != type)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        private Era era;
        public Era Era
        {
            get
            {
                return era;
            }
            set
            {
                if (value != era)
                {
                    era = value;
                    OnPropertyChanged("Era");
                }
            }
        }

        private string icon;
        public string Icon
        {
            get
            {
                return icon;
            }
            set
            {
                if (value != icon)
                {
                    icon = value;
                    OnPropertyChanged("Icon");
                }
            }
        }

        private bool archeologicallyExplored;
        public bool ArcheologicallyExplored
        {
            get
            {
                return archeologicallyExplored;
            }
            set
            {
                if (value != archeologicallyExplored)
                {
                    archeologicallyExplored = value;
                    OnPropertyChanged("ArcheologicallyExplored");
                }
            }
        }

        private bool unesco;
        public bool Unesco
        {
            get
            {
                return unesco;
            }
            set
            {
                if (value != unesco)
                {
                    unesco = value;
                    OnPropertyChanged("Unesco");
                }
            }
        }

        private bool populatedRegion;
        public bool PopulatedRegion
        {
            get
            {
                return populatedRegion;
            }
            set
            {
                if (value != populatedRegion)
                {
                    populatedRegion = value;
                    OnPropertyChanged("PopulatedRegion");
                }
            }
        }

        private TouristicStatus touristicStatus;
        public TouristicStatus TouristicStatus
        {
            get
            {
                return touristicStatus;
            }
            set
            {
                if (value != touristicStatus)
                {
                    touristicStatus = value;
                    OnPropertyChanged("TouristicStatus");
                }
            }
        }

        private int income;
        public int Income
        {
            get
            {
                return income;
            }
            set
            {
                if (value != income)
                {
                    income = value;
                    OnPropertyChanged("Income");
                }
            }
        }

        private string discoveryDate;
        public string DiscoveryDate
        {
            get
            {
                return discoveryDate;
            }
            set
            {
                if (value != discoveryDate)
                {
                    discoveryDate = value;
                    OnPropertyChanged("DiscoveryDate");
                }
            }
        }

        private ObservableCollection<Tag> tags;
        public ObservableCollection<Tag> Tags
        {
            get
            {
                return tags;
            }
            set
            {
                if (value != tags)
                {
                    tags = value;
                    OnPropertyChanged("Tags");
                }
            }
        }
        

        public Monument()
        {

        }

        public Monument(int Id, string Name, string Description,string Image, Type Type, Era Era, string Icon, bool ArcheologicallyExplored, bool Unesco, bool PopulatedRegion,
            TouristicStatus TouristicStatus, int Income, string DiscoveryDate, List<Tag> tags)
        {
            this.Id = Id;
            this.Name = Name;
            this.Image = Image;
            this.Description = Description;
            this.Type = Type;
            this.Era = Era;
            this.Tags = new ObservableCollection<Tag>(tags);
            this.Icon = Icon;
            this.ArcheologicallyExplored = ArcheologicallyExplored;
            this.Unesco = Unesco;
            this.PopulatedRegion = PopulatedRegion;
            this.TouristicStatus = TouristicStatus;
            this.Income = Income;
            this.DiscoveryDate = DiscoveryDate;
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

            // TODO: write your implementation of Equals() here
            if (this.Id == ((Monument)obj).Id)
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


//ID|IME|OPIS|SLIKA|TIP|ERA|ICON|ARHEOLOSKI|UNESCO|NASELJENO|TURISTICKI|PRIHOD|DATUMOTKRIVANJA1