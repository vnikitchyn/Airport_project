using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortApp
{
    [Table("Tickets")]
    public class Ticket : IComparable<Ticket>
    {
        public int Number { get; set; }     // number
        [StringLength(15)]

        public string Place { get; set; } //place
        public double Price { get; set; }   // price
        [Key]
        [Column(Order = 1)]
        public int TicketId { get; set; } // ticket id internal

        [ForeignKey("Flight")]
        public int FlightId { get; set; } // ticket id internal
        public Flight Flight { get; set; }  //Flight

        [ForeignKey("Passenger")]
        public int PassId { get; set; } // ticket id internal
        public Passenger Passenger { get; set; }



        public Ticket() { }
        internal Ticket(Flight flight, int number,  double price)
        {
            Flight = flight;
            Number = number;
            Price = price;
        }

        internal Ticket(Flight flight, Passenger passenger, int number, double price, string place)
        {
            Flight = flight;
            Passenger = passenger;
            Number = number;
            Price = price;
            Place = place;
        }

        internal Ticket(Flight flight, Passenger passenger, int number, double price)
        {
            Flight = flight;
            Passenger = passenger;
            Number = number;
            Price = price;
        }

        internal Ticket(Passenger passenger, int number, double price)
        {
            Passenger = passenger;
            Number = number;
            Price = price;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Place != null)
            {
                sb.Append("-------\n").
                   Append("Number: ").Append(Number)
                  .Append("\nPrice: ").Append(Price)
                  .Append("\nPlace: ").Append(Place);
            }
            else
            {   sb.Append("-------\n").
                   Append("Number: ").Append(Number)
                  .Append("\nPrice: ").Append(Price)
                  .Append("\nPlace undefinied");
            }
            return sb.ToString();
        }

        public int CompareTo(Ticket other) //Comparable
        {
            if (Price > other.Price)
                return 1;
            if (this.Price < other.Price)
                return -1;
            else
                return 0;
        }
    }
}