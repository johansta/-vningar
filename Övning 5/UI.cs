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
        public UI()
        {
            header = "Welcome to the garage application!";

            menuItems = new List<MenuItem>();

            menuItems.Add(new MenuItem('c', "create a garage with specific capacity"));
            menuItems.Add(new MenuItem('p', "park a viechle"));
            menuItems.Add(new MenuItem('d', "drive viechle"));
            menuItems.Add(new MenuItem('l', "list all viechles"));
            menuItems.Add(new MenuItem('g', "list all viechles by type and count each group"));
            menuItems.Add(new MenuItem('f', "find a car by licence number"));
            menuItems.Add(new MenuItem('a', "find a car by custom attribute"));
            menuItems.Add(new MenuItem('q', "exit application"));
        }

        private class MenuItem
        {
            public MenuItem(char command,String info)
            {
                Command = command;
                Description = info;          
            }

            public char Command { get; set; }
            public String Description { get; set; }
       
            public override string ToString()
            {
                return "Press " + Command + " to " + Description; 
            }
        }

        private String header;
        private List<MenuItem> menuItems; 

        public void PrintMainMenu()
        {
            WriteLine(header);

            foreach(var menuItem in menuItems)
            {
                WriteLine(menuItem);
            }         
        }
    }
}
