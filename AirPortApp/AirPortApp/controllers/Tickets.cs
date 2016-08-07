using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//–IComplarable, IComparer, IEnumerable in searching

namespace AirPortApp
{
   public static class Tickets
    {
        public static List<Ticket> TicketsList { get; set; }


        internal static void FindT(int number) //IEnumerator
        {
            bool find = false;
            var tickets = TicketsList.GetEnumerator();

            while (tickets.Current != null)
            {
                if (number.Equals(tickets.Current.Number))
                    Console.WriteLine(tickets.Current.ToString());
                tickets.MoveNext();
                find = true;
            }
            if (find == false)
            {
                Console.WriteLine("Such flight is not found");
            }
            else
            {
                Console.WriteLine(Flights.returnMesFind);
            }
        }

        internal static void FindName(double price, int number) //Enumerable
        {
            bool find = false;
            var tickets = TicketsList.AsEnumerable<Ticket>();

            foreach (Ticket ticket in tickets)
            {
                if (price.Equals(ticket.Price)&&number.Equals(ticket.Number))
                    Console.WriteLine(ticket.ToString());
                find = true;
            }
            if (find == false)
            {
                Console.WriteLine("Such flight is not found");
            }
            else
            {
                Console.WriteLine(Flights.returnMesFind);
            }
        }



        internal static void PriceMore(double price) //IComparer for sorting
        {
            bool find = false;
            PriceCompare <Ticket> pCompare = new PriceCompare<Ticket>();
            TicketsList.Sort(pCompare);
            foreach (Ticket ticket in TicketsList)
            {
                if (ticket.Price>price)
                    Console.WriteLine(ticket.ToString());
                find = true;
            }
            if (find == false)
            {
                Console.WriteLine("Such flight is not found");
            }
            else
            {
                Console.WriteLine(Flights.returnMesFind);
            }
        }

        internal static void PriceLess(double price) //IComparable for sorting
        {
            bool find = false;
            TicketsList.Sort();
            foreach (Ticket ticket in TicketsList)
            {
                if (ticket.Price < price)
                    Console.WriteLine(ticket.ToString());
                find = true;
            }
            if (find == false)
            {
                Console.WriteLine("Such flight is not found");
            }
            else
            {
                Console.WriteLine(Flights.returnMesFind);
            }
        }
    }


    class PriceCompare <T>: IComparer<T> //IComparer
        where T : Ticket
    {
        public int Compare(T x, T y)
        {
            if (x.Price < y.Price)
                return -1;
            if (x.Price > y.Price)
                return 1;
            else return 0;
        }
    }

    }
