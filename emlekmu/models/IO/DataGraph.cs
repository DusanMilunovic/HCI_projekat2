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
        public List<MonumentPosition> map1Monuments;
        public List<MonumentPosition> map2Monuments;
        public List<MonumentPosition> map3Monuments;
        public List<MonumentPosition> map4Monuments;

        public DataGraph()
        {
            this.monuments = new List<Monument>();
            this.tags = new List<Tag>();
            this.types = new List<Type>();
            this.map1Monuments = new List<MonumentPosition>();
            this.map2Monuments = new List<MonumentPosition>();
            this.map3Monuments = new List<MonumentPosition>();
            this.map4Monuments = new List<MonumentPosition>();
        }
    }
}
