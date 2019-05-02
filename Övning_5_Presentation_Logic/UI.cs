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
    public class UI
    {      
        public UI(ResourceManager resourceManager, GarageHandler garageHandler)
        {
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

        private class MenuItem
        {
            public MenuItem(char command,String info, Action action)
            {
                Command = command;
                Description = info;
                Action = action;
            }

            public char Command { get; set; }
            public String Description { get; set; }
            public Action Action { get; set; }

            public override string ToString()
            {
                return Command + ": " + Description; 
            }
        }

        private String header;
        private List<MenuItem> menuItems; 

        public void PrintMainMenu()
        {
            WriteLine(header + Environment.NewLine);

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
    }
}
