using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AirPortApp
{
    internal class Flight
    { 
        #region properties and fields: all string except Number
        public DateTime Time {get;set; }     //date and time
        public int Number    { get; set; }   //flight number
        public string Port { get; set; }     //city/port of arrival(departure)
        public string Airline { get; set; }  //Airline company
        public string Terminal { get; set; } // Terminal
        internal enum statusEnum {checkIn, gateClosed,arrived,departedAt,unknown,canceled,expectedAt,delayed,inFlight}//"check-in","gate closed","arrived","departed at","unknown","canceled","expected at","delayed","in flight"
        public statusEnum StatusE { get; set; } // status        
        public string Status { get; set; }
        public string Gate { get; set; } // gate

     

        #endregion

        Flight(DateTime time, int number, string port, string airline, string terminal, statusEnum statusE, string gate){
            Time = time;
            Number = number;
            Port = port;
            Airline = airline;
            Terminal = terminal;
            StatusE=statusE;
            Status = StatusStringEnricher(statusE);
            Gate = gate;
        }
 
        string StatusStringEnricher(statusEnum se)
        {
            string res;
             switch (se)
            {
                case statusEnum.arrived:
                    res = "Arrived";
                        break;
                case statusEnum.canceled:
                    res = "Cancelled";
                    break;
                case statusEnum.checkIn:
                    res = "Check-in";
                    break;
                case statusEnum.delayed:
                    res = "Delayed";
                    break;
                case statusEnum.departedAt:
                    res = "Departed at";
                    break;
                case statusEnum.expectedAt:
                    res = "Expected at";
                    break;
                case statusEnum.gateClosed:
                    res = "Gate closed";
                    break;
                case statusEnum.inFlight:
                    res = "In flight";
                    break;
                case statusEnum.unknown:
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
