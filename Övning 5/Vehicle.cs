using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5
{
    abstract class Vehicle
    {
        public Vehicle(String licensePlate)
        {
            LicensePlate = licensePlate;
        }

        private String licensePlate;

        public String LicensePlate
        {
            get { return licensePlate; }
            set { licensePlate = value; }
        }

        public override String ToString()
        {
            return "LicensePlate: " + licensePlate + " Viechle Type: " + this.GetType();
        }
    }
}
