using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPortApp
{
    [Table ("Passengers")]
    public class Passenger
    {
        public string Name { get; set; }    //Name of passenger
        [StringLength(25)]
        public string Surname { get; set; } // Surname of passenger
        [StringLength(12)]
        [Column("Passport", Order = 5, TypeName = "varchar")]
        public string Passport { get; set; }   // Passport of passenger

        [Key ]
        public int PassId { get; set; }   // Passport of passenger

        public virtual List<Ticket> Tickets  { get; set; }


        public Passenger() { }
        public Passenger(string name, string surname, string passport)
        {
            Name = name;
            Surname = surname;
            Passport = passport;
        }

        public Passenger(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (!Passport.Equals(null))
            {
                sb.Append("-------\n")
                  .Append("\nName: ").Append(Name)
                  .Append("\nSurname ").Append(Surname)
                  .Append("\nPassport: ").Append(Passport);
            }
            else
            {
                sb.Append("-------\n")
               .Append("\nName: ").Append(Name)
               .Append("\nSurname ").Append(Surname)
               .Append("\nPassport not provided ");
            }
            return sb.ToString();
        }

    }
}
