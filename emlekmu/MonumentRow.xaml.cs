﻿using emlekmu.models;
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
using static emlekmu.MonumentsTable;
using Type = emlekmu.models.Type;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for MonumentRow.xaml
    /// </summary>
    public partial class MonumentRow : UserControl
    {



        public string BorderColor
        {
            get { return (string)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BorderColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BorderColorProperty =
            DependencyProperty.Register("BorderColor", typeof(string), typeof(MonumentRow), new PropertyMetadata("#006699"));


        public ObservableCollection<int> EnlargenedMonuments
        {
            get { return (ObservableCollection<int>)GetValue(EnlargenedMonumentsProperty); }
            set { SetValue(EnlargenedMonumentsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnlargenedMonuments.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnlargenedMonumentsProperty =
            DependencyProperty.Register("EnlargenedMonuments", typeof(ObservableCollection<int>), typeof(MonumentRow), new PropertyMetadata(new ObservableCollection<int>()));

    
        public int MonumentId
        {
            get { return (int)GetValue(MonumentIdProperty); }
            set { SetValue(MonumentIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentIdProperty =
            DependencyProperty.Register("MonumentId", typeof(int), typeof(MonumentRow), new PropertyMetadata(0));



        public string MonumentName
        {
            get { return (string)GetValue(MonumentNameProperty); }
            set { SetValue(MonumentNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentNameProperty =
            DependencyProperty.Register("MonumentName", typeof(string), typeof(MonumentRow), new PropertyMetadata(""));



        public Type MonumentType
        {
            get { return (Type)GetValue(MonumentTypeProperty); }
            set { SetValue(MonumentTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentTypeProperty =
            DependencyProperty.Register("MonumentType", typeof(Type), typeof(MonumentRow), new PropertyMetadata(null));





        public ObservableCollection<Tag> MonumentTags
        {
            get { return (ObservableCollection<Tag>)GetValue(MonumentTagsProperty); }
            set { SetValue(MonumentTagsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentTags.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentTagsProperty =
            DependencyProperty.Register("MonumentTags", typeof(ObservableCollection<Tag>), typeof(MonumentRow), new PropertyMetadata(new ObservableCollection<Tag>()));






        public string MonumentImage
        {
            get { return (string)GetValue(MonumentImageProperty); }
            set { SetValue(MonumentImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentImageProperty =
            DependencyProperty.Register("MonumentImage", typeof(string), typeof(MonumentRow), new PropertyMetadata(""));

        
        public onMonumentClicked MonumentClickedCallback
        {
            get { return (onMonumentClicked)GetValue(MonumentClickedCallbackProperty); }
            set { SetValue(MonumentClickedCallbackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MonumentClickedCallback.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonumentClickedCallbackProperty =
            DependencyProperty.Register("MonumentClickedCallback", typeof(onMonumentClicked), typeof(MonumentRow), new PropertyMetadata(null));




        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            MonumentClickedCallback(MonumentId);
        }

        private void onRigthClick(object sender, MouseButtonEventArgs e)
        {
            // open context menu
        }

        private void editMenuAction(object sender, RoutedEventArgs e)
        {
            
        }


        public MonumentRow()
        {
            InitializeComponent();
            Root.DataContext = this;
        }
    }
}
