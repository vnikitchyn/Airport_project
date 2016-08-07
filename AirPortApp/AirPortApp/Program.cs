using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using static AirPortApp.StartMenu;
using static AirPortApp.SQLoper;
using static AirPortApp.Helper;


namespace AirPortApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //            if (flightList.Any() == false)
            if (CountAllFlights() <= 0)
                BuildInitialFlights();
            if (CountAllTickets()<=0)
                BuildInitialTickets();
            if (CountAllPassengers() <= 0)
                BuildInitialTickets();
            Wellcome();
            string input = Console.ReadLine();
            Choices(input);
        }
    }
}
