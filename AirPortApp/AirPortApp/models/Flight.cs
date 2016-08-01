using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AirPortApp.Flights;

namespace AirPortApp
{

    [Table("Flights")]
    public class Flight
    {
        #region properties and fields: all string except Number

        private DateTime? timeArrival;
        public DateTime? TimeArrival
        {
          get
            {
                if (timeArrival < (DateTime)SqlDateTime.MinValue)
                    timeArrival = null;                
                return timeArrival;
            }
            set
            {  timeArrival = value; }
        }

        //date and time of arrival
        public DateTime TimeDeparture { get; set; }  //date and time of departure
        public DateTime TimeExpected { get; set; } // TimeExpected  
        public int Number    { get; set; }   //flight number
        public string PortArrival { get; set; }     //city/port of arrival(departure)
        public string PortDeparture { get; set; }     //city/port of arrival(departure)
        public string Airline { get; set; }  //Airline company
        public string Terminal { get; set; } // Terminal
        [NotMapped]
        public statusEnum StatusE { get; set; } // status   enum is ignored by database.     
        public string Status { get; set; }
        public string Gate { get; set; } // gate
        [Key ]
        public int FlightId { get; set; } // flight id internal
        public virtual List<Ticket> Tickets { get; set; }

   

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (!TimeArrival.Equals(null))
            {
                DateTime TimeArrivalCast= (DateTime) TimeArrival;
                sb.Append("-------\n").
                   Append("Number: ").Append(Number)
                  .Append("\nPortArrival: ").Append(PortArrival)
                  .Append("\nPortDeparture: ").Append(PortDeparture)
                  .Append("\nAirline: ").Append(Airline)
                  .Append("\nStatus: ").Append(Status)
                  .Append("\nTimeDeparture: ").Append(TimeDeparture.ToString("yyyy-MM-dd hh-mm"))
                  .Append("\nTimeExpected: ").Append(TimeExpected.ToString("yyyy-MM-dd hh-mm"))
                  .Append("\nTimeArrival: ").Append(TimeArrivalCast.ToString("yyyy-MM-dd hh-mm"))
                  .Append("\nTerminal: ").Append(Terminal)
                  .Append("\nGate: ").Append(Gate);
            }
            else
            {
                sb.Append("-------\n").
                   Append("Number: ").Append(Number)
                  .Append("\nPortArrival: ").Append(PortArrival)
                  .Append("\nPortDeparture: ").Append(PortDeparture)
                  .Append("\nAirline: ").Append(Airline)
                  .Append("\nStatus: ").Append(Status)
                  .Append("\nTimeDeparture: ").Append(TimeDeparture.ToString("yyyy-MM-dd hh-mm"))
                  .Append("\nTimeExpected: ").Append(TimeExpected.ToString("yyyy-MM-dd hh-mm"))
                  .Append("\nTimeArrival: ").Append("Not arrived yet")
                  .Append("\nTerminal: ").Append(Terminal)
                  .Append("\nGate: ").Append(Gate);
            }
            return sb.ToString();
        }

        #endregion

        public Flight()
        { }

        internal Flight(DateTime timeD, DateTime timeE, DateTime timeA, int number, string portD, string portA, string airline, string terminal, Flights.statusEnum statusE, string gate){
            TimeDeparture = timeD;
            TimeExpected = timeE;
            TimeArrival = timeA;
            Number = number;
            PortArrival = portA;
            PortDeparture = portD;
            Airline = airline;
            Terminal = terminal;
            StatusE=statusE;
            Status = StatusStringEnricher(statusE);
            Gate = gate;
        }

        internal Flight(DateTime timeD, DateTime timeE, int number,  string portD, string portA, string airline, string terminal, Flights.statusEnum statusE, string gate)
        {
            TimeDeparture = timeD;
            TimeExpected = timeE;
            Number = number;
            PortArrival = portA;
            PortDeparture = portD;
            Airline = airline;
            Terminal = terminal;
            StatusE = statusE;
            Status = StatusStringEnricher(statusE);
            Gate = gate;
        }

        internal Flight(int number, string portA, string portD, string airline, Flights.statusEnum statusE)
        {
            Number = number;
            PortArrival = portA;
            PortDeparture = portD;
            Airline = airline;
            StatusE = statusE;
            Status = StatusStringEnricher(statusE);
        }

        Flight(int number, Flights.statusEnum statusE)
        {
            Number = number;
            StatusE = statusE;
            Status = StatusStringEnricher(statusE);
        }


        string StatusStringEnricher(Flights.statusEnum se)
        {
            string res;
             switch (se)
            {
                case Flights.statusEnum.arrived:
                    res = "Arrived";
                        break;
                case Flights.statusEnum.canceled:
                    res = "Cancelled";
                    break;
                case Flights.statusEnum.checkIn:
                    res = "Check-in";
                    break;
                case Flights.statusEnum.delayed:
                    res = "Delayed";
                    break;
                case Flights.statusEnum.departedAt:
                    res = ("Departed at "+TimeDeparture);
                    break;
                case Flights.statusEnum.expectedAt:
                    res = ("Expected at" +TimeExpected);
                    break;
                case Flights.statusEnum.gateClosed:
                    res = "Gate closed";
                    break;
                case Flights.statusEnum.inFlight:
                    res = "In flight";
                    break;
                case Flights.statusEnum.unknown:
                    res = "Unknown";
                    break;
                default:
                    res = "Unknown";
                    break;
            }
            return res;
        }
    }
}