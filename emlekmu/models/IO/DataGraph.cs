using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace emlekmu.models.IO
{
    public class DataGraph
    {
        public List<Monument> monuments;
        public List<Tag> tags;
        public List<Type> types;

        public DataGraph()
        {
            this.monuments = new List<Monument>();
            this.tags = new List<Tag>();
            this.types = new List<Type>();
        }
    }
}
