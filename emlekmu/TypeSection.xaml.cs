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
using static emlekmu.MainContent;
using Type = emlekmu.models.Type;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for TypeSection.xaml
    /// </summary>
    public partial class TypeSection: Window, INotifyPropertyChanged
    {
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public delegate void onTypeClicked(int id);
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

        public onTypeClicked typeClickedCallback;
        public onTypeClicked TypeClickedCallback
        {
            get
            {
                return typeClickedCallback;
            }
            set
            {
                if (value != typeClickedCallback)
                {
                    typeClickedCallback = value;
                    OnPropertyChanged("TypeClickedCallback");
                }
            }
        }
        public TypeSection()
        {
            InitializeComponent();
            Root.DataContext = this;
        }

        public TypeSection(ObservableCollection<Type> types, onAddType addTypeCallback, onEditType editTypeCallback, onRemoveType removeTypeCallback)
        {
            InitializeComponent();
            EnlargenedTypes = new ObservableCollection<int>();
            Root.DataContext = this;
            TypeClickedCallback = new onTypeClicked(typeClicked);
            Types = types;
            AddTypeCallback = addTypeCallback;
            EditTypeCallback = editTypeCallback;
            RemoveTypeCallback = removeTypeCallback;
        }

        ObservableCollection<int> enlargenedTypes;
        public ObservableCollection<int> EnlargenedTypes
        {
            get
            {
                return enlargenedTypes;
            }
            set
            {
                if (value != enlargenedTypes)
                {
                    enlargenedTypes = value;
                    OnPropertyChanged("EnlargenedTypes");
                }
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public void typeClicked(int id)
        {
            TypeRow myTypeUC = null;
            TypeRowDetail myTypeDUC = null;
            foreach (TypeRow tb in FindVisualChildren<TypeRow>(RootWoot))
            {
                tb.Visibility = Visibility.Visible;
                if (tb.Tag.Equals(id))
                    myTypeUC = tb;
                else
                    this.EnlargenedTypes.Remove(tb.Id);
            }
            foreach (TypeRowDetail tb in FindVisualChildren<TypeRowDetail>(RootWoot))
            {
                tb.Visibility = Visibility.Collapsed;
                if (tb.Tag.Equals(id))
                    myTypeDUC = tb;
                else
                    this.EnlargenedTypes.Remove(tb.Id);
            }

            if (this.EnlargenedTypes.IndexOf(id) == -1)
            {
                myTypeUC.Visibility = Visibility.Collapsed;
                myTypeDUC.Visibility = Visibility.Visible;
                this.EnlargenedTypes.Add(id);
            }
            else
            {
                myTypeDUC.Visibility = Visibility.Collapsed;
                myTypeUC.Visibility = Visibility.Visible;
                this.EnlargenedTypes.Remove(id);
            }
        }



        private void AddTypeButton_Click(object sender, RoutedEventArgs e)
        {
            AddType addTypeDialog = new AddType(AddTypeCallback, Types);

            addTypeDialog.Height = 600;
            addTypeDialog.Width = 400;

            addTypeDialog.ShowDialog();
        }

        private void onRigthClick(object sender, MouseButtonEventArgs e)
        {
            // open context menu
            if (((UIElement)sender).IsMouseDirectlyOver)
            {
                ContextMenu cm = this.FindResource("cmTypeSection") as ContextMenu;
                cm.IsOpen = true;
            }
        }

        public void CloseAction_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void EditTypeCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.EnlargenedTypes.Count > 0;
        }

        private void EditTypeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int toEdit = EnlargenedTypes.First();
            Type m = this.Types.First(x => x.Id == toEdit);
            EditType dialog = new EditType(m, this.EditTypeCallback);
            dialog.Width = 400;
            dialog.Height = 400;
            dialog.Show();
        }

        private void AddTypeCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AddTypeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddType dialog = new AddType(this.AddTypeCallback, this.Types);
            dialog.Height = 400;
            dialog.Width = 400;
            dialog.Show();
        }

        private void DeleteTypeCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.EnlargenedTypes.Count > 0;
        }

        private void DeleteTypeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int toRemove = this.EnlargenedTypes.First();
            Type t = this.Types.First(x => x.Id == toRemove);
            this.RemoveTypeCallback(toRemove);
            this.EnlargenedTypes.Remove(toRemove);
        }
    }
}
