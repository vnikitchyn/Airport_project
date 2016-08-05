using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AirPortApp.Flights;
using static AirPortApp.Tickets;
using static AirPortApp.SQLoper;

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
            Ticket t1, t2, t3, t4, t5, t6, t7, t8, t9, t10;
            t1 = new Ticket(flightList.ElementAt(0), 1, "Bill", "Gates", "AM00001", 1500.56);
            t2 = new Ticket(flightList.ElementAt(1), 2, "Fam", "Nuven", 1500.56);
            t3 = new Ticket(flightList.ElementAt(1), 3, "Alan", "Turing", "AM00001", 1500.56);
            t4 = new Ticket(flightList.ElementAt(2), 4, "James", "Bond", "AM00001", 511);
            t5 = new Ticket(flightList.ElementAt(2), 5, "Andy", "Wozniak", "AM00001", 54666);
            t6 = new Ticket(flightList.ElementAt(2), 7, "Nemo", "Captain", "AM00001", 100.56);
            t7 = new Ticket(flightList.ElementAt(2), 8, "Mouse", "Eldgernon", "AM00001", 15.56);
            t8 = new Ticket(flightList.ElementAt(3), 9, "Hilary", "Klinton", "AM00001", 500.14);
            t9 = new Ticket(flightList.ElementAt(3), 10, "Gney", "Pompey", "AM00001", 1.56);
            t10 = new Ticket(flightList.ElementAt(3), 11, "Sherlock", "Holmes", "AM00001", 1000.00);
            TicketsList = new List<Ticket>();
            TicketsList.AddValuesToList(t1,t2,t3,t4,t5,t6,t7,t8,t9,t10);
            //Tickets.TicketsList.AddRange(new Ticket[] { t1,t2,t3,t4,t5,t6,t7,t8,t9,t10});
        }

//      internal Ticket(Flight flight, int number, string name, string surname, string passport, double price)
        public static void AddValuesToList<T>(this List<T> list, params T[] values)
        {
            list.AddRange(values);
        }

    }
}
