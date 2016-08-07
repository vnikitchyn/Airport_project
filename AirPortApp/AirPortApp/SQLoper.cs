using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AirPortApp.Flights;
using static AirPortApp.Tickets;
using static AirPortApp.Passengers;



namespace AirPortApp
{
    internal static class SQLoper
    {
        internal static void RemoveFlight(int num)
        {
            using (var db = new AirportDB())
            {
                List<Flight> allDbFlights = db.Flights.ToList<Flight>();
                var filteredFlights = from f in allDbFlights
                                      where f.Number == num
                                      select f;
                foreach (Flight flight in filteredFlights)
                {
                    db.Flights.Remove(flight);
                }
                db.SaveChanges();
            }
        }


        internal static void RemoveTicket(int num)
        {
            using (var db = new AirportDB())
            {
                List<Ticket> allDbTickets = db.Tickets.ToList<Ticket>();
                var filtered = from t in allDbTickets
                                      where t.Number == num
                                      select t;
                foreach (Ticket tr in filtered)
                {
                    db.Tickets.Remove(tr);
                }
                db.SaveChanges();
            }
        }


        internal static void RemovePassenger(string passport)
        {
            using (var db = new AirportDB())
            {
                List<Passenger> allpas = db.Passengers.ToList<Passenger>();
                var filtered = from p in allpas
                                      where p.Passport.Equals(passport)
                                      select p;
                foreach (Passenger p in filtered)
                {
                    db.Passengers.Remove(p);
                }
                db.SaveChanges();
            }
        }


        internal static List <Flight> AllFlightsToList()
        {
            using (var db = new AirportDB())
            {
                flightList=db.Flights.ToList();
            }
            return flightList;
        }
        internal static List <Passenger> AllPassengersToList()
        {
            using (var db = new AirportDB())
            {
                passList = db.Passengers.ToList();
            }
            return passList;
        }

        internal static List <Ticket>  AllTicketsToList() 
        {
            using (var db = new AirportDB())
            {
                TicketsList = db.Tickets.ToList();
            }
            return TicketsList;
        }


        internal static void AddFlight(Flight flight)
        {
            using (var db = new AirportDB())
            {
                db.Flights.Add(flight);
                db.SaveChanges();
            }
        }

        internal static void AddFlight(Passenger passenger)
        {
            using (var db = new AirportDB())
            {
                db.Passengers.Add(passenger);
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
                foreach (Ticket ticket in tickets )
                {
                    if (ticket.Flight.FlightId >0)
                    ticket.Flight = null;
                    if (ticket.Passenger.PassId > 0)
                    ticket.Passenger = null;
                }
                db.Tickets.AddRange(tickets);
                db.SaveChanges();
//             foreach (Ticket ticket in tickets) { AddTicket(ticket, flight);}   //alt realization, do not know what is the best.
            }
        }


        internal static void AddTicket(Ticket ticket) // worked method!
        {
            using (var db = new AirportDB())
            {
                if (ticket.Flight.FlightId > 0)
                {
                    ticket.FlightId = ticket.Flight.FlightId;
                    ticket.Flight = null;
                }
                if (ticket.Passenger.PassId > 0)
                {
                    ticket.PassId = ticket.Passenger.PassId;
                    ticket.Passenger = null;
                }
                db.Tickets.Add(ticket);
                db.SaveChanges();
            }
        }


        internal static void AddTicket(Ticket ticket, int flightNumber) // worked method!
        {
            using (var db = new AirportDB())
            {
                int flId = FindSQLFlightID(flightNumber);
                if (flId > 0)
                {
                    ticket.Flight = null;
                    ticket.FlightId = flId;
                }
                if (ticket.Passenger.PassId > 0)
                {
                    ticket.PassId = ticket.Passenger.PassId;
                    ticket.Passenger = null;
                }
                db.Tickets.Add(ticket);
                //db.Flights.Attach(flight);
                //ticket.Flight = flight;
                db.SaveChanges();
            }
        }


        internal static dynamic  FindSQLFlightWithTicketsandPassengers()
        {
                IEnumerable<dynamic> flickets =
                    from t in AllTicketsToList()
                    join f in AllFlightsToList() on t.FlightId equals f.FlightId
                    join p in passList on t.PassId equals p.PassId
                   select new { FlightNumber = f.Number, f.Airline,  f.PortArrival,
                       f.PortDeparture, f.Status, f.Terminal,f.Gate, Departure=f.TimeDeparture,ETA=f.TimeExpected,ATA=f.TimeArrival,
                       t.Price,TicketNumber = t.Number,t.Place, p.Name, p.Surname, FullName = string.Format("{0} {1}", p.Name, p.Surname), p.Passport };
                foreach (dynamic flicket in flickets)
                {
                    Console.WriteLine("Flights with tikcets: {0} \n", flicket.ToString());
                }
            return flickets;
        }


