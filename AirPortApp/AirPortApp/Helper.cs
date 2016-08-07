using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AirPortApp.Flights;
using static AirPortApp.Tickets;
using static AirPortApp.Passengers;
using static AirPortApp.SQLoper;
using System.Text.RegularExpressions;

namespace AirPortApp
{
   public static class Helper
    {

        internal static void BuildInitialFlights()
        {
            Flight fl1 = new Flight(new DateTime(2016, 01, 01, 03, 00, 00), new DateTime(2016, 01, 01, 01, 00, 00), 2, "Stambul", "Kyiv", "Turkish airlines", "D", statusEnum.expectedAt, "2A");
            Flight fl2 = new Flight(new DateTime(2016, 06, 10, 18, 00, 00), new DateTime(2016, 06, 10, 20, 00, 00), new DateTime(2016, 06, 10, 20, 00, 00), 1, "Kyiv", "Stambul", "Ukrainian airlines", "D", statusEnum.arrived, "1A");
            Flight fl3 = new Flight(new DateTime(2016, 07, 25, 19, 00, 00), new DateTime(2016, 07, 25, 21, 00, 00), 3, "Stambul", "Kyiv", "Turkish airlines", "D", statusEnum.expectedAt, "2A");
            Flight fl4 = new Flight(new DateTime(2016, 08, 10, 20, 00, 00), new DateTime(2016, 06, 10, 20, 00, 00), 4, "Kyiv", "San-Francisco", "Ukrainian airlines", "C", statusEnum.inFlight, "3A");
            Flight fl5 = new Flight(new DateTime(2016, 01, 01, 03, 00, 00), new DateTime(2016, 01, 01, 01, 00, 00), 5, "Stambul", "Kyiv", "Turkish airlines", "D", statusEnum.expectedAt, "2A");
            Flight fl6 = fl1;
            flightList.AddValuesToList(fl1, fl2, fl3, fl4, fl5, fl6);
            //         flightList.AddRange(new Flight[] {fl1,fl2,fl3});

        }

        internal static void BuildInitialTickets()
        {
            if (flightList.Any() == false) {
               // AllFlightsToList();
                BuildInitialFlights();
                    }

            if (!passList.Any())
            {
                BuildInitialPassengers();
            }

            Ticket t1, t2, t3, t4, t5, t6, t7, t8, t9, t10;
            t1 = new Ticket(flightList.ElementAt(0), passList.ElementAt(0), 1, 1500.56, "2A");
            t2 = new Ticket(flightList.ElementAt(1), passList.ElementAt(1), 2,  1500.56, "3F");
            t3 = new Ticket(flightList.ElementAt(1), passList.ElementAt(2), 3,1500.56, "1A");
            t4 = new Ticket(flightList.ElementAt(2), passList.ElementAt(3), 4, 511, "4B");
            t5 = new Ticket(flightList.ElementAt(2), passList.ElementAt(4), 5, 54666, "2C");
            t6 = new Ticket(flightList.ElementAt(2), passList.ElementAt(5), 6, 100.56, "8E");
            t7 = new Ticket(flightList.ElementAt(2), passList.ElementAt(6), 7, 15.56, "3D");
            t8 = new Ticket(flightList.ElementAt(3), passList.ElementAt(7), 8, 500.14, "5A");
            t9 = new Ticket(flightList.ElementAt(3), passList.ElementAt(8), 9, 1.56);
            t10 = new Ticket(flightList.ElementAt(3), passList.ElementAt(9), 10, 1000.00, "8G");
            TicketsList = new List<Ticket>();
            TicketsList.AddValuesToList(t1,t2,t3,t4,t5,t6,t7,t8,t9,t10);
            //Tickets.TicketsList.AddRange(new Ticket[] { t1,t2,t3,t4,t5,t6,t7,t8,t9,t10});
        }

        internal static void BuildInitialPassengers()
        {
          Passenger p1 = new Passenger("Bill", "Gates", "AM00001");
          Passenger p2 = new Passenger("Fam", "Nuven");
          Passenger p3 = new Passenger("Alan", "Turing", "AM001");
          Passenger p4 = new Passenger("James", "Bond", "AM0023401");
          Passenger p5 = new Passenger("Andy", "Wozniak", "AM00023");
          Passenger p6 = new Passenger("Nemo", "Captain", "ADSD001");
          Passenger p7 = new Passenger("Mouse", "Eldgernon", "AM000341");
          Passenger p8 = new Passenger("Hilary", "Klinton", "AM0005451");
          Passenger p9 = new Passenger("Gney", "Pompey", "AM0001434");
          Passenger p10 = new Passenger("Sherlock", "Holmes", "AM0000321");
          passList.AddValuesToList (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);
        }


        public static void AddValuesToList<T>(this List<T> list, params T[] values)
        {
            list.AddRange(values);
        }

        public static string StringWithoutNumbers(string input) 
        {
            string output = Regex.Replace(input, @"[\d-]", string.Empty);
            //string output = new string(input.Where(c => c != '-' && (c < '0' || c > '9')).ToArray()); via lambda and Linq
            return output;
        }

        public static void NumbersWithoutString(this string input) //similar with extension
        {
            string output = Regex.Replace(input, "[A-Za-z&*%#$@!(){}. ]", string.Empty);
            output = Regex.Replace(output, @"\,+", ",");
            input = output;
        }
    }
}
