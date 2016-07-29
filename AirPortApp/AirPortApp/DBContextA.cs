using System.Data.Entity;




namespace AirPortApp
{






    internal class DBContextA : DbContext
    {     
        internal DbSet<Flight> Flights { get; set; }
        internal DbSet<Ticket> Tickets { get; set; }
    }
}