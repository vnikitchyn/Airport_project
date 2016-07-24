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
  public static class Flights
    {

        internal static List<Flight> flightList = new List<Flight>();
        public enum statusEnum {checkIn=1, gateClosed, arrived, departedAt, unknown, canceled, expectedAt, delayed, inFlight }//"check-in","gate closed","arrived","departed at","unknown","canceled","expected at","delayed","in flight"        
        private static string[] statusArray = Enum.GetNames(typeof(statusEnum));


    internal  static void Input()
        {        
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Please enter flight parameters");

            Console.WriteLine("Please enter flight number (integer value)...");
            string numberS = Console.In.ReadLine();
            int number;
            while (int.TryParse(numberS, out number) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, flight number is mandatory, please enter value again \nPlease note, it should be integer value (you previously entered '{0}')", numberS);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                numberS = Console.In.ReadLine();
            }
            Console.WriteLine("Airport of departure...");
            string portD = Console.In.ReadLine();
            Console.WriteLine("Airport of arrival...");
            string portA = Console.In.ReadLine();
            Console.WriteLine("Airline company...");
            string airline = Console.In.ReadLine();

            Console.WriteLine("Time of departure in format 'yyyy-MM-dd hh-mm' ...");
            string timeDS = Console.In.ReadLine();
            DateTime timeD;
            while (DateTime.TryParseExact(timeDS, "yyyy-MM-dd hh-mm", null, System.Globalization.DateTimeStyles.AssumeUniversal, out timeD)==false)           
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, this date is mandatory, please enter values time of departure again \nPlease be carefull about format 'yyyy-MM-dd hh-mm' (you previously entered '{0}')", timeDS);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                timeDS = Console.In.ReadLine();
            }

            Console.WriteLine("Planned (expected) time of arrival 'yyyy-MM-dd hh-mm'...");
            string timeES = Console.In.ReadLine();
            DateTime timeE;
            while (DateTime.TryParseExact(timeES, "yyyy-MM-dd hh-mm", null, System.Globalization.DateTimeStyles.AssumeUniversal, out timeE) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, this date is mandatory, please enter values expected time of arrival again \nPlease be carefull about format 'yyyy-MM-dd hh-mm' (you previously entered '{0}')", timeES);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                timeES = Console.In.ReadLine();
            }
            Console.WriteLine("If the plane is arrived already, please enter time of arrival 'yyyy-MM-dd hh-mm' \nYou can skip this parameter by entering no value...");
            string timeAS = Console.In.ReadLine();
            DateTime timeA;
            DateTime.TryParseExact(timeAS, "yyyy-MM-dd hh-mm", null, System.Globalization.DateTimeStyles.AssumeUniversal, out timeA);            

            //      Console.WriteLine("Status. Please note it could be only one of below:\n{0}...",string.Join(" \n",statusArray));
            Console.WriteLine("Status. Please note it could be only one of the specified list:\n Pease enter 0-8, based on the status values below");
            foreach (string status in statusArray)
            {
              statusEnum se= (statusEnum) Enum.Parse(typeof(statusEnum), status);
              Console.WriteLine("{0}\t - {1}\n", se.ToString("F"),se.ToString("D"));
            }
            string statusS = Console.In.ReadLine();
            byte statusB;
            while (byte.TryParse(statusS, out statusB) == false|| statusB>8||statusB<1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, status is mandatory. You previously entered '{0}' \nPlease enter value (0-8) again)...", statusS);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                statusS = Console.In.ReadLine();
            }
            statusEnum statusE = (statusEnum) statusB;
            
            Console.WriteLine("Terminal...");
            string terminal = Console.In.ReadLine();
            Console.WriteLine("Gate...");
            string gate = Console.In.ReadLine();
            Flight flight;

            if (timeA == null) {
                flight = new Flight(timeD, timeE, number, portD, portA, airline, terminal, statusE, gate);
                flightList.Add(flight);
            }
            else
            {
                flight = new Flight(timeD, timeE, timeA, number, portD, portA, airline, terminal, statusE, gate);
                flightList.Add(flight);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("New flight is added: \n{0}", flight.ToString());
            Console.ReadKey();                  
        }

        internal static void Delete(int number)
        {
            foreach (Flight flight in flightList)
            {
                if (number.Equals(flight.Number))
                flightList.Remove(flight);
            }


        }

        internal  static void Find(int number)
        {
            foreach (Flight flight in flightList)
            {
                if (number.Equals(flight.Number))
                    flight.ToString();
            }

        }

        internal static void Find(string airportA)
        {
            foreach (Flight flight in flightList)
            {
                if (airportA.Equals(flight.PortArrival))
                    flight.ToString();
            }
                Console.WriteLine("Such flight is not found");


        }


        internal static void Find(DateTime dateA)
        {
            foreach (Flight flight in flightList)
            {
                if (dateA.Equals(flight.TimeArrival))
                    flight.ToString();

            }

        }


        internal static void ShowAll()
        {
            foreach (Flight flight in flightList)
            {
                    flight.ToString();
            }

        }


        internal static void BuildInitial()
        {
            Flight fl1 = new Flight(new DateTime (2016,06,10,18,00,00),new DateTime(2016, 06, 10, 20, 00, 00),new DateTime(2016, 06, 10, 20, 00, 00),1,"Kyiv","Stambul","Ukrainian airlines", "D", statusEnum.arrived,"1A");
            Flight fl2 = new Flight(new DateTime(2016, 07, 25, 19, 00, 00), new DateTime(2016, 07, 25, 21, 00, 00), 2, "Stambul", "Kyiv", "Turkish airlines", "D", statusEnum.expectedAt, "2A");
            Flight fl3 = new Flight(new DateTime(2016, 08, 10, 20, 00, 00), new DateTime(2016, 06, 10, 20, 00, 00), 3, "Kyiv", "San-Francisco", "Ukrainian airlines", "C", statusEnum.inFlight, "3A");

            flightList.AddValues(fl1, fl2, fl3);
 //         flightList.AddRange(new Flight[] {fl1,fl2,fl3});
 
        }

        public static void AddValues<T>(this List<T> list, params T[]values)
            {
                list.AddRange(values);
            }
        



    }
}
