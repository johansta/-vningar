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
    class UI
    {      
        public UI(GarageHandler garageHandler)
        {
            Queue<Vehicle> queue = garageHandler.GetTestData();

            header = "Welcome to the garage application!";

            menuItems = new List<MenuItem>();

            menuItems.Add(new MenuItem('c', "create a garage with specific capacity", garageHandler.SetGarageCapacity));
            menuItems.Add(new MenuItem('p', "park a viechle", () => garageHandler.Park(queue)));
            menuItems.Add(new MenuItem('d', "drive viechle", garageHandler.Drive));
            menuItems.Add(new MenuItem('l', "list all viechles", garageHandler.ListVehicles));
            menuItems.Add(new MenuItem('g', "list all viechles by type and count each group", garageHandler.ListByVehicleType));
            menuItems.Add(new MenuItem('f', "find a car by licence number", garageHandler.FindVehicleByLicense));
            menuItems.Add(new MenuItem('a', "find a car by custom attribute", garageHandler.FindVehicleByAttributes));
            menuItems.Add(new MenuItem('q', "exit application", () => { return; }));
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
                return "Press " + Command + " to " + Description; 
            }
        }

        private String header;
        private List<MenuItem> menuItems; 

        public void PrintMainMenu()
        {
            WriteLine(header + Environment.NewLine);

            foreach(var menuItem in menuItems)
            {
                WriteLine(menuItem);
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
