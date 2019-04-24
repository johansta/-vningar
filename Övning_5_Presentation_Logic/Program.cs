using Övning_5_Business_Logic;
using Övning_5_Business_Logic.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Presentation_Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            GarageHandler garageHandler = GarageHandler.GetInstance();

            //Queue<Vehicle> queue = garageHandler.GetTestData();
            garageHandler.SetCapacity(10);

            UI ui = new UI(garageHandler);

            while (true)
            {
                ui.PrintMainMenu();

                Console.Write(Environment.NewLine + "Input command: ");

                String input = Console.ReadLine();

                bool success = false;

                if (!String.IsNullOrWhiteSpace(input) && input.Length == 1)
                {
                    char command = input[0];

                    if (ui.RunMenuAction(command))
                    {
                        success = true;

                        //Console.WriteLine("Press any key to continue..." + Environment.NewLine);
                        //Console.ReadKey();
                    }                  
                }

                if (!success)
                { 
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(Environment.NewLine + "Invalid command, try again." + Environment.NewLine);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        
    }
}
