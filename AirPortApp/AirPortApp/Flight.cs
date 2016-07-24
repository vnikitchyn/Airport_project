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
        enum statusEnum {checkIn, gateClosed,arrived,departedAt,unknown,canceled,expectedAt,delayed,inFlight}//"check-in","gate closed","arrived","departed at","unknown","canceled","expected at","delayed","in flight"
        private string status;        
        public string Gate { get; set; } // gate

        public string Status
        {   get
            {
                return status;
            }
            set
            {
                statusEnum.inFlight=
                if (statusEnum.arrived.Equals) 
                status = value;
            }
        }
        #endregion

        Flight(DateTime time, int number, string port, string airline, string terminal, statusEnum status, string gate){
            Time = time;
            Number = number;
            Port = port;
            Airline = airline;
            Terminal = terminal;
            Status=status.ToString();
            Gate = gate;
        }
            

    }
}
