using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using static AirPortApp.Flights;

namespace AirPortApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Flights.flightList.Any()==false)
            Helper.BuildInitial();
            Wellcome();
            string input = Console.ReadLine();
            Choices(input);

        }

        static void Choices(string input)
        {
            while (!input.Equals("exit"))
            {
                switch (input.Replace(" ", String.Empty).ToLower())
                {
                    case "add":
                        Console.WriteLine("You chose add option.");
                        Input();
                        input = Console.ReadLine();
                        break;

                    case "showall":
                        Console.WriteLine("You chose show all option.");
                        ShowAll();
                        input = Console.ReadLine();
                        break;

                    case "find":
                        Console.Clear();
                        string findMenuHelp =("\nPossible seacrhes are:"
                            + "\n'number' - by flight number\n'portA' - by port of arrival \n'portD' - by port of departure"
                            + "\n'timeA' - by time of arrival"
                            + "\ntimeNear - finding nearest races (appr to 1 hour"
                            + "\n'exit' - exit from find menu \n'help' - find menu help"
                           );
                        Console.WriteLine("You chose find option. Please choose now subcategory of the search" + findMenuHelp);   
                        string inputF = Console.ReadLine();
                        int number;
                        DateTime time;

                        while (!inputF.Equals("exit"))
                        {
                            switch (inputF)
                            {
                                case "number":
                                    Console.WriteLine("You chose 'find by number' option. Please enter flight number you want to find");
                                    inputF = Console.ReadLine();

                                    while (int.TryParse(inputF, out number) == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("It looks you made a mistake, please enter flight number (in integer) again");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        inputF = Console.ReadLine();
                                    }
                                    Find(number);
                                    inputF = Console.ReadLine();
                                    break;
                                case "portA":
                                    Console.WriteLine("You chose 'find by port of arrival' option. Please enter port of arrival you want to find");
                                    inputF = Console.ReadLine();
                                    FindArrivalPort(inputF);
                                    inputF = Console.ReadLine();
                                    break;
                                case "portD":
                                    Console.WriteLine("You chose 'find by port of departure' option. Please enter port of departure you want to find");
                                    inputF = Console.ReadLine();
                                    FindDeparturePort(inputF);
                                    inputF = Console.ReadLine();
                                    break;
                                case "timeA":
                                    Console.WriteLine("You chose 'find by time of arrival' option. Please enter time of arrival of the flight you want to find \nin format: 'yyyy-MM-dd hh-mm'");
                                    inputF = Console.ReadLine();

                                    while (DateTime.TryParseExact(inputF, "yyyy-MM-dd hh-mm", null, DateTimeStyles.None, out time) == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("It looks you made a mistake, please re-enter time of arrival of the flight you want to find \nin format: 'yyyy-MM-dd hh-mm'");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        inputF = Console.ReadLine();
                                    }
                                    Find(time);
                                    inputF = Console.ReadLine();
                                    break;

                                case "timeNear":
                                    Console.WriteLine("You chose 'find near 1 hour' option. \nPlease enter airport you are interesting in...");
                                    string port = Console.ReadLine();
                                    Console.WriteLine("\nNow please enter time and app will show nearset flights\nin format: 'yyyy-MM-dd hh-mm'");
                                    inputF = Console.ReadLine();

                                    while (DateTime.TryParseExact(inputF, "yyyy-MM-dd hh-mm", null, DateTimeStyles.None, out time) == false)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("It looks you made a mistake, please re-enter time of arrival of the flight you want to find \nin format: 'yyyy-MM-dd hh-mm'");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        inputF = Console.ReadLine();
                                    }
                                    FindNear(time,port);
                                    inputF = Console.ReadLine();
                                    break;


                                case "help":
                                    Console.WriteLine(findMenuHelp);
                                    inputF = Console.ReadLine();
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("It looks as mistake, please re-enter the keyword/nTo see all options of find menu, please type 'help'");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    inputF = Console.ReadLine();
                                    break;
                            }
                        }
                        Console.Clear();
                        Console.WriteLine(returnMes);
                        input = Console.ReadLine();
                        break;

                    case "delete":
                        Console.WriteLine("You chose delete option. Please enter flight number you want to delete");
                        input = Console.ReadLine();
//                        number=0;
                        while (int.TryParse(input,out number) == false)
                        {
                            Console.WriteLine("It looks you made a mistake, please enter flight number (in integer) again");
                            input = Console.ReadLine();
                        }
                        Delete(number);
                        input = Console.ReadLine();
                        break;
                    case "show all":
                        Console.WriteLine("You chose show all option.\n");
                        ShowAll();
                        input = Console.ReadLine();
                        break;

                    case "help":
                        Console.WriteLine("\nPossible options are:\n\n"
                        + "add - you can add new fight to global flight list \n\n"
                        + "find - you can find a flight by its number \n\n"
                        + "delete -  you can delete a flight by its number \n\n"
                        + "show all - you can se current flight list \n\n"
                        + "edit - you can edit flight record \n\n"
                        + "exit - you can edit flight record \n\n"
                        + "help - to see this menu again \n");
                        input = Console.ReadLine();
                        break;
                    case "emergency":
                        Console.WriteLine("All emergency messages are below:\n");
                        foreach (string emergEnum in Enum.GetNames(typeof(emergencyEnum)))
                        {
                            emergencyEnum en = (emergencyEnum)Enum.Parse(typeof(emergencyEnum), emergEnum);
                            //Console.WriteLine("{0}: {1}\n",emergEnum,(byte)en); // en.ToString("D") same as (byte) en
                            Console.WriteLine("{0}:\n{1}\n",emergEnum, Emergency(en));
                        }

                        input = Console.ReadLine();
                        break;

                    case "edit":


                        input = Console.ReadLine();
                        break;
  
                    default:
                        Console.WriteLine("It looks as mistake, please re-enter the keyword. To see all options, plesase type 'help'");
                        input = Console.ReadLine();
                        Choices(input);
                        break;
                }
            }
            Console.WriteLine("You are leaving this wonder application\nDeveloper hopes you will be back..");
            Console.ReadKey();
        }
         
        static void Wellcome()
        {
            string caption = "Airport application";
            string wellcome = "This app emulates airport managament\n"
                                + "It can do some actions with flights: get info, add records and so on.\n";
            string wellcomeConsole = wellcome
                + "Possible options are:\n\n"
                + "add - you can add new fight to global flight list \n\n"
                + "find - you can find a flight by its number \n\n"
                + "delete -  you can delete a flight by its number \n\n"
                + "show all - you can se current flight list \n\n"
                + "edit - you can edit flight record \n\n"
                + "exit - you can edit flight record \n\n"
                + "help - to see this menu again \n"
                ;
            MessageBox.Show(wellcome+"\n"+wellcomeConsole, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Console.Title = "Airport application";
                Console.WindowWidth = 150;
                Console.WriteLine(wellcomeConsole);
              } 
    }
}
