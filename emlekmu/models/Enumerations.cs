using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emlekmu.models
{
    public class Enumerations
    {
        public static TouristicStatus stringToTouristic(string toParse)
        {
            if (toParse == "Not available")
            {
                return TouristicStatus.Unavailable;
            }
            else if (toParse == "Available")
            {
                return TouristicStatus.Available;
            } else if (toParse == "Exploited")
            {
                return TouristicStatus.Exploited;
            }
            throw new Exception("It is zal");
        }
    }

    public enum Era
    {
        Paleolith,
        Neolithic,
        Ancient,
        Medieval,
        Renaissance,
        Modern
    }

    public enum TouristicStatus
    {
        Exploited,
        Available,
        Unavailable
    }

}
