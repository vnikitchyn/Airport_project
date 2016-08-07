
using System.Data.Entity;


namespace AirPortApp
{

    public class AirportDB : DbContext
    {     
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

    }
}