using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Data_Access_Layer.Vehicles
{
    public enum FuelType
    {
        GASOLINE,
        DIESEL
    };

    public class Car : Vehicle
    {
        public FuelType FuelType { get; set; }

        public Car(ResourceManager resourceManager, String licence, FuelType fuelType) : base(resourceManager, licence)
        {
            FuelType = fuelType;
        }

        public override String ToString()
        {
            return base.ToString() + Environment.NewLine + ResourceManager.GetString("Car_FuelType") + ": " + FuelType;
        }

        public new static List<ParameterInfo> GetParameters()
        {
            ParameterInfo parameterInfo = new ParameterInfo();
            parameterInfo.name = "FuelType";
            parameterInfo.type = typeof(FuelType);
         
            parameterInfo.tryParse = (string s, out object r) => {

                bool result = Enum.TryParse(s, out FuelType v);
                r = v;
                return result;
            };

            List<ParameterInfo> parameters = Vehicle.GetParameters();
            parameters.Add(parameterInfo);

            return parameters;
        }
    }
}
