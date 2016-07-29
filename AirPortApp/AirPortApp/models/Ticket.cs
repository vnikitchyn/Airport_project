using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortApp
{   
    [Table ("tickets") ]
    internal class Ticket
    {
        public Flight Flight { get; set; }      //Flight
        public int Number { get; set; }   // number
        public string Name { get; set; }  //Name of passenger
        public string Surname { get; set; } // Surname of passenger
        public int Passport { get; set; } // Passport of passenger
        public double Price { get; set; }   // price
        [Key]
        public int id { get; set; } // ticket id internal

        public virtual List<Flight> Flights { get; set; }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("-------\n").
               Append("Number: ").Append(Number)
              .Append("\nName: ").Append(Name)
              .Append("\nSurname ").Append(Surname)
              .Append("\nPassport: ").Append(Passport)
              .Append("\nPrice: ").Append(Price);
            return sb.ToString();
        }

        internal Ticket() { }
        internal Ticket(Flight flight, int number, string name, string surname, int passport, double price)
        {
            Flight = flight;
            Number = number;
            Name = name;
            Surname = surname;
            Passport = passport;
            Price = price;
        }

    }
}