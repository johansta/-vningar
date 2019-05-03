using System.Resources;

using Övning_5_Tools;

using Övning_5_Business_Layer;
using Övning_5_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Övning_5_Presentation_Layer
{
    public abstract class UserInterface
    {
        protected UserInterface(ResourceManager resourceManager)
        {
            ResourceManager = resourceManager;
        }

        public ResourceManager ResourceManager { get; protected set; }
        protected String header;
        protected List<MenuItem> menuItems;
        private bool running;

        public void PrintMenu(bool printHeader = false)
        {
            if (printHeader && this.header != null)
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
            PrintMenu(true);

            running = true;

            while (running)
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

                        if (running)
                        {
                            PrintMenu();
                        }
                    }
                }

                if (!success)
                {
                    ConsoleWrapper.WritePreLine(ResourceManager.GetString("Invalid_Command"), ConsoleColor.Red);
                }
            }
        }

        protected void Exit()
        {
            running = false;
        }
    }
}
