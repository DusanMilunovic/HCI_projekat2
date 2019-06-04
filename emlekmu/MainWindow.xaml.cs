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
using emlekmu.models.IO;
using emlekmu.models;
using System.Windows.Media.Animation;
using System.Threading;
using System.Windows.Controls.Primitives;
using System.Diagnostics;

namespace emlekmu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextCompositionManager.AddTextInputHandler(this,
                new TextCompositionEventHandler(OnTextComposition));
            this.WindowState = WindowState.Maximized;
            this.Title = "Emlekmu";
        }

        

        private void AddMonumentCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AddMonumentCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddMonument dialog = new AddMonument(MainContent.Monuments, MainContent.Types, MainContent.Tags,
            MainContent.addMonumentCallback, MainContent.addTypeCallback, MainContent.addTagCallback);
            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.Height = 560;
            dialog.Width = 800;
            dialog.MinHeight = 560;
            dialog.MinWidth = 800;
            dialog.ShowDialog();
            if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
            {
                var m = dialog.Monument;
                if (m != null)
                {
                    MainContent.MonumentTable.monumentClicked(m.Id);
                    MainContent.MonumentTable.ScrollToSelected();
                }
            }
            else
            {
                return;
            }
            
        }

        private void AddTypeCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AddTypeCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddType dialog = new AddType(MainContent.addTypeCallback, MainContent.Types);
            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.Height = 490;
            dialog.Width = 350;
            dialog.MinHeight = 420;
            dialog.MinWidth = 280;
            dialog.ShowDialog();
        }

        private void AddTagCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AddTagCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddTag dialog = new emlekmu.AddTag(MainContent.addTagCallback, MainContent.Tags);
            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.Height = 490;
            dialog.Width = 350;
            dialog.MinHeight = 420;
            dialog.MinWidth = 280;
            dialog.ShowDialog();
        }

        private void EditMonumentCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.MainContent.MonumentTable.EnlargenedMonuments.Count > 0;
        }

        private void EditMonumentCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            int toEdit = MainContent.MonumentTable.EnlargenedMonuments.First();
            Monument m = MainContent.Monuments.SingleOrDefault(x => x.Id == toEdit);
            EditMonument dialog = new EditMonument(MainContent.Types, MainContent.Tags, MainContent.editMonumentCallback, m, MainContent.addTypeCallback, MainContent.addTagCallback);
            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.Height = 560;
            dialog.Width = 800;
            dialog.MinHeight = 560;
            dialog.MinWidth = 800;
            dialog.ShowDialog();
        }

        private void RemoveMonumentCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.MainContent.MonumentTable.EnlargenedMonuments.Count > 0;
        }

        private void RemoveMonumentCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AreYouSure ars = new AreYouSure("Are you sure you want to delete this monument?");
            ars.Owner = Application.Current.MainWindow;
            ars.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ars.ShowDialog();

            if (ars.DialogResult.HasValue && !ars.DialogResult.Value)
            {
                return;
            }

            int toRemove = MainContent.MonumentTable.EnlargenedMonuments.First();
            Monument m = MainContent.Monuments.SingleOrDefault(x => x.Id == toRemove);
            this.MainContent.removeMonumentCallback(m.Id);
            MainContent.MonumentTable.EnlargenedMonuments.Remove(toRemove);
        }

        private void ListTypesCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ListTypesCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TypeSection typeSectionDialog = new TypeSection(MainContent.Types, MainContent.addTypeCallback, MainContent.editTypeCallback, MainContent.removeTypeCallback);
            typeSectionDialog.Owner = Application.Current.MainWindow;
            typeSectionDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            typeSectionDialog.Height = 700;
            typeSectionDialog.Width = 800;
            typeSectionDialog.MinHeight = 560;
            typeSectionDialog.MinWidth = 600;
            this.TypeSectionDemonDialog = typeSectionDialog;
            typeSectionDialog.ShowDialog();
        }


        private void ListTagsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ListTagsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            TagSection tagSectionDialog = new TagSection(MainContent.Tags, MainContent.addTagCallback, MainContent.editTagCallback, MainContent.removeTagCallback);
            tagSectionDialog.Owner = Application.Current.MainWindow;
            tagSectionDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            tagSectionDialog.Height = 700;
            tagSectionDialog.Width = 800;
            tagSectionDialog.MinHeight = 560;
            tagSectionDialog.MinWidth = 600;
            this.TagSectionDemonDialog = TagSectionDemonDialog;
            tagSectionDialog.ShowDialog();
        }

        private void NextTabCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NextTabCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MainContent.MapsContainer.SelectedIndex = (MainContent.MapsContainer.SelectedIndex + 1) % 4;
        }

        private void PreviousTabCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PreviousTabCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MainContent.MapsContainer.SelectedIndex = (MainContent.MapsContainer.SelectedIndex + 3) % 4;
        }

        private void Tab1Command_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Tab1Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MainContent.MapsContainer.SelectedIndex = 0;
        }

        private void Tab2Command_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Tab2Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MainContent.MapsContainer.SelectedIndex = 1;
        }

        private void Tab3Command_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Tab3Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MainContent.MapsContainer.SelectedIndex = 2;
        }

        private void Tab4Command_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Tab4Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MainContent.MapsContainer.SelectedIndex = 3;
        }

        private void CheatSheetCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CheatSheetCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CheatSheet dialog = new CheatSheet();
            dialog.Owner = Application.Current.MainWindow;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.Width = 300;
            dialog.Height = 300;
            dialog.MinWidth = 300;
            dialog.MinHeight = 300;
            dialog.Show();
        }

        private void HelpDocumentationCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void HelpDocumentationCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            HelpProvider.ShowHelpTopic("Emlekmu");
        }



        public TagSection TagSectionDemonDialog { get; set; }
        public TypeSection TypeSectionDemonDialog { get; set; }


        private void OnTextComposition(object sender, TextCompositionEventArgs e)
        {
            if (MainContent.DemonAlive)
            {
                MainContent.Demon.Abort();
                MainContent.DemonAlive = false;
            }
            
        }

    }
}
