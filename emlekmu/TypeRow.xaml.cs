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
using Type = emlekmu.models.Type;


namespace emlekmu
{
    /// <summary>
    /// Interaction logic for TypeRow.xaml
    /// </summary>

    public partial class TypeRow : UserControl
    {


        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(TypeRow), new PropertyMetadata(0));



        public string TypeName
        {
            get { return (string)GetValue(TypeNameProperty); }
            set { SetValue(TypeNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeNameProperty =
            DependencyProperty.Register("TypeName", typeof(string), typeof(TypeRow), new PropertyMetadata(""));



        public string Descripton
        {
            get { return (string)GetValue(DescriptonProperty); }
            set { SetValue(DescriptonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Descripton.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptonProperty =
            DependencyProperty.Register("Descripton", typeof(string), typeof(TypeRow), new PropertyMetadata(""));



        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(TypeRow), new PropertyMetadata(""));



        public TypeRow()
        {
            InitializeComponent();
        }
    }
}
