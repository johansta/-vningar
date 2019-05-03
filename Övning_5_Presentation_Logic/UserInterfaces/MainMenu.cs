using Övning_5_Business_Logic;
using Övning_5_Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Presentation_Logic.UserInterfaces
{
    public class MainMenu : UserInterface
    {
        public MainMenu(ResourceManager resourceManager, GarageHandler garageHandler) : base(resourceManager)
        {
            UserInterface garageMenu = new GarageMenu(resourceManager, garageHandler);
   
            header = resourceManager.GetString("Menu_Header");

            menuItems = new List<MenuItem>();

            menuItems.Add(new MenuItem('c', resourceManager.GetString("Menu_Create_Garage"), () => { garageHandler.SetGarageCapacity();
                                                                                                     garageMenu.Run();}));
            menuItems.Add(new MenuItem('h', resourceManager.GetString("Menu_Help"), Help));
            menuItems.Add(new MenuItem('q', resourceManager.GetString("Menu_Exit"), Exit));
        }

        private void Help()
        {
            Console.WriteLine();
            ConsoleWrapper.WriteLine("{0} - {1}",
                                    new object[] { ResourceManager.GetString("Help_Green"), ResourceManager.GetString("Help_Green_Description") },
                                    new ConsoleColor[] { ConsoleColor.Green, ConsoleColor.White });

            ConsoleWrapper.WriteLine("{0} - {1}",
                                    new object[] { ResourceManager.GetString("Help_Blue"), ResourceManager.GetString("Help_Blue_Description") },
                                    new ConsoleColor[] { ConsoleColor.Blue, ConsoleColor.White });

            ConsoleWrapper.WriteLine("{0} - {1}",
                                    new object[] { ResourceManager.GetString("Help_Yellow"), ResourceManager.GetString("Help_Yellow_Description") },
                                    new ConsoleColor[] { ConsoleColor.Yellow, ConsoleColor.White });

            ConsoleWrapper.WriteLine("{0} - {1}",
                                    new object[] { ResourceManager.GetString("Help_Red"), ResourceManager.GetString("Help_Red_Description") },
                                    new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.White });
        }
    }
}
