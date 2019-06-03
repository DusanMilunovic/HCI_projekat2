using System;
using System.Collections.Generic;
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
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Collections.ObjectModel;

using Type = emlekmu.models.Type;
using emlekmu.models;
using static emlekmu.MainContent;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for SearchFilterControl.xaml
    /// </summary>
    public partial class SearchFilterControl : UserControl, INotifyPropertyChanged
    {


        public onFindMonuments SearchCallback
        {
            get { return (onFindMonuments)GetValue(SearchCallbackProperty); }
            set { SetValue(SearchCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SearchCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchCallbackProperty =
            DependencyProperty.Register("SearchCallback", typeof(onFindMonuments), typeof(SearchFilterControl), new PropertyMetadata(null));





        public onFilterMonuments FilterCallback
        {
            get { return (onFilterMonuments)GetValue(FilterCallbackProperty); }
            set { SetValue(FilterCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilterCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilterCallbackProperty =
            DependencyProperty.Register("FilterCallback", typeof(onFilterMonuments), typeof(SearchFilterControl), new PropertyMetadata(null));



        public Type type;
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
        public ObservableCollection<Tag> Tags
        {
            get { return (ObservableCollection<Tag>)GetValue(TagsProperty); }
            set { SetValue(TagsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tags.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagsProperty =
            DependencyProperty.Register("Tags", typeof(ObservableCollection<Tag>), typeof(SearchFilterControl), new PropertyMetadata(null));



        public ObservableCollection<Type> Types
        {
            get { return (ObservableCollection<Type>)GetValue(TypesProperty); }
            set { SetValue(TypesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Types.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypesProperty =
            DependencyProperty.Register("Types", typeof(ObservableCollection<Type>), typeof(SearchFilterControl), new PropertyMetadata(null));


        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
       
        public string DialogType
        {
            get { return (string)GetValue(DialogTypeProperty); }
            set { SetValue(DialogTypeProperty, value); }
        }


        // Using a DependencyProperty as the backing store for DialogType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DialogTypeProperty =
            DependencyProperty.Register("DialogType", typeof(string), typeof(SearchFilterControl), new PropertyMetadata("Search"));

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public SearchFilterControl()
        {
            InitializeComponent();
            Root.DataContext = this;
        }

        public void resetTagFlags()
        {
            foreach (Tag t in this.Tags)
            {
                t.Selected = false;
            }
        }

        private void SearchFilterButton_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, int> magic = new Dictionary<string, int>();
            magic.Add("Yes", 1);
            magic.Add("No", 0);
            magic.Add("--", -1);

            int id;
            try
            {
                id = Convert.ToInt32(input_id.Text);
            }catch(Exception err)
            {
                id = -1;
            }
            string name = input_name.Text; int typeId;
            try { 
            typeId = ((Type)input_type.SelectedValue).Id;
            }
            catch (Exception err)
            {
                typeId = -1;
            }
            string era = input_era.Text.ToString();

                int arch = magic[input_archeological.Text.ToString()];


                int unesco = magic[input_unesco.Text.ToString()];

                int populated = magic[input_populated.Text.ToString()];
            string touristicStatus = input_touristic.Text.ToString(); int min_income;
            try
            {
                min_income = Convert.ToInt32(input_mini.Text);}catch(Exception err)
            {
                min_income = -1;
            }
            int max_income;
            try
            {
                max_income = Convert.ToInt32(input_maxi.Text);}catch(Exception err)
            {
                max_income = -1;
            }
            var tags = new List<Tag>();
            foreach (var item in TagListBox.SelectedItems)
            {
                tags.Add((Tag)item);
            }
            if (DialogType.Equals("Search"))
                SearchCallback(id, name, typeId, era, arch, unesco, populated, touristicStatus, min_income, max_income, tags);
            
            else
                FilterCallback(id, name, typeId, era, arch, unesco, populated, touristicStatus, min_income, max_income, tags);


        }

        private void Reset_era_Click(object sender, RoutedEventArgs e)
        {
            input_era.SelectedIndex = -1;
            input_era.SelectedItem = null;
            input_era.SelectedValue = null;
            input_era.Text = "";
        }

        private void Input_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (input_type.SelectedValue == null)
                Reset_type.IsEnabled = false;
            else
                Reset_type.IsEnabled = true;
        }

        private void Reset_type_Click(object sender, RoutedEventArgs e)
        {
            input_type.SelectedIndex = -1;
            input_type.SelectedItem = null;
            input_type.SelectedValue = null;
            input_type.Text = "";
        }

        private void Input_era_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (input_era.SelectedValue == null)
                Reset_era.IsEnabled = false;
            else
                Reset_era.IsEnabled = true;
        }

        private void Reset_touristic_Click(object sender, RoutedEventArgs e)
        {
            input_touristic.SelectedIndex = -1;
            input_touristic.SelectedItem = null;
            input_touristic.SelectedValue = null;
            input_touristic.Text = "";
        }
    }
}
