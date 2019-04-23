using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Bussiness_Logic.Vehicles
{
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public Bus(String licence, int numberOfSeats) : base(licence)
        {
            NumberOfSeats = numberOfSeats;
        }

        public override String ToString()
        {
            return base.ToString() + Environment.NewLine + "NumberOfSeats: " + NumberOfSeats;
        }
    }
}
