using emlekmu.models;
using emlekmu.models.IO;
using System;
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
using Type = emlekmu.models.Type;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for MainContent.xaml
    /// </summary>
    public partial class MainContent : UserControl, INotifyPropertyChanged
    {
        #region Data

        

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Type> types;
        public ObservableCollection<Type> Types {
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
        #endregion

        #region Search parameters
        int id_s;
        string name_s;
        string typeName_s;
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
        string typeName_f;
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
        ObservableCollection<Monument> monuments;
            ObservableCollection<Monument> searchedMonuments;
            ObservableCollection<Monument> filteredMonuments;

            ObservableCollection<Tag> tags;
        
        #endregion
        #region Monument
        public delegate Monument onAddMonument(Monument m);
        public delegate Monument onRemoveMonument(int id);
        public delegate Monument onEditMonument(Monument m);
        public delegate Monument onFindMonument(int id);
        public delegate void onFindMonuments(int id, string name, string typeName, string era, int arch, int unesco, int populated, string touristicStatus, int min_income, int max_income, List<Tag> tags);
        public delegate void onFilterMonuments(int id, string name, string typeName, string era, int arch, int unesco, int populated, string touristicStatus, int min_income, int max_income, List<Tag> tags);


        public onAddMonument addMonumentCallback { get; set; }
        public onRemoveMonument removeMonumentCallback { get; set; }
        public onEditMonument editMonumentCallback { get; set; }
        public onFindMonument findMonumentCallback { get; set; }
        public onFindMonuments findMonumentsCallback { get; set; }
        public onFilterMonuments filterMonumentsCallback { get; set; }

        Monument addMonument(Monument t)
        {
            this.monuments.Add(t);
            this.findMonuments(
                this.id_s,
                this.name_s,
                this.typeName_s,
                this.era_s,
                this.arch_s,
                this.unesco_s,
                this.populated_s,
                this.touristicStatus_s,
                this.min_income_s,
                this.max_income_s,
                this.tags_s);
            this.filterMonuments(
                this.id_f,
                this.name_f,
                this.typeName_f,
                this.era_f,
                this.arch_f,
                this.unesco_f,
                this.populated_f,
                this.touristicStatus_f,
                this.min_income_f,
                this.max_income_f,
                this.tags_f);
            return t;
        }

        Monument removeMonument(int id)
        {
            foreach (var m in this.monuments)
            {
                if (m.Id == id)
                {
                    this.monuments.Remove(m);
                    this.findMonuments(
                        this.id_s,
                        this.name_s,
                        this.typeName_s,
                        this.era_s,
                        this.arch_s,
                        this.unesco_s,
                        this.populated_s,
                        this.touristicStatus_s,
                        this.min_income_s,
                        this.max_income_s,
                        this.tags_s);
                    this.filterMonuments(
                        this.id_f,
                        this.name_f,
                        this.typeName_f,
                        this.era_f,
                        this.arch_f,
                        this.unesco_f,
                        this.populated_f,
                        this.touristicStatus_f,
                        this.min_income_f,
                        this.max_income_f,
                        this.tags_f);
                    return m;
                }
            }
            return null;
        }

        Monument editMonument(Monument t)
        {
            if (this.monuments.Remove(t))
            {
                this.monuments.Add(t);
                this.findMonuments(
                    this.id_s,
                    this.name_s,
                    this.typeName_s,
                    this.era_s,
                    this.arch_s,
                    this.unesco_s,
                    this.populated_s,
                    this.touristicStatus_s,
                    this.min_income_s,
                    this.max_income_s,
                    this.tags_s);
                this.filterMonuments(
                    this.id_f,
                    this.name_f,
                    this.typeName_f,
                    this.era_f,
                    this.arch_f,
                    this.unesco_f,
                    this.populated_f,
                    this.touristicStatus_f,
                    this.min_income_f,
                    this.max_income_f,
                    this.tags_f);
                return t;
            }
            return null;
        }

        Monument findMonument(int id)
        {
            foreach (var m in this.monuments)
            {
                if(m.Id == id)
                {
                    return m;
                }
            }
            return null;
        }

        void findMonuments(
            int id,
            string name,
            string typeName,
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
            List<Monument> sMonuments = new List<Monument>(this.monuments);
            foreach (var monument in this.monuments)
            {
                if (id != -1)
                {
                    if(monument.Id != id)
                    {
                        sMonuments.Remove(monument);
                    }
                }

                if (name != "")
                {
                    if (!monument.Name.ToLower().Contains(name.ToLower()))
                    {
                        sMonuments.Remove(monument);
                    }
                }

                if (typeName != "")
                {
                    if(!monument.Type.Name.ToString().ToLower().Contains(typeName.ToLower()))
                    {
                        sMonuments.Remove(monument);
                    }
                }

                if (era != "")
                {
                    if (!monument.Era.ToString().ToLower().Contains(era.ToLower()))
                    {
                        sMonuments.Remove(monument);
                    }
                }

                if (arch != -1)
                {
                    bool match = false;
                    if (arch == 1)
                        match = true;
                    if (monument.ArcheologicallyExplored != match)
                    {
                        sMonuments.Remove(monument);
                    }

                }

                if (unesco != -1)
                {
                    bool match = false;
                    if (unesco == 1)
                        match = true;
                    if (monument.Unesco != match)
                    {
                        sMonuments.Remove(monument);
                    }
                }
                
                if (populated != -1)
                {
                    bool match = false;
                    if (populated == 1)
                        match = true;
                    if (monument.PopulatedRegion != match)
                    {
                        sMonuments.Remove(monument);
                    }
                }

                if (touristicStatus != "")
                {
                    if (!monument.TouristicStatus.ToString().ToLower().Contains(touristicStatus.ToLower()))
                    {
                        sMonuments.Remove(monument);
                    }
                }

                if (min_income != -1)
                {
                    if(monument.Income < min_income)
                    {
                        sMonuments.Remove(monument);
                    }
                }

                if (max_income != -1)
                {
                    if (monument.Income > max_income)
                    {
                        sMonuments.Remove(monument);
                    }

                }
                
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

            this.searchedMonuments = new ObservableCollection<Monument>(sMonuments);
        }

        void filterMonuments(
            int id,
            string name,
            string typeName,
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
            List<Monument> fMonuments = new List<Monument>(this.searchedMonuments);
            foreach (var monument in this.searchedMonuments)
            {
                if (id != -1)
                {
                    if (monument.Id != id)
                    {
                        fMonuments.Remove(monument);
                    }
                }

                if (name != "")
                {
                    if (!monument.Name.ToLower().Contains(name.ToLower()))
                    {
                        fMonuments.Remove(monument);
                    }
                }

                if (typeName != "")
                {
                    if (!monument.Type.Name.ToString().ToLower().Contains(typeName.ToLower()))
                    {
                        fMonuments.Remove(monument);
                    }
                }

                if (era != "")
                {
                    if (!monument.Era.ToString().ToLower().Contains(era.ToLower()))
                    {
                        fMonuments.Remove(monument);
                    }
                }

                if (arch != -1)
                {
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
                    bool match = false;
                    if (populated == 1)
                        match = true;
                    if (monument.PopulatedRegion != match)
                    {
                        fMonuments.Remove(monument);
                    }
                }

                if (touristicStatus != "")
                {
                    if (!monument.TouristicStatus.ToString().ToLower().Contains(touristicStatus.ToLower()))
                    {
                        fMonuments.Remove(monument);
                    }
                }

                if (min_income != -1)
                {
                    if (monument.Income < min_income)
                    {
                        fMonuments.Remove(monument);
                    }
                }

                if (max_income != -1)
                {
                    if (monument.Income > max_income)
                    {
                        fMonuments.Remove(monument);
                    }

                }

                if (tags.Count != 0)
                {
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

            this.searchedMonuments = new ObservableCollection<Monument>(fMonuments);
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
            this.types.Add(t);
            return t;
        }

        Type removeType(int id)
        {
            foreach (var t in this.types)
            {
                if (t.Id == id)
                {
                    this.types.Remove(t);
                    return t;
                }
            }
            return null;
        }

        Type editType(Type t)
        {
            if (this.types.Remove(t))
            {
                this.types.Add(t);
                return t;
            }
            return null;
        }

        Type findType(int id)
        {
            foreach (var t in this.types)
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
            return t;
        }

        Tag removeTag(string id)
        {
            foreach (var t in this.tags)
            {
                if (t.Id == id)
                {
                    this.tags.Remove(t);
                    return t;
                }
            }
            return null;
        }

        Tag editTag(Tag t)
        {
            if (this.tags.Remove(t))
            {
                this.tags.Add(t);
                return t;
            }
            return null;
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
        public MainContent()
        {

            InitializeComponent();

            Root.DataContext = this;
            // data initialization
            DataGraph dataGraph = XmlParser.deserialize();
            Types = new ObservableCollection<Type>(dataGraph.types);

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
        }

    }
}
