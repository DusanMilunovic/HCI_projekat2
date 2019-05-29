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
                    string image = values[0] + ".png";
                    retVal.types.Add(new Type(id, values[1], image, values[2]));
                }
            }
            using (var reader = new StreamReader(@"../../resources/monuments.txt"))
            {
                //skip first
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    var values = line.Split('|');
                    int id = Convert.ToInt32(values[0]);
                    var name = values[1];
                    var description = values[2];
                    var image = values[3];
                    var typeId = Convert.ToInt32(values[4]);
                    var type = retVal.types.Find(x => x.Id == typeId);
                    var era = (Era)Enum.Parse(typeof(Era), values[5]);
                    var icon = values[6];
                    var archeological = "1" == values[7];
                    var unesco = "1" == values[8];
                    var populated = "1" == values[9];
                    var touristic = Enumerations.stringToTouristic(values[10]);
                    var income = Convert.ToInt32(values[11]);
                    var date = values[12];
                    retVal.monuments.Add(new Monument(id, name, description, image, type, era, icon, archeological, unesco, populated, touristic, income, date));


                }
            }
                return retVal;
        }
    }
}
