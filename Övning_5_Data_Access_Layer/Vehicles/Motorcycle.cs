﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Data_Access_Layer.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public bool Silencer { get; set; }

        public Motorcycle(ResourceManager resourceManager, String licence, bool silencer) : base(resourceManager, licence)
        {
            Silencer = silencer;
        }

        public override String ToString()
        {
            return base.ToString() + Environment.NewLine + ResourceManager.GetString("Motorcycle_Silencer") + ": " + Silencer;
        }

        public new static List<ParameterInfo> GetParameters()
        {
            ParameterInfo parameterInfo = new ParameterInfo();
            parameterInfo.name = "Silencer";
            parameterInfo.type = typeof(bool);

            parameterInfo.tryParse = (string s, out object r) => {

                bool result = bool.TryParse(s, out bool v);
                r = v;
                return result;
            };

            List<ParameterInfo> parameters = Vehicle.GetParameters();
            parameters.Add(parameterInfo);

            return parameters;
        }
    }
}