        internal static dynamic FindSQLFlightWithTicketsandPassengers(int number)
        {
            IEnumerable<dynamic> flickets =
                from t in AllTicketsToList()
                join f in AllFlightsToList() on t.FlightId equals f.FlightId
                join p in passList on t.PassId equals p.PassId
                where t.Number == number
                select new
                {
                    FlightNumber = f.Number,
                    f.Airline,
                    f.PortArrival,
                    f.PortDeparture,
                    f.Status,
                    f.Terminal,
                    f.Gate,
                    Departure = f.TimeDeparture,
                    ETA = f.TimeExpected,
                    ATA = f.TimeArrival,
                    t.Price,
                    TicketNumber = t.Number,
                    t.Place,
                    p.Name,
                    p.Surname,
                    FullName = string.Format("{0} {1}", p.Name, p.Surname),
                    p.Passport
                };
            foreach (dynamic flicket in flickets)
            {
                //Console.WriteLine("Flights with tikcets: {0} \n", flicket.ToString());
            }
            return flickets;
        }

        internal static void FindSQLFlight(int number) {
            IEnumerable<dynamic> flickets =
        from f in AllFlightsToList()
        where f.Number.Equals(number)
        join t in AllTicketsToList() on f.FlightId equals t.FlightId into ticketsfl
        from ft in ticketsfl.DefaultIfEmpty(new Ticket {FlightId=0, Number=0, Place="", Price =0, TicketId=0})
        join p in passList on ft.PassId equals p.PassId into ticketsflp
        from ftp in ticketsflp.DefaultIfEmpty(new Passenger {PassId=0, Name="",Surname="",Passport=""})

        select new
        {
            FlightNumber = f.Number,
            f.Airline,
            f.PortArrival,
            f.PortDeparture,
            f.Status,
            f.Terminal,
            f.Gate,
            Departure = f.TimeDeparture,
            ETA = f.TimeExpected,
            ATA = f.TimeArrival,
            ft.Price,
            TicketNumber = ft.Number,
            ft.Place,
            ftp.Name,
            ftp.Surname,
            FullName = string.Format("{0} {1}", ftp.Name, ftp.Surname),
            ftp.Passport
        };

            foreach (dynamic flicket in flickets)
            {
                Console.WriteLine("Flights with tikcets: {0} \n", flicket.ToString());
            }
        }

        internal static IEnumerable FindSQLFlightOnly(int number)
        {
            using (var db = new AirportDB())
            {
                List<Flight> allFlights = db.Flights.ToList<Flight>();
                IEnumerable<Flight> filtered =
                    from flight in allFlights
                    where flight.Number == number
                    select flight;
                //foreach (Flight flight in filtered)
                //{
                //    Console.WriteLine("{0}n\",flight", flight.ToString());
                //}
                return filtered;
            }
        }

        internal static IEnumerable FindSQLTicketOnly(int number)
        {                
                IEnumerable<Ticket> filtered =
                    from ticket in AllTicketsToList()
                    where ticket.Number == number
                    select ticket;
            return filtered;    
               }


        internal static IEnumerable FindSQLPassengerOnly(string passport)
        {
            IEnumerable<Passenger> filtered =
              from passenger in AllPassengersToList()
              where passenger.Passport.Equals(passport)
              select passenger;
            return filtered;
        }

        internal static IEnumerable FindSQLPassengerOnly(string name, string surname)
        {
            IEnumerable<Passenger> filtered =
              from passenger in AllPassengersToList()
              where passenger.Name.Equals(name) && passenger.Surname.Equals(surname)
              select passenger;
            return filtered;
        }


        internal static int FindSQLFlightID(int number)
        {
            using (var db = new AirportDB())
            {
                List<Flight> allFlights = db.Flights.ToList<Flight>();
                IEnumerable<Flight> filtered =
                    from flight in allFlights
                    where flight.Number == number
                    select flight;
                if (filtered.Any())
                    return filtered.FirstOrDefault().FlightId;
                else return 0;
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

        internal static int CountAllPassengers()
        {
            using (var db = new AirportDB())
            {
                List<Passenger> allPassengers = db.Passengers.ToList<Passenger>();
                int count = allPassengers.Count();
                return count;
            }
        }


    }
}
