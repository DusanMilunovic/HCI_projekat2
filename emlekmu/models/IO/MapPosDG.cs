using emlekmu.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emlekmu.models.IO
{
    public class MapPosDG
    {
        public List<MonumentPosition> map1Monuments;
        public List<MonumentPosition> map2Monuments;
        public List<MonumentPosition> map3Monuments;
        public List<MonumentPosition> map4Monuments;

        public MapPosDG()
        {
            this.map1Monuments = new List<MonumentPosition>();
            this.map2Monuments = new List<MonumentPosition>();
            this.map3Monuments = new List<MonumentPosition>();
            this.map4Monuments = new List<MonumentPosition>();
        }
    }
}
