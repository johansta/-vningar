using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Presentation_Logic
{
    public class MenuItem
    {
        internal MenuItem(char command, String info, Action action)
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
}
