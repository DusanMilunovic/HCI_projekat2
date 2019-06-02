using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace emlekmu.models.IO
{
    class CsvParser
    {
        public static string ABSOLUTE_PATH = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString() + "\\resources\\";
        public static DataGraph readCSV()
        {

            DataGraph retVal = new DataGraph();
            using (var reader = new StreamReader(@"../../resources/types.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('|');
                    int id = Convert.ToInt32(values[0]);
                    string image = ABSOLUTE_PATH + "type" + values[0] + ".png";
                    retVal.types.Add(new Type(id, values[1], image, values[2]));
                }
            }
            using (var reader = new StreamReader(@"../../resources/tags.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split('|');
                    string id = values[0];
                    string image = ABSOLUTE_PATH + "type" + values[0] + ".png";
                    retVal.tags.Add(new Tag(id, new Color(255, 255, 255), values[1]));
                }
            }
            using (var reader = new StreamReader(@"../../resources/monuments.txt"))
            {
                //skip first
                Random r = new Random();
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var values = line.Split('|');
                    int id = Convert.ToInt32(values[0]);
                    var name = values[1];
                    var description = values[2];
                    var image = ABSOLUTE_PATH + "monument" + values[0] + ".png";
                    var typeId = Convert.ToInt32(values[4]);
                    var type = retVal.types.Find(x => x.Id == typeId);
                    var era = (Era)Enum.Parse(typeof(Era), values[5]);
                    var icon = ABSOLUTE_PATH + "type" + type.Id + ".png";
                    var archeological = "1" == values[7];
                    var unesco = "1" == values[8];
                    var populated = "1" == values[9];
                    var touristic = Enumerations.stringToTouristic(values[10]);
                    var income = Convert.ToInt32(values[11]);
                    var date = values[12];

                    int numoftags = r.Next(1, 3);
                    List<Tag> tagzzz = new List<Tag>();
                    for (int i = 0; i < numoftags; i++)
                    {
                        Tag t = retVal.tags.ElementAt(r.Next(0, retVal.tags.Count() - 1));
                        if (tagzzz.IndexOf(t) == -1)
                            tagzzz.Add(t);
                    }
                    retVal.monuments.Add(new Monument(id, name, description, image, type, era, icon, archeological, unesco, populated, touristic, income, date, tagzzz));


                }
            }
                return retVal;
        }
    }
}
