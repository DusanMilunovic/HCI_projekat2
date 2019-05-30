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
using Type = emlekmu.models.Type;
using Color = emlekmu.models.Color;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for MainContent.xaml
    /// </summary>
    /// 
   
    public partial class MainContent : UserControl, INotifyPropertyChanged
    {
        #region Event listeners
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
                    OnPropertyChanged("SearchedMonuments");
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
            this.Monuments.Add(t);
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
            foreach (var m in this.Monuments)
            {
                if (m.Id == id)
                {
                    this.Monuments.Remove(m);
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
            int idx = this.Monuments.IndexOf(t);
            if (idx == -1)
                return null;
            this.Monuments[idx].Name = t.Name;
            this.Monuments[idx].Description = t.Description;
            this.Monuments[idx].Icon = t.Icon;
            
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

                if (name != "")
                {
                    if (!monument.Name.ToLower().Contains(name.ToLower()))
                    {
                        sMonuments.Remove(monument);
                    }
                }

                if (typeName != "")
                {
                    if (!monument.Type.Name.ToString().ToLower().Contains(typeName.ToLower()))
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
                    if (monument.Income < min_income)
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

                if (Tags.Count != 0)
                {
                    bool match = false;
                    foreach (var t in Tags)
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

                if (Tags.Count != 0)
                {
                    bool match = false;
                    foreach (var t in Tags)
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
            this.Types.Add(t);
            return t;
        }

        Type removeType(int id)
        {
            foreach (var t in this.Types)
            {
                if (t.Id == id)
                {
                    this.Types.Remove(t);
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
            int idx = this.Tags.IndexOf(t);
            if (idx == -1)
                return null;
            this.Tags[idx].Description = t.Description;
            this.Tags[idx].Color = t.Color;

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
            typeSectionDialog.Width = 725;
            typeSectionDialog.Height = 800;
            typeSectionDialog.ShowDialog();
        }

        public void tags_Click(object sender, RoutedEventArgs e)
        {
            TagSection tagSectionDialog = new TagSection(Tags, addTagCallback, editTagCallback, removeTagCallback);

            tagSectionDialog.ShowDialog();
        }

        public void monumentAdd_Click(object sender, RoutedEventArgs e)
        {
            AddMonument addMonumentDialog = new emlekmu.AddMonument(Monuments, Types, Tags, addMonumentCallback, addTypeCallback);
            addMonumentDialog.Height = 750;
            addMonumentDialog.Width = 400;
            addMonumentDialog.ShowDialog();
        }

        public void tagAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        public void typeAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion
        public MainContent()
        {
            Tags = new ObservableCollection<Tag>();

            this.Tags.Add(new Tag("Good1", new Color(0, 100, 166), "Very good tag"));
            this.Tags.Add(new Tag("GRood2", new Color(100, 0, 166), "Very grood tag"));
            this.Tags.Add(new Tag("GRooden3", new Color(100, 166, 0), "Very grooden tag"));
            this.Tags.Add(new Tag("Good4", new Color(100, 100, 166), "Even verier good tag"));
            this.Tags.Add(new Tag("GRood5", new Color(100, 100, 166), "Even verier grood tag"));
            this.Tags.Add(new Tag("GRoode6n", new Color(100, 166, 100), "Even verier grooden tag"));
            this.Tags.Add(new Tag("Good7", new Color(45, 100, 166), "Even verier beste tag"));
            this.Tags.Add(new Tag("GRood8", new Color(130, 207, 166), "Even verier bestere tag"));
            this.Tags.Add(new Tag("GRoode9n", new Color(114, 20, 35), "Even verier besterederen tag"));
            this.Tags.Add(new Tag("Good0", new Color(66, 100, 200), "Even verier more grood beste tag"));
            this.Tags.Add(new Tag("GRood11", new Color(70, 100, 50), "Even verier more grooder beste tag"));
            this.Tags.Add(new Tag("GRoode12n", new Color(20, 30, 20), "Even verier more grooderen bestere tagEven verier more groven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more oderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more ven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tag"));
            RESOURCES_PATH = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString() + "\\resources\\";

            this.Tags.Add(new Tag("Good", new Color(0, 100, 166), "Very good tag"));
            this.Tags.Add(new Tag("GRood", new Color(100, 0, 166), "Very grood tag"));
            this.Tags.Add(new Tag("GRooden", new Color(100, 166, 0), "Very grooden tag"));
            this.Tags.Add(new Tag("Good1", new Color(100, 100, 166), "Even verier good tag"));
            this.Tags.Add(new Tag("GRood1", new Color(100, 100, 166), "Even verier grood tag"));
            this.Tags.Add(new Tag("GRooden1", new Color(100, 166, 100), "Even verier grooden tag"));
            this.Tags.Add(new Tag("Good2", new Color(45, 100, 166), "Even verier beste tag"));
            this.Tags.Add(new Tag("GRood2", new Color(130, 207, 166), "Even verier bestere tag"));
            this.Tags.Add(new Tag("GRooden2", new Color(114, 20, 35), "Even verier besterederen tag"));
            this.Tags.Add(new Tag("Good3", new Color(66, 100, 200), "Even verier more grood beste tag"));
            this.Tags.Add(new Tag("GRood3", new Color(70, 100, 50), "Even verier more grooder beste tag"));
            this.Tags.Add(new Tag("GRooden3", new Color(20, 30, 20), "Even verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tagEven verier more grooderen bestere tag"));
            InitializeComponent();



            Root.DataContext = this;
            // data initialization
            DataGraph dataGraph = XmlParser.deserialize();

            Types = new ObservableCollection<Type>(dataGraph.types);
            Monuments = new ObservableCollection<Monument>(dataGraph.monuments);

            Monuments[0].Tags.Add(this.Tags[0]);
            Monuments[0].Tags.Add(this.Tags[1]);
            Monuments[0].Tags.Add(this.Tags[2]);
            Monuments[0].Tags.Add(this.Tags[3]);
            Monuments[0].Tags.Add(this.Tags[4]);
            Monuments[1].Tags.Add(this.Tags[1]);
            Monuments[1].Tags.Add(this.Tags[2]);
            Monuments[6].Tags.Add(this.Tags[3]);
            Monuments[6].Tags.Add(this.Tags[6]);
            Monuments[2].Tags.Add(this.Tags[7]);
            Monuments[3].Tags.Add(this.Tags[1]);
            Monuments[3].Tags.Add(this.Tags[2]);
            Monuments[3].Tags.Add(this.Tags[3]);
            Monuments[4].Tags.Add(this.Tags[3]);

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