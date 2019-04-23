using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Bussiness_Logic.Vehicles
{
    public enum FuelType
    {
        GASOLINE,
        DIESEL
    };

    public class Car : Vehicle
    {
        public FuelType FuelType { get; set; }

        public Car(String licence, FuelType fuelType) : base(licence)
        {
            FuelType = fuelType;
        }

        public override String ToString()
        {
            return base.ToString() + Environment.NewLine + "FuelType: " + FuelType;
        }
    }
}
