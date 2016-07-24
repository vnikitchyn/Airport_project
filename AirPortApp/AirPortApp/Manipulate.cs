using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//–input, deleting and editing of  this information
//–search by the flight number, time of arrival, arrival (departure) port and the information output about the found flight in the specified format
//–search of the flight which is the nearest (1 hour) to the specified time to/from the specified port and output information sorted by time
//–output of the emergency information (evacuation, fire, etc.)
//–menu for input and output
//•use:
//–arrays
//–casting and type conversions
//–loops
//–switch
//–read/write from/to console
//–string format
//–Console class properties


namespace AirPortApp
{
 static class Manipulate
    {
        internal static void Input()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Please enter flight parameters");
            Console.WriteLine("Airport ");
            Console.In.ReadLine();

        }

    }


}
