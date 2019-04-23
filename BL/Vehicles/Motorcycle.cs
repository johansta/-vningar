using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Bussiness_Logic.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public bool Silencer { get; set; }

        public Motorcycle(String licence, bool silencer) : base(licence)
        {
            Silencer = silencer;
        }

        public override String ToString()
        {
            return base.ToString() + Environment.NewLine + "Silencer: " + Silencer;
        }
    }
}
