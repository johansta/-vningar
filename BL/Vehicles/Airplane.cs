using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Bussiness_Logic.Vehicles
{
    public class Airplane : Vehicle
    {
        public int NumberOfParachutes { get; set; }

        public Airplane(String licence, int numberOfParachutes) : base(licence)
        {
            NumberOfParachutes = NumberOfParachutes;
        }

        public override String ToString()
        {
            return base.ToString() + Environment.NewLine + "NumberOfParachutes: " + NumberOfParachutes;
        }
    }
}
