using System.Resources;

using Övning_5_Tools;

using Övning_5_Business_Logic;
using Övning_5_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Övning_5_Presentation_Logic
{
    public class UserInterface
    {      
        public UserInterface(ResourceManager resourceManager, GarageHandler garageHandler)
        {
            ResourceManager = resourceManager;

            header = resourceManager.GetString("Menu_Header");

            menuItems = new List<MenuItem>();

            menuItems.Add(new MenuItem('c', resourceManager.GetString("Menu_Create_Garage") , garageHandler.SetGarageCapacity));
            menuItems.Add(new MenuItem('p', resourceManager.GetString("Menu_Park_Vehicle"), () => garageHandler.Park()));
            menuItems.Add(new MenuItem('d', resourceManager.GetString("Menu_Drive_Vehicle"), garageHandler.Drive));
            menuItems.Add(new MenuItem('l', resourceManager.GetString("Menu_List_Vehicles"), garageHandler.ListVehicles));
            menuItems.Add(new MenuItem('g', resourceManager.GetString("Menu_Group_Vehicles"), garageHandler.ListByVehicleType));
            menuItems.Add(new MenuItem('s', resourceManager.GetString("Menu_Search_License"), garageHandler.FindVehicleByLicense));
            menuItems.Add(new MenuItem('a', resourceManager.GetString("Menu_Search_Attribute"), garageHandler.FindVehicleByAttributes));
            menuItems.Add(new MenuItem('q', resourceManager.GetString("Menu_Exit"), () => { return; }));
        }

        public ResourceManager ResourceManager { get; private set; }
        private String header;
        private List<MenuItem> menuItems; 

        public void PrintMainMenu(bool header = false)
        {
            if (header)
            {
                WriteLine(header);
            }

            foreach(var menuItem in menuItems)
            {
                ConsoleWrapper.Write(Environment.NewLine + "{0} -> {1}",
                   new object[] { menuItem.Command, menuItem.Description },
                   new ConsoleColor[] { ConsoleColor.Green, ConsoleColor.White});
            }         
        }

        public bool RunMenuAction(char command)
        {
            IEnumerable<MenuItem> result = menuItems.Where(x => x.Command == command);

            if (result.Count() == 1)
            {
                MenuItem menuItem = result.ToArray()[0];
                menuItem.Action();

                return true;
            }
                                
            return false;
        }

        public void Run()
        {
            PrintMainMenu(true);

            while (true)
            {
                ConsoleWrapper.WritePreLine(ResourceManager.GetString("Input_Command") + " ", 2);

                String input = ConsoleWrapper.ReadLine(ConsoleColor.Green);

                bool success = false;

                if (!String.IsNullOrWhiteSpace(input) && input.Length == 1)
                {
                    char command = input[0];

                    if (RunMenuAction(command))
                    {
                        success = true;
                        PrintMainMenu();
                    }
                }

                if (!success)
                {
                    ConsoleWrapper.WritePreLine(ResourceManager.GetString("Invalid_Command"), ConsoleColor.Red);
                }
            }
        }
    }
}
