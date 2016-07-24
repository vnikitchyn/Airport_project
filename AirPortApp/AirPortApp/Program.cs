using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace AirPortApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Flights.flightList.Any()==false)
            Flights.BuildInitial();
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
                        Flights.Input();
                        input = Console.ReadLine();
                        break;

                    case "showall":
                        Console.WriteLine("You chose show all option.");
                        Flights.ShowAll();
                        input = Console.ReadLine();
                        break;

                    case "find":
                        Console.Clear();
                        Console.WriteLine("You chose find option. Please choose now subcategory of the search"
                            + "\nPossible seacrhes are:n\'number' - by flight number\n'portA' - by port of arrival \n'timeA' - by time of arrival");
                        string inputF = Console.ReadLine();
                        int number;
                        DateTime time;

                        switch (inputF) {
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
                        Flights.Find(number);
                        input = Console.ReadLine();
                        break;
                            case "portA":
                                Console.WriteLine("You chose 'find by port of arrival' option. Please enter port of arrival you want to find");
                                inputF = Console.ReadLine();
                                Flights.Find(inputF);
                                input = Console.ReadLine();
                                break;
                            case "timeA":
                                Console.WriteLine("You chose 'find by time of arrival' option. Please enter time of arrival of the flight you want to find \nin format: 'yyyy-MM-dd hh-mm'");
                                inputF = Console.ReadLine();

                               while(DateTime.TryParseExact(inputF, "yyyy-MM-dd hh-mm",null,DateTimeStyles.AssumeUniversal,out time) == false)          
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("It looks you made a mistake, please re-enter time of arrival of the flight you want to find \nin format: 'yyyy-MM-dd hh-mm'");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    inputF = Console.ReadLine();
                                }
                                Flights.Find(time);
                                input = Console.ReadLine();
                                break;

                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("It looks as mistake, please re-enter the keyword");
                                Console.ForegroundColor = ConsoleColor.White;
                                inputF = Console.ReadLine();
                                break;

                        }
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
                        Flights.Delete(number);
                        input = Console.ReadLine();
                        break;
                    case "show all":
                        Console.WriteLine("You chose show all option.\n");
                        Flights.ShowAll();
                        input = Console.ReadLine();
                        break;

                    case "edit":



                        break;
                    case "exit":
                        Console.WriteLine("You are leaving the app. Press any key...");
                        Console.In.Close();
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("It looks as mistake, please re-enter the keyword");
                        input = Console.ReadLine();
                        Choices(input);
                        break;
                }
            }
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
                ; 
           MessageBox.Show(wellcome+"\n"+wellcomeConsole, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                Console.Title = "Airport application";
                Console.WindowWidth = 150;
                Console.WriteLine(wellcomeConsole);
              } 

    }

}
