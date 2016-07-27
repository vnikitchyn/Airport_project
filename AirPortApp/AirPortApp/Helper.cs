using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AirPortApp.Flights;

namespace AirPortApp
{
    static class Helper
    {

        internal static void BuildInitial()
        {
            Flight fl1 = new Flight(new DateTime(2016, 01, 01, 03, 00, 00), new DateTime(2016, 01, 01, 01, 00, 00), 2, "Stambul", "Kyiv", "Turkish airlines", "D", statusEnum.expectedAt, "2A");
            Flight fl2 = new Flight(new DateTime(2016, 06, 10, 18, 00, 00), new DateTime(2016, 06, 10, 20, 00, 00), new DateTime(2016, 06, 10, 20, 00, 00), 1, "Kyiv", "Stambul", "Ukrainian airlines", "D", statusEnum.arrived, "1A");
            Flight fl3 = new Flight(new DateTime(2016, 07, 25, 19, 00, 00), new DateTime(2016, 07, 25, 21, 00, 00), 2, "Stambul", "Kyiv", "Turkish airlines", "D", statusEnum.expectedAt, "2A");
            Flight fl4 = new Flight(new DateTime(2016, 08, 10, 20, 00, 00), new DateTime(2016, 06, 10, 20, 00, 00), 3, "Kyiv", "San-Francisco", "Ukrainian airlines", "C", statusEnum.inFlight, "3A");
            Flight fl5 = new Flight(new DateTime(2016, 01, 01, 03, 00, 00), new DateTime(2016, 01, 01, 01, 00, 00), 2, "Stambul", "Kyiv", "Turkish airlines", "D", statusEnum.expectedAt, "2A");
            Flight fl6 = fl1;
            flightList.AddValues(fl1, fl2, fl3, fl4, fl5);
            //         flightList.AddRange(new Flight[] {fl1,fl2,fl3});

        }

        public static void AddValues<T>(this List<T> list, params T[] values)
        {
            list.AddRange(values);
        }

    }
}
