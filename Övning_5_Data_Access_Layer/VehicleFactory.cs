using Övning_5_Data_Access_Layer.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Data_Access_Layer
{
    public enum VehicleType
    {
        AIRPLANE,
        BOAT,
        BUS,
        CAR,
        MOTORCYLE
    }

    public class VehicleFactory
    {
        public Vehicle GetVehicle(VehicleType vehicleType)
        {
            /*switch (vehicleType)
            {
                case VehicleType.AIRPLANE:
                    return new Airplane();
                case VehicleType.BOAT:
                    return new Boat();
                case VehicleType.BUS:
                    return new Bus();
                case VehicleType.CAR:
                    return new Car();
                case VehicleType.MOTORCYLE:
                    return new Motorcycle();
                default:
                    throw new NotSupportedException();
            }*/

            return null;
        }

        public List<ParameterInfo> GetParameters(VehicleType vehicleType)
        {
            switch (vehicleType)
            {
                case VehicleType.AIRPLANE:
                    return Airplane.GetParameters();
                case VehicleType.BOAT:
                    return Boat.GetParameters();
                case VehicleType.BUS:
                    return Bus.GetParameters();
                case VehicleType.CAR:
                    return Car.GetParameters();
                case VehicleType.MOTORCYLE:
                    return Motorcycle.GetParameters();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
