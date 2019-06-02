using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace emlekmu.models.IO
{
    public class XmlParser
    {
        public static void serialize(DataGraph dataGraph)
        {
            XmlSerializer ser = new XmlSerializer(typeof(DataGraph));
            TextWriter writer = new StreamWriter(@"../../resources/datagraph.xml");
            ser.Serialize(writer, dataGraph);
            writer.Close();
        }

        public static void serMapPog(MapPosDG mpdg)
        {
            XmlSerializer ser = new XmlSerializer(typeof(MapPosDG));
            TextWriter writer = new StreamWriter(@"../../resources/mappos.xml");
            ser.Serialize(writer, mpdg);
            writer.Close();
        }
        public static MapPosDG desMapPog(List<Monument> monuments)
        {
            XmlSerializer ser = new XmlSerializer(typeof(MapPosDG));
            StreamReader reader = new StreamReader(@"../../resources/mappos.xml");
            MapPosDG mpdg = (MapPosDG)ser.Deserialize(reader);
            reader.Close();

            foreach (Monument monument in monuments)
            {
                foreach (MonumentPosition mp in mpdg.map1Monuments)
                {
                    mp.Monument = monuments.Find(x => x.Id == mp.Monument.Id);
                }
                foreach (MonumentPosition mp in mpdg.map2Monuments)
                {
                    mp.Monument = monuments.Find(x => x.Id == mp.Monument.Id);
                }
                foreach (MonumentPosition mp in mpdg.map3Monuments)
                {
                    mp.Monument = monuments.Find(x => x.Id == mp.Monument.Id);
                }
                foreach (MonumentPosition mp in mpdg.map4Monuments)
                {
                    mp.Monument = monuments.Find(x => x.Id == mp.Monument.Id);
                }
            }

            return mpdg;
        }
        public static DataGraph deserialize()
        {
            XmlSerializer ser = new XmlSerializer(typeof(DataGraph));
            StreamReader reader = new StreamReader(@"../../resources/datagraph.xml");
            DataGraph ds = (DataGraph)ser.Deserialize(reader);
            reader.Close();

            foreach (Monument monument in ds.monuments)
            {
                monument.Type = ds.types.Find(x => x.Id == monument.Type.Id);
                List<Tag> newTags = new List<Tag>();
                foreach (Tag tag in monument.Tags)
                {
                    newTags.Add(ds.tags.Find(x => x.Id == tag.Id));
                }
                monument.Tags = new ObservableCollection<Tag>(newTags);
                
            }
            return ds;
        }

    }
}
