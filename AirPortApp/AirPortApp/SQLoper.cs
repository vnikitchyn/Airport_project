using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortApp
{
    internal static class SQLoper
    {
        internal static void Remove(int num)
        {
            using (var db = new AirportDB())
            {
                List<Flight> allDbFlights = db.Flights.ToList<Flight>();
                var filteredFlights = from st in allDbFlights
                                      where st.Number == num
                                      select st;
                foreach (Flight flight in filteredFlights)
                {
                    db.Flights.Remove(flight);
                }
                db.SaveChanges();
            }
        }


        internal static void AddFlight(Flight flight)
        {
            using (var db = new AirportDB())
            {
                db.Flights.Add(flight);
                db.SaveChanges();
            }
        }

        internal static void AddFlights(List <Flight> flights)
        {
            using (var db = new AirportDB())
            {
                foreach (Flight fl in flights)
                { AddFlight(fl); } // alt: db.Flights.AddRange(flights);
            }
        }

        internal static void AddTickets(List <Ticket> tickets)
        {
            using (var db = new AirportDB())
            {
                //foreach (Ticket ticket in tickets )
                //{
                //    ticket.Flight = flight;                      
                //}
                db.Tickets.AddRange(tickets);
                db.SaveChanges();
//             foreach (Ticket ticket in tickets) { AddTicket(ticket, flight);}   //alt realization, do not know what is the best. This one calling to db every ticket.
            }
        }

        internal static void AddTicket(Ticket ticket)
        {
            using (var db = new AirportDB())
            {             
                db.Tickets.Add(ticket);
                db.SaveChanges();
            }
        }

        internal static void FindSQLFlightWithTickets()
        {
            using (var db = new AirportDB())
            {

                List<Flight> allFlights = db.Flights.ToList<Flight>();
                List<Ticket> allTickets = db.Tickets.ToList<Ticket>();

                IEnumerable<Flight> filtered =
                    from flight in allFlights
                    join ticket in allTickets on flight.FlightId equals ticket.FlightId
                    select flight;
                foreach (Flight flight in filtered)
                {
                    Console.WriteLine("Totally flights with tickets: {0} \n{1}\n",filtered.Count(),flight.ToString());
                }
            }
        }


        internal static void FindSQLFlight(int number) {
            using (var db = new AirportDB())
            {

                List<Flight> allFlights = db.Flights.ToList<Flight>();
                List<Ticket> allTickets = db.Tickets.ToList<Ticket>();

               var filtered =
                    from flight in allFlights
                    join ticket in allTickets on flight.FlightId equals ticket.FlightId into grouped
                    //                    where flight.Number == number                   
                    select  grouped.DefaultIfEmpty(new Ticket() { Name = string.Empty, FlightId = flight.FlightId }); 


                foreach ( var flickets in filtered)
                {
                    Console.WriteLine("flikcet group: {0} ", flickets.Count());

                    foreach (var flicket in flickets)
                    {
                        Console.WriteLine("{0}n\",flight. \nticket- name: {1}\tsurname:{2}\tnumber{3}",flicket.Flight.ToString(), flicket.Name,flicket.Surname, flicket.Number);
                    }
                }
            }
        }

        internal static void FindSQLFlightOnly(int number)
        {
            using (var db = new AirportDB())
            {
                List<Flight> allFlights = db.Flights.ToList<Flight>();
                IEnumerable<Flight> filtered =
                    from flight in allFlights
                    where flight.Number == number
                    select flight;
                foreach (Flight flight in filtered)
                {
                    Console.WriteLine("{0}n\",flight");
                }
            }

        }

        internal static int CountAllFlights ()
        {
            using (var db = new AirportDB())
            {
                List<Flight> allFlights = db.Flights.ToList<Flight>();
                int count = allFlights.Count();
                return count;
            }

        }

        internal static int CountAllTickets()
        {
            using (var db = new AirportDB())
            {
                List<Ticket> allTickets = db.Tickets.ToList<Ticket>();
                int count = allTickets.Count();
                return count;
            }

        }
    }
}
