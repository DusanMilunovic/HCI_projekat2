using emlekmu.models;
using emlekmu.models.IO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using WpfApplication1;
using Type = emlekmu.models.Type;
using Color = emlekmu.models.Color;
using emlekmu.models.IO;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for MainContent.xaml
    /// </summary>
    /// 

    public partial class MainContent : UserControl, INotifyPropertyChanged
    {


        #region Events

        public delegate void onPinClicked(int monumentId);
        public onPinClicked pinClickedCallback { get; set; }


        public delegate void onMapSave();
        public onMapSave mapSaveCallback { get; set; }

        public void pinClicked(int monumentId)
        {
            MonumentTable.monumentClicked(monumentId);
            MonumentTable.ScrollToSelected();
        }
        #endregion
        #region Data

        public static string RESOURCES_PATH = "";


        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Type> types;
        public ObservableCollection<Type> Types
        {
            get
            {
                return types;
            }
            set
            {
                if (value != types)
                {
                    types = value;
                    OnPropertyChanged("Types");
                }
            }
        }

        ObservableCollection<Monument> monuments;
        public ObservableCollection<Monument> Monuments
        {
            get
            {
                return monuments;
            }
            set
            {
                if (value != monuments)
                {
                    monuments = value;
                    OnPropertyChanged("Monuments");
                }
            }
        }
        ObservableCollection<Monument> searchedMonuments;
        public ObservableCollection<Monument> SearchedMonuments
        {
            get
            {
                return searchedMonuments;
            }
            set
            {
                if (value != searchedMonuments)
                {
                    searchedMonuments = value;
                    foreach (var item in Map1Monuments)
                    {
                        if(searchedMonuments.IndexOf(item.Monument) != -1)
                        {
                            item.Showable = Visibility.Visible;
                        } else
                        {
                            item.Showable = Visibility.Collapsed;
                        }
                    }
                    foreach (var item in Map2Monuments)
                    {
                        if (searchedMonuments.IndexOf(item.Monument) != -1)
                        {
                            item.Showable = Visibility.Visible;
                        }
                        else
                        {
                            item.Showable = Visibility.Collapsed;
                        }
                    }
                    foreach (var item in Map3Monuments)
                    {
                        if (searchedMonuments.IndexOf(item.Monument) != -1)
                        {
                            item.Showable = Visibility.Visible;
                        }
                        else
                        {
                            item.Showable = Visibility.Collapsed;
                        }
                    }
                    foreach (var item in Map4Monuments)
                    {
                        if (searchedMonuments.IndexOf(item.Monument) != -1)
                        {
                            item.Showable = Visibility.Visible;
                        }
                        else
                        {
                            item.Showable = Visibility.Collapsed;
                        }
                    }
                    OnPropertyChanged("SearchedMonuments");
                }
            }
        }

        ObservableCollection<Monument> searchedNFMonuments;
        public ObservableCollection<Monument> SearchedNFMonuments
        {
            get
            {
                return searchedNFMonuments;
            }
            set
            {
                if (value != searchedNFMonuments)
                {
                    searchedNFMonuments = value;

                    OnPropertyChanged("SearchedNFMonuments");
                }
            }
        }
        ObservableCollection<Monument> filteredMonuments;
        public ObservableCollection<Monument> FilteredMonuments
        {
            get
            {
                return filteredMonuments;
            }
            set
            {
                if (value != filteredMonuments)
                {
                    filteredMonuments = value;
                    foreach (var item in Map1Monuments)
                    {
                        if (filteredMonuments.IndexOf(item.Monument) != -1)
                        {
                            item.Color = new Color("#2299CC");
                        }
                        else
                        {
                            item.Color = new Color(255, 255, 255);
                        }
                    }
                    foreach (var item in Map2Monuments)
                    {
                        if (filteredMonuments.IndexOf(item.Monument) != -1)
                        {
                            item.Color = new Color("#2299CC");
                        }
                        else
                        {
                            item.Color = new Color(255, 255, 255);
                        }
                    }
                    foreach (var item in Map3Monuments)
                    {
                        if (filteredMonuments.IndexOf(item.Monument) != -1)
                        {
                            item.Color = new Color("#2299CC");
                        }
                        else
                        {
                            item.Color = new Color(255, 255, 255);
                        }
                    }
                    foreach (var item in Map4Monuments)
                    {
                        if (filteredMonuments.IndexOf(item.Monument) != -1)
                        {
                            item.Color = new Color("#2299CC");
                        }
                        else
                        {
                            item.Color = new Color(255, 255, 255);
                        }
                    }
                    OnPropertyChanged("FilteredMonuments");
                }
            }
        }

        ObservableCollection<Tag> tags;
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

        ObservableCollection<MonumentPosition> map1Monumets;

        public ObservableCollection<MonumentPosition> Map1Monuments
        {
            get
            {
                return map1Monumets;
            }
            set
            {
                if (value != map1Monumets)
                {
                    map1Monumets = value;
                    foreach (var item in map1Monumets)
                    {
                        if(this.searchedMonuments != null)
                        {
                            if (this.searchedMonuments.IndexOf(item.Monument) != -1)
                                item.Showable = Visibility.Visible;
                            else
                                item.Showable = Visibility.Collapsed;
                        }
                        
                        if(this.filteredMonuments != null)
                        {
                            if (this.filteredMonuments.IndexOf(item.Monument) != -1)
                                item.Color = new Color("#2299CC");
                            else
                                item.Color = new Color(255, 255, 255);
                        }
                        
                    }
                    OnPropertyChanged("Map1Monuments");
                }
            }
        }

        ObservableCollection<MonumentPosition> map2Monumets;

        public ObservableCollection<MonumentPosition> Map2Monuments
        {
            get
            {
                return map2Monumets;
            }
            set
            {
                if (value != map2Monumets)
                {
                    map2Monumets = value;
                    foreach (var item in map2Monumets)
                    {
                        if (this.searchedMonuments != null)
                        {
                            if (this.searchedMonuments.IndexOf(item.Monument) != -1)
                                item.Showable = Visibility.Visible;
                            else
                                item.Showable = Visibility.Collapsed;
                        }

                        if (this.filteredMonuments != null)
                        {
                            if (this.filteredMonuments.IndexOf(item.Monument) != -1)
                                item.Color = new Color("#2299CC");
                            else
                                item.Color = new Color(255, 255, 255);
                        }

                    }
                    OnPropertyChanged("Map2Monuments");
                }
            }
        }

        ObservableCollection<MonumentPosition> map3Monumets;

        public ObservableCollection<MonumentPosition> Map3Monuments
        {
            get
            {
                return map3Monumets;
            }
            set
            {
                if (value != map3Monumets)
                {
                    map3Monumets = value;
                    foreach (var item in map3Monumets)
                    {
                        if (this.searchedMonuments != null)
                        {
                            if (this.searchedMonuments.IndexOf(item.Monument) != -1)
                                item.Showable = Visibility.Visible;
                            else
                                item.Showable = Visibility.Collapsed;
                        }

                        if (this.filteredMonuments != null)
                        {
                            if (this.filteredMonuments.IndexOf(item.Monument) != -1)
                                item.Color = new Color("#2299CC");
                            else
                                item.Color = new Color(255, 255, 255);
                        }

                    }
                    OnPropertyChanged("Map3Monuments");
                }
            }
        }

        ObservableCollection<MonumentPosition> map4Monumets;

        public ObservableCollection<MonumentPosition> Map4Monuments
        {
            get
            {
                return map4Monumets;
            }
            set
            {
                if (value != map4Monumets)
                {
                    map4Monumets = value;
                    foreach (var item in map4Monumets)
                    {
                        if (this.searchedMonuments != null)
                        {
                            if (this.searchedMonuments.IndexOf(item.Monument) != -1)
                                item.Showable = Visibility.Visible;
                            else
                                item.Showable = Visibility.Collapsed;
                        }

                        if (this.filteredMonuments != null)
                        {
                            if (this.filteredMonuments.IndexOf(item.Monument) != -1)
                                item.Color = new Color("#2299CC");
                            else
                                item.Color = new Color(255, 255, 255);
                        }

                    }
                    OnPropertyChanged("Map4Monuments");
                }
            }
        }

        public MapEurope MyMap { get; set; }

        #endregion

        #region Search parameters

        public string searchFilter;

        public string SearchFilter
        {
            get
            {
                return searchFilter;
            }

            set
            {
                if (value != searchFilter)
                {
                    searchFilter = value;
                    OnPropertyChanged("SearchFilter");
                }
            }
        }

        int id_s;
        string name_s;
        int typeName_s;
        string era_s;
        int arch_s;
        int unesco_s;
        int populated_s;
        string touristicStatus_s;
        int min_income_s;
        int max_income_s;
        List<Tag> tags_s;


        int id_f;
        string name_f;
        int typeName_f;
        string era_f;
        int arch_f;
        int unesco_f;
        int populated_f;
        string touristicStatus_f;
        int min_income_f;
        int max_income_f;
        List<Tag> tags_f;
        #endregion
        #region Lists

        #endregion
        #region Monument
        public delegate Monument onAddMonument(Monument m);
        public delegate Monument onRemoveMonument(int id);
        public delegate Monument onEditMonument(Monument m);
        public delegate Monument onFindMonument(int id);
        public delegate void onFindMonuments(int id, string name, int typeName, string era, int arch, int unesco, int populated, string touristicStatus, int min_income, int max_income, List<Tag> tags);
        public delegate void onFilterMonuments(int id, string name, int typeName, string era, int arch, int unesco, int populated, string touristicStatus, int min_income, int max_income, List<Tag> tags);


        public onAddMonument addMonumentCallback { get; set; }
        public onRemoveMonument removeMonumentCallback { get; set; }
        public onEditMonument editMonumentCallback { get; set; }
        public onFindMonument findMonumentCallback { get; set; }
        public onFindMonuments findMonumentsCallback { get; set; }
        public onFilterMonuments filterMonumentsCallback { get; set; }

        public delegate void onMonumentSelectionChanged();
        public onMonumentSelectionChanged monumentSelectionChangedCallback { get; set; }

        public void MonumentSelectionChanged()
        {
            Map1.updateSelection();
            Map2.updateSelection();
            Map3.updateSelection();
            Map4.updateSelection();
        }

        Monument addMonument(Monument t)
        {
            this.Monuments.Add(t);

            this.SearchedMonuments.Add(t);
            if (id_s != -1)
            {
                if (t.Id != id_s)
                {
                    SearchedMonuments.Remove(t);
                }
            }

            if (name_s != "" && name_s != null)
            {
                if (!t.Name.ToLower().Contains(name_s.ToLower()))
                {
                    SearchedMonuments.Remove(t);
                }
            }

            if (typeName_s != -1 && typeName_s != null)
            {
                if (!t.Type.Id.Equals(typeName_s))
                {
                    SearchedMonuments.Remove(t);
                }
            }

            if (era_s != "" && era_s != "--" && era_s != null)
            {
                if (!t.Era.ToString().ToLower().Contains(era_s.ToLower()))
                {
                    SearchedMonuments.Remove(t);
                }
            }

            if (arch_s != -1)
            {
                bool match = false;
                if (arch_s == 1)
                    match = true;
                if (t.ArcheologicallyExplored != match)
                {
                    SearchedMonuments.Remove(t);
                }

            }

            if (unesco_s != -1)
            {
                bool match = false;
                if (unesco_s == 1)
                    match = true;
                if (t.Unesco != match)
                {
                    SearchedMonuments.Remove(t);
                }
            }

            if (populated_s != -1)
            {
                bool match = false;
                if (populated_s == 1)
                    match = true;
                if (t.PopulatedRegion != match)
                {
                    SearchedMonuments.Remove(t);
                }
            }

            if (touristicStatus_s != "" && touristicStatus_s != "--" && touristicStatus_s != null)
            {
                if (!t.TouristicStatus.ToString().ToLower().Contains(touristicStatus_s.ToLower()))
                {
                    SearchedMonuments.Remove(t);
                }
            }

            if (min_income_s != -1)
            {
                if (t.Income < min_income_s)
                {
                    SearchedMonuments.Remove(t);
                }
            }

            if (max_income_s != -1)
            {
                if (t.Income > max_income_s)
                {
                    SearchedMonuments.Remove(t);
                }

            }

            if (tags_s != null)
            {
                if (tags_s.Count != 0)
                {
                    bool match = false;
                    foreach (var tag in tags_s)
                    {
                        if (t.Tags.IndexOf(tag) != -1)
                            match = true;
                    }

                    if (!match)
                        SearchedMonuments.Remove(t);
                }
            }

            bool anyfilter = false;
            bool flag = true;
            if (id_f != -1)
            {
                anyfilter = true;
                if (t.Id != id_f)
                {
                    flag = false;
                }
            }

            if (name_f != "" && name_f != null)
            {
                anyfilter = true;
                if (!t.Name.ToLower().Contains(name_f.ToLower()))
                {
                    flag = false;
                }
            }

            if (typeName_f != -1 && typeName_f != null)
            {
                anyfilter = true;
                if (!t.Type.Id.Equals(typeName_f))
                {
                    flag = false;
                }
            }

            if (era_f != "" && era_f != "--" && era_f != null)
            {
                anyfilter = true;
                if (!t.Era.ToString().ToLower().Contains(era_f.ToLower()))
                {
                    flag = false;
                }
            }

            if (arch_f != -1)
            {
                anyfilter = true;
                bool match = false;
                if (arch_f == 1)
                    match = true;
                if (t.ArcheologicallyExplored != match)
                {
                    flag = false;
                }

            }

            if (unesco_f != -1)
            {
                anyfilter = true;
                bool match = false;
                if (unesco_f == 1)
                    match = true;
                if (t.Unesco != match)
                {
                    flag = false;
                }
            }

            if (populated_f != -1)
            {
                anyfilter = true;
                bool match = false;
                if (populated_f == 1)
                    match = true;
                if (t.PopulatedRegion != match)
                {
                    flag = false;
                }
            }

            if (touristicStatus_f != "" && touristicStatus_f != "--" && touristicStatus_f != null)
            {
                anyfilter = true;
                if (!t.TouristicStatus.ToString().ToLower().Contains(touristicStatus_f.ToLower()))
                {
                    flag = false;
                }
            }

            if (min_income_f != -1)
            {
                anyfilter = true;
                if (t.Income < min_income_f)
                {
                    flag = false;
                }
            }

            if (max_income_f != -1)
            {
                anyfilter = true;
                if (t.Income > max_income_f)
                {
                    flag = false;
                }

            }

            if (tags_f != null)
            {
                if (tags_f.Count != 0)
                {
                    anyfilter = true;
                    bool match = false;
                    foreach (var tag in tags_f)
                    {
                        if (t.Tags.IndexOf(tag) != -1)
                            match = true;
                    }

                    if (!match)
                        flag = false;
                }
            }

            if (anyfilter && flag)
                this.FilteredMonuments.Add(t);
            else if(!anyfilter)
                this.FilteredMonuments = new ObservableCollection<Monument>();

            this.SearchedNFMonuments = new ObservableCollection<Monument>(this.SearchedMonuments.Except(this.FilteredMonuments));

            SaveData();
            return t;
        }

        Monument removeMonument(int id)
        {
            Monument mon = null;

            foreach (var m in this.Monuments)
            {
                if (m.Id == id)
                {
                    mon = m;
                    break;
                }
            }

            if (mon == null)
            {
                return null;
            }

            MonumentPosition mp1 = Map1Monuments.SingleOrDefault(x => x.Monument.Id == id);
            if (mp1 != null)
            {
                Map1Monuments.Remove(mp1);
            }
            MonumentPosition mp2 = Map2Monuments.SingleOrDefault(x => x.Monument.Id == id);
            if (mp2 != null)
            {
                Map2Monuments.Remove(mp2);
            }
            MonumentPosition mp3 = Map3Monuments.SingleOrDefault(x => x.Monument.Id == id);
            if (mp3 != null)
            {
                Map3Monuments.Remove(mp3);
            }
            MonumentPosition mp4 = Map4Monuments.SingleOrDefault(x => x.Monument.Id == id);
            if (mp4 != null)
            {
                Map4Monuments.Remove(mp4);
            }

            this.Monuments.Remove(mon);
            this.SearchedMonuments.Remove(mon);
            this.FilteredMonuments.Remove(mon);
            this.SearchedNFMonuments.Remove(mon);


            SaveData();
            SaveMapData();
            return mon;
        }

        Monument editMonument(Monument t)
        {
            int idx = this.Monuments.IndexOf(t);
            if (idx == -1)
                return null;
            this.Monuments[idx].Name = t.Name;
            this.Monuments[idx].Description = t.Description;
            this.Monuments[idx].Image = t.Image;
            this.Monuments[idx].Type = t.Type;
            this.Monuments[idx].Era = t.Era;
            this.Monuments[idx].Icon = t.Icon;
            this.Monuments[idx].ArcheologicallyExplored = t.ArcheologicallyExplored;
            this.Monuments[idx].Unesco = t.Unesco;
            this.Monuments[idx].PopulatedRegion = t.PopulatedRegion;
            this.Monuments[idx].TouristicStatus = t.TouristicStatus;
            this.Monuments[idx].Income = t.Income;
            this.Monuments[idx].DiscoveryDate = t.DiscoveryDate;
            this.Monuments[idx].Tags = t.Tags;


            int idxs = this.SearchedMonuments.IndexOf(t);
            this.SearchedMonuments[idxs].Name = t.Name;
            this.SearchedMonuments[idxs].Description = t.Description;
            this.SearchedMonuments[idxs].Image = t.Image;
            this.SearchedMonuments[idxs].Type = t.Type;
            this.SearchedMonuments[idxs].Era = t.Era;
            this.SearchedMonuments[idxs].Icon = t.Icon;
            this.SearchedMonuments[idxs].ArcheologicallyExplored = t.ArcheologicallyExplored;
            this.SearchedMonuments[idxs].Unesco = t.Unesco;
            this.SearchedMonuments[idxs].PopulatedRegion = t.PopulatedRegion;
            this.SearchedMonuments[idxs].TouristicStatus = t.TouristicStatus;
            this.SearchedMonuments[idxs].Income = t.Income;
            this.SearchedMonuments[idxs].DiscoveryDate = t.DiscoveryDate;
            this.SearchedMonuments[idxs].Tags = t.Tags;
            if (id_s != -1)
            {
                if (t.Id != id_s)
                {
                    SearchedMonuments.Remove(t);
                }
            }

            if (name_s != "" && name_s != null)
            {
                if (!t.Name.ToLower().Contains(name_s.ToLower()))
                {
                    SearchedMonuments.Remove(t);
                }
            }

            if (typeName_s != -1 && typeName_s != null)
            {
                if (!t.Type.Id.Equals(typeName_s))
                {
                    SearchedMonuments.Remove(t);
                }
            }

            if (era_s != "" && era_s != "--" && era_s != null)
            {
                if (!t.Era.ToString().ToLower().Contains(era_s.ToLower()))
                {
                    SearchedMonuments.Remove(t);
                }
            }

            if (arch_s != -1)
            {
                bool match = false;
                if (arch_s == 1)
                    match = true;
                if (t.ArcheologicallyExplored != match)
                {
                    SearchedMonuments.Remove(t);
                }

            }

            if (unesco_s != -1)
            {
                bool match = false;
                if (unesco_s == 1)
                    match = true;
                if (t.Unesco != match)
                {
                    SearchedMonuments.Remove(t);
                }
            }

            if (populated_s != -1)
            {
                bool match = false;
                if (populated_s == 1)
                    match = true;
                if (t.PopulatedRegion != match)
                {
                    SearchedMonuments.Remove(t);
                }
            }

            if (touristicStatus_s != "" && touristicStatus_s != "--" && touristicStatus_s != null)
            {
                if (!t.TouristicStatus.ToString().ToLower().Contains(touristicStatus_s.ToLower()))
                {
                    SearchedMonuments.Remove(t);
                }
            }

            if (min_income_s != -1)
            {
                if (t.Income < min_income_s)
                {
                    SearchedMonuments.Remove(t);
                }
            }

            if (max_income_s != -1)
            {
                if (t.Income > max_income_s)
                {
                    SearchedMonuments.Remove(t);
                }

            }

            if (tags_s != null)
            {
                if (tags_s.Count != 0)
                {
                    bool match = false;
                    foreach (var tag in tags_s)
                    {
                        if (t.Tags.IndexOf(tag) != -1)
                            match = true;
                    }

                    if (!match)
                        SearchedMonuments.Remove(t);
                }
            }

            bool anyfilter = false;
            bool flag = true;
            if (id_f != -1)
            {
                anyfilter = true;
                if (t.Id != id_f)
                {
                    flag = false;
                }
            }

            if (name_f != "" && name_f != null)
            {
                anyfilter = true;
                if (!t.Name.ToLower().Contains(name_f.ToLower()))
                {
                    flag = false;
                }
            }

            if (typeName_f != -1 && typeName_f != null)
            {
                anyfilter = true;
                if (!t.Type.Id.Equals(typeName_f))
                {
                    flag = false;
                }
            }

            if (era_f != "" && era_f != "--" && era_f != null)
            {
                anyfilter = true;
                if (!t.Era.ToString().ToLower().Contains(era_f.ToLower()))
                {
                    flag = false;
                }
            }

            if (arch_f != -1)
            {
                anyfilter = true;
                bool match = false;
                if (arch_f == 1)
                    match = true;
                if (t.ArcheologicallyExplored != match)
                {
                    flag = false;
                }

            }

            if (unesco_f != -1)
            {
                anyfilter = true;
                bool match = false;
                if (unesco_f == 1)
                    match = true;
                if (t.Unesco != match)
                {
                    flag = false;
                }
            }

            if (populated_f != -1)
            {
                anyfilter = true;
                bool match = false;
                if (populated_f == 1)
                    match = true;
                if (t.PopulatedRegion != match)
                {
                    flag = false;
                }
            }

            if (touristicStatus_f != "" && touristicStatus_f != "--" && touristicStatus_f != null)
            {
                anyfilter = true;
                if (!t.TouristicStatus.ToString().ToLower().Contains(touristicStatus_f.ToLower()))
                {
                    flag = false;
                }
            }

            if (min_income_f != -1)
            {
                anyfilter = true;
                if (t.Income < min_income_f)
                {
                    flag = false;
                }
            }

            if (max_income_f != -1)
            {
                anyfilter = true;
                if (t.Income > max_income_f)
                {
                    flag = false;
                }

            }

            if (tags_f != null)
            {
                if (tags_f.Count != 0)
                {
                    anyfilter = true;
                    bool match = false;
                    foreach (var tag in tags_f)
                    {
                        if (t.Tags.IndexOf(tag) != -1)
                            match = true;
                    }

                    if (!match)
                        flag = false;
                }
            }

            if (anyfilter && flag)
            {
                int idxf = this.FilteredMonuments.IndexOf(t);
                this.FilteredMonuments[idxf].Name = t.Name;
                this.FilteredMonuments[idxf].Description = t.Description;
                this.FilteredMonuments[idxf].Image = t.Image;
                this.FilteredMonuments[idxf].Type = t.Type;
                this.FilteredMonuments[idxf].Era = t.Era;
                this.FilteredMonuments[idxf].Icon = t.Icon;
                this.FilteredMonuments[idxf].ArcheologicallyExplored = t.ArcheologicallyExplored;
                this.FilteredMonuments[idxf].Unesco = t.Unesco;
                this.FilteredMonuments[idxf].PopulatedRegion = t.PopulatedRegion;
                this.FilteredMonuments[idxf].TouristicStatus = t.TouristicStatus;
                this.FilteredMonuments[idxf].Income = t.Income;
                this.FilteredMonuments[idxf].DiscoveryDate = t.DiscoveryDate;
                this.FilteredMonuments[idxf].Tags = t.Tags;
            }
            else if (!anyfilter)
                this.FilteredMonuments = new ObservableCollection<Monument>();

            this.SearchedNFMonuments = new ObservableCollection<Monument>(this.SearchedMonuments.Except(this.FilteredMonuments));

            if (MonumentTable.EnlargenedMonuments.Contains(t.Id))
            {
                MonumentTable.monumentClicked(t.Id);
                MonumentTable.monumentClicked(t.Id);
            }
            SaveData();
            return t;

        }

        Monument findMonument(int id)
        {
            foreach (var m in this.Monuments)
            {
                if (m.Id == id)
                {
                    return m;
                }
            }
            return null;
        }

        void findMonuments(
            int id,
            string name,
            int typeName,
            string era,
            int arch,
            int unesco,
            int populated,
            string touristicStatus,
            int min_income,
            int max_income,
            List<Tag> tags
            )
        {
            this.id_s = id;
            this.name_s = name;
            this.typeName_s = typeName;
            this.era_s = era;
            this.arch_s = arch;
            this.unesco_s = unesco;
            this.populated_s = populated;
            this.touristicStatus_s = touristicStatus;
            this.min_income_s = min_income;
            this.max_income_s = max_income;
            this.tags_s = tags;
            List<Monument> sMonuments = new List<Monument>(this.Monuments);
            foreach (var monument in this.Monuments)
            {
                if (id != -1)
                {
                    if (monument.Id != id)
                    {
                        sMonuments.Remove(monument);
                    }
                }

                if (name != "" && name != null)
                {
                    if (!monument.Name.ToLower().Contains(name.ToLower()))
                    {
                        sMonuments.Remove(monument);
                    }
                }

                if (typeName != -1)
                {
                    if (!monument.Type.Id.Equals(typeName))
                    {
                        sMonuments.Remove(monument);
                    }
                }

                if (era != "--" && era != "" && era != null)
                {
                    if (!monument.Era.ToString().ToLower().Contains(era.ToLower()))
                    {
                        sMonuments.Remove(monument);
                    }
                }

                if (arch != -1 && arch != null)
                {
                    bool match = false;
                    if (arch == 1)
                        match = true;
                    if (monument.ArcheologicallyExplored != match)
                    {
                        sMonuments.Remove(monument);
                    }

                }

                if (unesco != -1 && unesco != null)
                {
                    bool match = false;
                    if (unesco == 1)
                        match = true;
                    if (monument.Unesco != match)
                    {
                        sMonuments.Remove(monument);
                    }
                }

                if (populated != -1 && populated != null)
                {
                    bool match = false;
                    if (populated == 1)
                        match = true;
                    if (monument.PopulatedRegion != match)
                    {
                        sMonuments.Remove(monument);
                    }
                }

                if (touristicStatus != "" && touristicStatus != null)
                {
                    if (!monument.TouristicStatus.ToString().ToLower().Contains(touristicStatus.ToLower()))
                    {
                        sMonuments.Remove(monument);
                    }
                }

                if (min_income != -1 && min_income != null)
                {
                    if (monument.Income < min_income)
                    {
                        sMonuments.Remove(monument);
                    }
                }

                if (max_income != -1 && max_income != null)
                {
                    if (monument.Income > max_income)
                    {
                        sMonuments.Remove(monument);
                    }

                }

                if (tags != null)
                {
                    if (tags.Count != 0)
                    {
                        bool match = false;
                        foreach (var t in tags)
                        {
                            if (monument.Tags.IndexOf(t) != -1)
                                match = true;
                        }

                        if (!match)
                            sMonuments.Remove(monument);
                    }
                }

            }


            this.SearchedMonuments = new ObservableCollection<Monument>(sMonuments);
            filterMonuments(id_f, name_f, typeName_f, era_f, arch_f, unesco_f, populated_f, touristicStatus_f, min_income_f, max_income_f, tags_f);
            this.SearchedNFMonuments = new ObservableCollection<Monument>(this.SearchedMonuments.Except(this.FilteredMonuments));
            
            if (MonumentTable.EnlargenedMonuments.Count > 0)
            {
                int monumentId = MonumentTable.EnlargenedMonuments[0];
                MonumentTable.monumentClicked(monumentId);
                MonumentTable.monumentClicked(monumentId);

                if (!MonumentTable.ScrollToSelected())
                {
                    MonumentTable.ScrollToTop();
                }
            } else
            {
                MonumentTable.ScrollToTop();
            }

        }


        //SLJUUUUN
        public void removeTagFromMonuments(string tagId)
        {
            Tag t = Tags.SingleOrDefault(x => x.Id == tagId);
            if (t == null)
            {
                return;
            }

            foreach (Monument m in this.Monuments)
            {

                Monument newMonumnet = m;
                if (newMonumnet.Tags.Remove(t))
                    this.editMonument(newMonumnet);
            }
        }


        // DO NOT USE, COMPILER WILL REMOVE eXcesS CODE
        public void cascadeRemoveTag(Tag t)
        {
            List<Monument> toRemove = new List<Monument>();
            foreach(Monument m in this.Monuments)
            {
                
                if (m.Tags.Remove(t))
                {
                    toRemove.Add(m);
                }
            }
            foreach(Monument m in toRemove)
            {
                this.removeMonument(m.Id);
                //this.Monuments.Remove(m);
            }
        }

        public void removeTypeAndMonuments(int typeId)
        {
            Type t = Types.SingleOrDefault(x => x.Id == typeId);
            if (t == null)
            {
                return;
            }

            List<Monument> toRemove = new List<Monument>();
            foreach (Monument m in this.Monuments)
            {
                if (m.Type == t)
                {
                    toRemove.Add(m);
                }
            }
            foreach (Monument m in toRemove)
            {
                this.removeMonument(m.Id);
            }
        }

        public bool checkIfTagReferenced(Tag t)
        {
            foreach(Monument m in this.Monuments)
            {
                if (m.Tags.Contains(t))
                {
                    return true;
                }
            }
            return false;
        }

        public bool checkIfTypeReferences(Type t)
        {
            foreach(Monument m in this.Monuments)
            {
                if (m.Type == t)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Monument> tagConflictingMonuments(string tagId)
        {
            Tag t = Tags.SingleOrDefault(x => x.Id == tagId);
            if (t == null)
            {
                return null;
            }

            List<Monument> retVal = new List<Monument>();
            foreach(Monument m in this.Monuments)
            {
                if (m.Tags.Contains(t))
                {
                    retVal.Add(m);
                }
            }
            if (retVal.Count == 0)
            {
                retVal = null;
            }
            return retVal;
        }

        public List<Monument> typeConflictingMonuments(int typeId)
        {
            Type t = Types.SingleOrDefault(x => x.Id == typeId);
            if (t == null)
            {
                return null;
            }

            List<Monument> retVal = new List<Monument>();
            foreach(Monument m in this.Monuments)
            {
                if (m.Type == t)
                {
                    retVal.Add(m);
                }
            }
            if (retVal.Count == 0)
            {
                retVal = null;
            }
            return retVal;
        }
        //SLJUUUUUN OUT

        void filterMonuments(
            int id,
            string name,
            int typeName,
            string era,
            int arch,
            int unesco,
            int populated,
            string touristicStatus,
            int min_income,
            int max_income,
            List<Tag> tags
            )
        {
            this.id_f = id;
            this.name_f = name;
            this.typeName_f = typeName;
            this.era_f = era;
            this.arch_f = arch;
            this.unesco_f = unesco;
            this.populated_f = populated;
            this.touristicStatus_f = touristicStatus;
            this.min_income_f = min_income;
            this.max_income_f = max_income;
            this.tags_f = tags;

            List<Monument> fMonuments = new List<Monument>(this.SearchedMonuments);
            bool anyfilter = false;
            foreach (var monument in this.SearchedMonuments)
            {
                if (id != -1)
                {
                    anyfilter = true;
                    if (monument.Id != id)
                    {
                        fMonuments.Remove(monument);
                    }
                }

                if (name != "" && name != null)
                {
                    anyfilter = true;
                    if (!monument.Name.ToLower().Contains(name.ToLower()))
                    {
                        fMonuments.Remove(monument);
                    }
                }

                if (typeName != -1 && typeName != null)
                {
                    anyfilter = true;
                    if (!monument.Type.Id.Equals(typeName))
                    {
                        fMonuments.Remove(monument);
                    }
                }

                if (era != "" && era != "--" && era != null)
                {
                    anyfilter = true;
                    if (!monument.Era.ToString().ToLower().Contains(era.ToLower()))
                    {
                        fMonuments.Remove(monument);
                    }
                }

                if (arch != -1)
                {
                    anyfilter = true;
                    bool match = false;
                    if (arch == 1)
                        match = true;
                    if (monument.ArcheologicallyExplored != match)
                    {
                        fMonuments.Remove(monument);
                    }

                }

                if (unesco != -1)
                {
                    anyfilter = true;
                    bool match = false;
                    if (unesco == 1)
                        match = true;
                    if (monument.Unesco != match)
                    {
                        fMonuments.Remove(monument);
                    }
                }

                if (populated != -1)
                {
                    anyfilter = true;
                    bool match = false;
                    if (populated == 1)
                        match = true;
                    if (monument.PopulatedRegion != match)
                    {
                        fMonuments.Remove(monument);
                    }
                }

                if (touristicStatus != "" && touristicStatus != "--" && touristicStatus != null)
                {
                    anyfilter = true;
                    if (!monument.TouristicStatus.ToString().ToLower().Contains(touristicStatus.ToLower()))
                    {
                        fMonuments.Remove(monument);
                    }
                }

                if (min_income != -1)
                {
                    anyfilter = true;
                    if (monument.Income < min_income)
                    {
                        fMonuments.Remove(monument);
                    }
                }

                if (max_income != -1)
                {
                    anyfilter = true;
                    if (monument.Income > max_income)
                    {
                        fMonuments.Remove(monument);
                    }

                }

                if (tags != null)
                {
                    if (tags.Count != 0)
                    {
                        anyfilter = true;
                        bool match = false;
                        foreach (var t in tags)
                        {
                            if (monument.Tags.IndexOf(t) != -1)
                                match = true;
                        }

                        if (!match)
                            fMonuments.Remove(monument);
                    }
                }

            }

            if (anyfilter)
                this.FilteredMonuments = new ObservableCollection<Monument>(fMonuments);
            else
                this.FilteredMonuments = new ObservableCollection<Monument>();
            this.SearchedNFMonuments = new ObservableCollection<Monument>( this.SearchedMonuments.Except(this.FilteredMonuments));


            if (MonumentTable.EnlargenedMonuments.Count > 0)
            {
                int monumentId = MonumentTable.EnlargenedMonuments[0];
                MonumentTable.monumentClicked(monumentId);
                MonumentTable.monumentClicked(monumentId);

                if (!MonumentTable.ScrollToSelected())
                {
                    MonumentTable.ScrollToTop();
                }
            }
            else
            {
                MonumentTable.ScrollToTop();
            }
        }

        #endregion

        #region Type
        public delegate Type onAddType(Type t);
        public delegate Type onRemoveType(int id);
        public delegate Type onEditType(Type t);
        public delegate Type onFindType(int id);


        public onAddType addTypeCallback { get; set; }
        public onRemoveType removeTypeCallback { get; set; }
        public onEditType editTypeCallback { get; set; }
        public onFindType findTypeCallback { get; set; }

        Type addType(Type t)
        {
            this.Types.Add(t);
            SaveData();
            return t;
        }

        Type removeType(int id)
        {
            foreach (var t in this.Types)
            {
                if (t.Id == id)
                {
                    this.Types.Remove(t);
                    SaveData();
                    return t;
                }
            }
            return null;
        }

        Type editType(Type t)
        {
            int idx = this.Types.IndexOf(t);
            if (idx == -1)
                return null;
            this.Types[idx].Name = t.Name;
            this.Types[idx].Description = t.Description;
            this.Types[idx].Icon = t.Icon;

            SaveData();
            return t;
        }

        Type findType(int id)
        {
            foreach (var t in this.Types)
            {
                if (t.Id == id)
                    return t;
            }
            return null;
        }

        #endregion

        #region Tag
        public delegate Tag onAddTag(Tag t);
        public delegate Tag onRemoveTag(string id);
        public delegate Tag onEditTag(Tag t);
        public delegate Tag onFindTag(string id);


        public onAddTag addTagCallback { get; set; }
        public onRemoveTag removeTagCallback { get; set; }
        public onEditTag editTagCallback { get; set; }
        public onFindTag findTagCallback { get; set; }

        Tag addTag(Tag t)
        {
            this.tags.Add(t);
            SaveData();
            return t;
        }

        Tag removeTag(string id)
        {
            foreach (var t in this.tags)
            {
                if (t.Id == id)
                {
                    this.tags.Remove(t);
                    SaveData();
                    return t;
                }
            }
            return null;
        }

        Tag editTag(Tag t)
        {
            int idx = this.Tags.IndexOf(t);
            if (idx == -1)
                return null;
            this.Tags[idx].Description = t.Description;
            this.Tags[idx].Color = t.Color;

            SaveData();
            return t;
        }

        Tag findTag(string id)
        {
            foreach (var t in this.tags)
            {
                if (t.Id == id)
                    return t;
            }
            return null;
        }


        #endregion

        #region MenuActions

        public void types_Click(object sender, RoutedEventArgs e)
        {
            TypeSection typeSectionDialog = new TypeSection(Types, addTypeCallback, editTypeCallback, removeTypeCallback);
            typeSectionDialog.Owner = Application.Current.MainWindow;
            typeSectionDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            typeSectionDialog.Width = 700;
            typeSectionDialog.Height = 800;
            typeSectionDialog.ShowDialog();
        }

        public void tags_Click(object sender, RoutedEventArgs e)
        {
            TagSection tagSectionDialog = new TagSection(Tags, addTagCallback, editTagCallback, removeTagCallback);

            tagSectionDialog.Owner = Application.Current.MainWindow;
            tagSectionDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            tagSectionDialog.Width = 700;
            tagSectionDialog.Height = 800;
            tagSectionDialog.ShowDialog();
        }

        public void monumentAdd_Click(object sender, RoutedEventArgs e)
        {
            AddMonument addMonumentDialog = new emlekmu.AddMonument(Monuments, Types, Tags, addMonumentCallback, addTypeCallback, addTagCallback);
            addMonumentDialog.Owner = Application.Current.MainWindow;
            addMonumentDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addMonumentDialog.Height = 610;
            addMonumentDialog.Width = 800;
            addMonumentDialog.ShowDialog();
        }

        public void tagAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTag addTagDialog = new AddTag(addTagCallback, Tags);
            addTagDialog.Owner = Application.Current.MainWindow;
            addTagDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addTagDialog.Height = 590;
            addTagDialog.Width = 450;
            addTagDialog.ShowDialog();
        }

        public void typeAdd_Click(object sender, RoutedEventArgs e)
        {
            AddType addTypeDialog = new AddType(addTypeCallback, Types);
            addTypeDialog.Height = 590;
            addTypeDialog.Owner = Application.Current.MainWindow;
            addTypeDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addTypeDialog.MinHeight = 535;
            addTypeDialog.Width = 450;
            addTypeDialog.MinWidth = 250;
            addTypeDialog.ShowDialog();
        }

        #endregion

        #region DialogCallback
        public delegate Monument onOpenEditMonument(int monumentId);
        public onOpenEditMonument openEditMonumentCallback { get; set; }

        public Monument openEditMonument(int monumentId)
        {
            Monument monumentToEdit = Monuments.SingleOrDefault(x => x.Id == monumentId);

            EditMonument editMonumentDialog = new EditMonument(Types, Tags, editMonumentCallback, monumentToEdit, addTypeCallback, addTagCallback);
            editMonumentDialog.Owner = Application.Current.MainWindow;
            editMonumentDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            editMonumentDialog.Height = 560;
            editMonumentDialog.Width = 800;
            editMonumentDialog.MinHeight = 560;
            editMonumentDialog.MinWidth = 800;
            editMonumentDialog.ShowDialog();

            if (editMonumentDialog.DialogResult.HasValue && editMonumentDialog.DialogResult.Value)
            {
                return editMonumentDialog.NewMonument;
            } else
            {
                return null;
            }
        }

        public delegate Monument onOpenAddMonument();
        public onOpenAddMonument openAddMonumentCallback { get; set; }

        public Monument openAddMonument()
        {
            AddMonument addMonumentDialog = new AddMonument(Monuments,
                Types, Tags, addMonumentCallback, addTypeCallback, addTagCallback);
            addMonumentDialog.Owner = Application.Current.MainWindow;
            addMonumentDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addMonumentDialog.Height = 560;
            addMonumentDialog.Width = 800;
            addMonumentDialog.MinHeight = 560;
            addMonumentDialog.MinWidth = 800;

            addMonumentDialog.ShowDialog();

            if (addMonumentDialog.DialogResult.HasValue && addMonumentDialog.DialogResult.Value)
            {
                return addMonumentDialog.Monument;
            } else
            {
                return null;
            }

        }

        public delegate void onOpenMonumentDetail(int monumentId);
        public onOpenMonumentDetail openMonumentDetailCallback { get; set;}

        public void openMonumentDetail(int monumentId)
        {
            Monument monument = Monuments.SingleOrDefault(x => x.Id == monumentId);
            MonumentDetail mdDialog = new MonumentDetail(monument);
            mdDialog.Owner = Application.Current.MainWindow;
            mdDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            mdDialog.Height = 590;
            mdDialog.Width = 890;
            mdDialog.MinHeight = 590;
            mdDialog.MinWidth = 890;
            mdDialog.ShowDialog();
        }

        #endregion

        #region Mouse

        //for status bar
        public string mousePositionXText;

        public string MousePositionXText
        {
            get
            {
                return mousePositionXText;
            }
            set
            {
                if (value != mousePositionXText)
                {
                    mousePositionXText = value;
                    OnPropertyChanged("MousePositionXText");
                }
            }
        }


        public string mousePositionYText;

        public string MousePositionYText
        {
            get
            {
                return mousePositionYText;
            }
            set
            {
                if (value != mousePositionYText)
                {
                    mousePositionYText = value;
                    OnPropertyChanged("MousePositionYText");
                }
            }
        }

        #endregion

        public ObservableCollection<int> EnlargenedMonuments
        {
            get { return (ObservableCollection<int>)GetValue(EnlargenedMonumentsProperty); }
            set { SetValue(EnlargenedMonumentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnlargenedMonuments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnlargenedMonumentsProperty =
            DependencyProperty.Register("EnlargenedMonuments", typeof(ObservableCollection<int>), typeof(MainContent), new PropertyMetadata(new ObservableCollection<int>()));

        //CONSTRUCTOR!!!!
        public MainContent()
        {
            MyMap = new MapEurope();
            RESOURCES_PATH = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString() + "\\resources\\";

            //DataGraph dataGraph = CsvParser.readCSV();
            //XmlParser.serialize(dataGraph);
            //MapPosDG mp = new MapPosDG();
            //XmlParser.serMapPog(mp);

            DataGraph dataGraph = XmlParser.deserialize();
            
            InitializeComponent();



            Root.DataContext = this;
            // data initialization
            this.id_s = -1;
            this.min_income_s = -1;
            this.max_income_s = -1;
            this.typeName_s = -1;
            this.arch_s = -1;
            this.unesco_s = -1;
            this.populated_s = -1;

            this.id_f = -1;
            this.min_income_f = -1;
            this.max_income_f = -1;
            this.typeName_f = -1;
            this.arch_f = -1;
            this.unesco_f = -1;
            this.populated_f = -1;


            Types = new ObservableCollection<Type>(dataGraph.types);
            Monuments = new ObservableCollection<Monument>(dataGraph.monuments);
            Tags = new ObservableCollection<models.Tag>(dataGraph.tags);
            List<Monument> lm = new List<Monument>(Monuments);
            MapPosDG mpdg = XmlParser.desMapPog(lm);

            Map1Monuments = new ObservableCollection<MonumentPosition>(mpdg.map1Monuments);
            Map2Monuments = new ObservableCollection<MonumentPosition>(mpdg.map2Monuments);
            Map3Monuments = new ObservableCollection<MonumentPosition>(mpdg.map3Monuments);
            Map4Monuments = new ObservableCollection<MonumentPosition>(mpdg.map4Monuments);
            

            this.SearchedMonuments = new ObservableCollection<Monument>(this.Monuments);
            this.FilteredMonuments = new ObservableCollection<Monument>();
            this.searchedNFMonuments = new ObservableCollection<Monument>(this.Monuments);
            // Tag callback initialization
            this.addTagCallback = new onAddTag(addTag);
            this.removeTagCallback = new onRemoveTag(removeTag);
            this.editTagCallback = new onEditTag(editTag);
            this.findTagCallback = new onFindTag(findTag);

            // Type callback initialization
            this.addTypeCallback = new onAddType(addType);
            this.removeTypeCallback = new onRemoveType(removeType);
            this.editTypeCallback = new onEditType(editType);
            this.findTypeCallback = new onFindType(findType);

            // Monument callback initialization
            this.addMonumentCallback = new onAddMonument(addMonument);
            this.removeMonumentCallback = new onRemoveMonument(removeMonument);
            this.editMonumentCallback = new onEditMonument(editMonument);
            this.findMonumentCallback = new onFindMonument(findMonument);
            this.findMonumentsCallback = new onFindMonuments(findMonuments);
            this.filterMonumentsCallback = new onFilterMonuments(filterMonuments);
            this.monumentSelectionChangedCallback = new onMonumentSelectionChanged(MonumentSelectionChanged);

            // Dialog callback initialization
            this.openEditMonumentCallback = new onOpenEditMonument(openEditMonument);
            this.openAddMonumentCallback = new onOpenAddMonument(openAddMonument);
            this.openMonumentDetailCallback = new onOpenMonumentDetail(openMonumentDetail);
            // pin click callback
            this.pinClickedCallback = new onPinClicked(pinClicked);


            // save map data callback
            this.mapSaveCallback = new onMapSave(SaveMapData) ;
        }

        private void EditFirstMonument_Click(object sender, RoutedEventArgs e)
        {
            EditMonument dialog = new EditMonument(Types, Tags, this.editMonumentCallback, this.Monuments.First(), addTypeCallback, addTagCallback);
            dialog.Height = 610;
            dialog.Width = 800;
            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.ShowDialog();
        }
        

        private void Map1Tab_PreviewDragEnter(object sender, DragEventArgs e)
        {
             MapsContainer.SelectedIndex = 0;
        } 
        private void Map2Tab_PreviewDragEnter(object sender, DragEventArgs e)
        {

            MapsContainer.SelectedIndex = 1;
        }

        private void Map3Tab_PreviewDragEnter(object sender, DragEventArgs e)
        {
            MapsContainer.SelectedIndex = 2;
        }

        private void Map4Tab_PreviewDragEnter(object sender, DragEventArgs e)
        {
            MapsContainer.SelectedIndex = 3;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (SearchFilter == "Search")
            {
                if (SFControl.Visibility == Visibility.Collapsed)
                {
                    Search.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(204, 238, 255));
                    Search.BorderThickness = new Thickness(1, 1, 1, 0);
                    Filter.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                    Filter.BorderThickness = new Thickness(1, 1, 1, 1);
                    SFControl.Visibility = Visibility.Visible;
                } else
                {
                    Search.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                    Search.BorderThickness = new Thickness(1, 1, 1, 1);
                    Filter.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                    Filter.BorderThickness = new Thickness(1, 1, 1, 1);
                    SFControl.Visibility = Visibility.Collapsed;
                }
            } else
            {
                SearchFilter = "Search";
                Search.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(204, 238, 255));
                Search.BorderThickness = new Thickness(1, 1, 1, 0);
                Filter.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                Filter.BorderThickness = new Thickness(1, 1, 1, 1);
                SFControl.Visibility = Visibility.Visible;
            }
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            if (SearchFilter == "Filter")
            {
                if (SFControl.Visibility == Visibility.Collapsed)
                {
                    Filter.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(204, 238, 255));
                    Filter.BorderThickness = new Thickness(1, 1, 1, 0);
                    Search.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                    Search.BorderThickness = new Thickness(1, 1, 1, 1);
                    SFControl.Visibility = Visibility.Visible;
                }
                else
                {
                    Filter.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                    Filter.BorderThickness = new Thickness(1, 1, 1, 1);
                    Search.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                    Search.BorderThickness = new Thickness(1, 1, 1, 1);
                    SFControl.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                SearchFilter = "Filter";
                Filter.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(204, 238, 255));
                Filter.BorderThickness = new Thickness(1, 1, 1, 0);
                Search.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                Search.BorderThickness = new Thickness(1, 1, 1, 1);
                SFControl.Visibility = Visibility.Visible;
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public void SaveData()
        {
            DataGraph dg = new DataGraph();
            dg.monuments = new List<Monument>(Monuments);
            dg.types = new List<Type>(Types);
            dg.tags = new List<Tag>(Tags);

            XmlParser.serialize(dg);
        }

        public void SaveMapData()
        {
            MapPosDG mpdg = new MapPosDG();
            mpdg.map1Monuments = new List<MonumentPosition>(Map1Monuments);
            mpdg.map2Monuments = new List<MonumentPosition>(Map2Monuments);
            mpdg.map3Monuments = new List<MonumentPosition>(Map3Monuments);
            mpdg.map4Monuments = new List<MonumentPosition>(Map4Monuments);

            XmlParser.serMapPog(mpdg);
        }
    }
}