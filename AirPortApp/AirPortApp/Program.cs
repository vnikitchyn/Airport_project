﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using static AirPortApp.Flights;
using static AirPortApp.StartMenu;

namespace AirPortApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (flightList.Any() == false)
            Helper.BuildInitial();
            Wellcome();
            string input = Console.ReadLine();
            Choices(input);
        }
    }
}
