using emlekmu.models;
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
    /// Interaction logic for MainContent.xaml
    /// </summary>
    public partial class MainContent : UserControl
    {
        #region Monument
        public delegate Monument onAddMonument(Monument m);
        public delegate Monument onRemoveMonument(int id);
        public delegate Monument onEditMonument(Monument m);
        public delegate Monument onFindMonument(int id);


        public onAddMonument addMonumentCallback { get; set; }
        public onRemoveMonument removeMonumentCallback { get; set; }
        public onEditMonument editMonumentCallback { get; set; }
        public onFindMonument findMonumentCallback { get; set; }

        Monument addMonument(Monument t)
        {
            return null;
        }

        Monument removeMonument(int id)
        {
            return null;
        }

        Monument editMonument(Monument t)
        {
            return null;
        }

        Monument findMonument(int id)
        {
            return null;
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
            return null;
        }

        Type removeType(int id)
        {
            return null;
        }

        Type editType(Type t)
        {
            return null;
        }

        Type findType(int id)
        {
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
            return null;
        }

        Tag removeTag(string id)
        {
            return null;
        }

        Tag editTag(Tag t)
        {
            return null;
        }

        Tag findTag(string id)
        {
            return null;
        }


        #endregion
        public MainContent()
        {
            InitializeComponent();
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
        }

    }
}
