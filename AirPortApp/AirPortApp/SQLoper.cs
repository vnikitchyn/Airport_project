using System;
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
            using (var db = new DBContextA())
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

        internal static void Add(DateTime timeD, DateTime timeE, DateTime timeA, int number, string portD, string portA, string airline, string terminal, Flights.statusEnum statusE, string gate)
        {
            using (var db = new DBContextA())
            {
                var flight = new Flight(timeD, timeE, timeA,  number,  portD,  portA,  airline,  terminal, statusE, gate);
                db.Flights.Add(flight);
                db.SaveChanges();
            }
        }

        internal static void Add(Flight flight)
        {
            using (var db = new DBContextA())
            {
                db.Flights.Add(flight);
                db.SaveChanges();
            }
        }


    }
}
