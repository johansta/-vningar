using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Business_Logic.Vehicles
{
    public class Boat : Vehicle
    {
        public int NumberOfEngines { get; set; }

        public Boat(String licence, int numberOfEngines) : base(licence)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override String ToString()
        {
            return base.ToString() + Environment.NewLine + "NumberOfEngines: " + NumberOfEngines;
        }
    }
}
