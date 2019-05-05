﻿using System;
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

        public Car(String licence, FuelType fuelType) : base(licence)
        {
            FuelType = fuelType;
        }
      
        public new static List<ParameterInfo> GetParameters()
        {
            ParameterInfo parameterInfo = new ParameterInfo();
            parameterInfo.name = "FuelType";
            parameterInfo.type = typeof(FuelType);
         
            parameterInfo.tryParse = (string s, out object r) => {

                bool result = Enum.TryParse(s, true, out FuelType v);
                r = v;
                return result;
            };

            /*List<string> arguments = new List<string>();
            arguments.Add(FuelType.GASOLINE.ToString());
            arguments.Add(FuelType.DIESEL.ToString());

            parameterInfo.arguments = arguments;*/

            List<ParameterInfo> parameters = Vehicle.GetParameters();
            parameters.Add(parameterInfo);

            return parameters;
        }
    }
}
