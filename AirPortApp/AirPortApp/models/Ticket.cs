using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortApp
{   
    [Table ("Tickets")]
    public class Ticket
    {
        public int Number { get; set; }     // number
        [StringLength(15)]
        public string Name { get; set; }    //Name of passenger
        [StringLength(25)]
        public string Surname { get; set; } // Surname of passenger

        [StringLength(12)]
        [Column("Passport", Order = 5, TypeName = "varchar")]
        public string Passport { get; set; }   // Passport of passenger
        public double Price { get; set; }   // price
        [Key]
        [Column(Order = 1)]
        public int TicketId { get; set; } // ticket id internal

        public int FlightId { get; set; } // ticket id internal
        [ForeignKey("FlightId")]
        [Column(Order = 2)]
        public Flight Flight { get; set; }  //Flight

        


        //     public virtual List<Flight> Flights { get; set; }

        public Ticket() { }
        internal Ticket(Flight flight, int number, string name, string surname, string passport, double price)
        {
            Flight = flight;
            Number = number;
            Name = name;
            Surname = surname;
            Passport = passport;
            Price = price;
        }
        internal Ticket(Flight flight, int number, string name, string surname, double price)
        {
            Flight = flight;
            Number = number;
            Name = name;
            Surname = surname;
            Price = price;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (!Passport.Equals(null))
            {
                sb.Append("-------\n").
                   Append("Number: ").Append(Number)
                  .Append("\nName: ").Append(Name)
                  .Append("\nSurname ").Append(Surname)
                  .Append("\nPassport: ").Append(Passport)
                  .Append("\nPrice: ").Append(Price);
            }
            else {
                sb.Append("-------\n").
                Append("Number: ").Append(Number)
               .Append("\nName: ").Append(Name)
               .Append("\nSurname ").Append(Surname)
               .Append("\nPassport not provided ")
               .Append("\nPrice: ").Append(Price);
            }

            return sb.ToString();
        }



    }
}