using Övning_5_Resources;
using Övning_5_Tools;
using System;
using System.Collections.Generic;

namespace Övning_5_Presentation_Layer.UserInterfaces
{
    public class MainMenu : UserInterface
    {
        public MainMenu(ResourceContext resourceContext, InputHandler inputHandler, ValidationHandler validationHandler, GarageHandler garageHandler) : base(resourceContext, inputHandler, validationHandler)
        {
            UserInterface garageMenu = new GarageMenu(resourceContext, inputHandler, validationHandler, garageHandler);

            header = ResourceContext.Language.GetString("Menu_Header");

            menuItems = new List<MenuItem>();

            menuItems.Add(new MenuItem('c', ResourceContext.Language.GetString("Menu_Create_Garage"), () => {   garageHandler.InputGarageCapacity();
                                                                                                                garageMenu.Run();}));
            menuItems.Add(new MenuItem('h', ResourceContext.Language.GetString("Menu_Help"), ListHelp));
            menuItems.Add(new MenuItem('q', ResourceContext.Language.GetString("Menu_Exit"), Exit));
        }

        private void ListHelp()
        {
            Console.WriteLine();
            ConsoleWrapper.WriteLine("{0} - {1}",
                                    new object[] { ResourceContext.Language.GetString("Help_Green"), ResourceContext.Language.GetString("Help_Green_Description") },
                                    new ConsoleColor[] { ConsoleColor.Green, ConsoleColor.White });

            ConsoleWrapper.WriteLine("{0} - {1}",
                                    new object[] { ResourceContext.Language.GetString("Help_Blue"), ResourceContext.Language.GetString("Help_Blue_Description") },
                                    new ConsoleColor[] { ConsoleColor.Blue, ConsoleColor.White });

            ConsoleWrapper.WriteLine("{0} - {1}",
                                    new object[] { ResourceContext.Language.GetString("Help_Yellow"), ResourceContext.Language.GetString("Help_Yellow_Description") },
                                    new ConsoleColor[] { ConsoleColor.Yellow, ConsoleColor.White });

            ConsoleWrapper.WriteLine("{0} - {1}",
                                    new object[] { ResourceContext.Language.GetString("Help_Red"), ResourceContext.Language.GetString("Help_Red_Description") },
                                    new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.White });
        }
    }
}
