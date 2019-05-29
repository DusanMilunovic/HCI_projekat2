using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static emlekmu.MainContent;
using Type = emlekmu.models.Type;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for TypeSection.xaml
    /// </summary>
    public partial class TypeSection: Window
    {

        public onAddType AddTypeCallback
        {
            get { return (onAddType)GetValue(AddTypeCallbackProperty); }
            set { SetValue(AddTypeCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddTypeCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddTypeCallbackProperty =
            DependencyProperty.Register("AddTypeCallback", typeof(onAddType), typeof(TypeSection), new PropertyMetadata(null));



        public onEditType EditTypeCallback
        {
            get { return (onEditType)GetValue(EditTypeCallbackProperty); }
            set { SetValue(EditTypeCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditTypeCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditTypeCallbackProperty =
            DependencyProperty.Register("EditTypeCallback", typeof(onEditType), typeof(TypeSection), new PropertyMetadata(null));



        public onRemoveType RemoveTypeCallback
        {
            get { return (onRemoveType)GetValue(RemoveTypeCallbackProperty); }
            set { SetValue(RemoveTypeCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RemoveTypeCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RemoveTypeCallbackProperty =
            DependencyProperty.Register("RemoveTypeCallback", typeof(onRemoveType), typeof(TypeSection), new PropertyMetadata(null));




        public ObservableCollection<Type> Types
        {
            get { return (ObservableCollection<Type>)GetValue(TypesProperty); }
            set { SetValue(TypesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Types.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypesProperty =
            DependencyProperty.Register("Types", typeof(ObservableCollection<Type>), typeof(TypeSection), new PropertyMetadata(new ObservableCollection<Type>()));


        public TypeSection()
        {
            InitializeComponent();
            Root.DataContext = this;
        }

        public TypeSection(ObservableCollection<Type> types, onAddType addTypeCallback, onEditType editTypeCallback, onRemoveType removeTypeCallback)
        {
            InitializeComponent();
            Root.DataContext = this;
            Types = types;
            AddTypeCallback = addTypeCallback;
            EditTypeCallback = editTypeCallback;
            RemoveTypeCallback = removeTypeCallback;
        }

        private void AddTypeButton_Click(object sender, RoutedEventArgs e)
        {
            AddType addTypeDialog = new AddType(this.AddTypeCallback);

            addTypeDialog.ShowDialog();
        }

        private void EditTypeButton_Click(object sender, RoutedEventArgs e)
        {
            EditType editTypeDialog = new emlekmu.EditType(Types[0], EditTypeCallback);

            editTypeDialog.ShowDialog();
        }
    }
}
