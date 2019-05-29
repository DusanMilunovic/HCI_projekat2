using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace emlekmu.models
{
    public class Monument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Type Type { get; set; }
        public Era Era { get; set; }
        public string Icon { get; set; }
        public bool ArcheologicallyExplored { get; set; }
        public bool Unesco { get; set; }
        public bool PopulatedRegion { get; set; }
        public TouristicStatus TouristicStatus { get; set; }
        public int Income { get; set; }
        public string DiscoveryDate { get; set; }
        public ObservableCollection<Tag> Tags { get; set; }

        public Monument()
        {

        }

        public Monument(int Id, string Name, string Description,string Image, Type Type, Era Era, string Icon, bool ArcheologicallyExplored, bool Unesco, bool PopulatedRegion,
            TouristicStatus TouristicStatus, int Income, string DiscoveryDate)
        {
            this.Id = Id;
            this.Name = Name;
            this.Image = Image;
            this.Description = Description;
            this.Type = Type;
            this.Era = Era;
            this.Icon = Icon;
            this.ArcheologicallyExplored = ArcheologicallyExplored;
            this.Unesco = Unesco;
            this.PopulatedRegion = PopulatedRegion;
            this.TouristicStatus = TouristicStatus;
            this.Income = Income;
            this.DiscoveryDate = DiscoveryDate;
        }
    }
}


//ID|IME|OPIS|SLIKA|TIP|ERA|ICON|ARHEOLOSKI|UNESCO|NASELJENO|TURISTICKI|PRIHOD|DATUMOTKRIVANJA1