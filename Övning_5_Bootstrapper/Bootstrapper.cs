using System.Globalization;
using System.Resources;

using Övning_5_Business_Logic;
using Övning_5_Presentation_Logic;
using System;
using System.Configuration;
using System.Threading;
using Övning_5_Tools;

namespace Övning_5_Bootstrapper
{
    class Bootstrapper
    {
        static ResourceManager resourceManager;

        static void setupLanguage()
        {
            resourceManager = new ResourceManager("Övning_5_Bootstrapper.Resources.Resources", typeof(Bootstrapper).Assembly);

            string langauge = ConfigurationManager.AppSettings["language"];
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture(langauge);

            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }


        static void Main(string[] args)
        {

            setupLanguage();

            Input.ResourceManager = resourceManager;

            GarageHandler garageHandler = GarageHandler.GetInstance();

            garageHandler.SetCapacity(20);

            UI ui = new UI(resourceManager, garageHandler);

            ui.PrintMainMenu();

            while (true)
            {
                ConsoleWrapper.WritePreLine(resourceManager.GetString("Input_Command") + " ", 2);              
             
                Console.ForegroundColor = ConsoleColor.Green;
                String input = Console.ReadLine();

                bool success = false;

                if (!String.IsNullOrWhiteSpace(input) && input.Length == 1)
                {
                    char command = input[0];

                    if (ui.RunMenuAction(command))
                    {
                        success = true;
                    }                  
                }

                if (!success)
                { 
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    ConsoleWrapper.WritePreLine(resourceManager.GetString("Invalid_Command"));
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        
    }
}
