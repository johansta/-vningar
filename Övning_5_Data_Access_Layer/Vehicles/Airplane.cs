using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Data_Access_Layer.Vehicles
{
    public class Airplane : Vehicle
    {
        public int NumberOfParachutes { get; set; }

        public Airplane(String licence, int numberOfParachutes) : base(licence)
        {
            NumberOfParachutes = numberOfParachutes;           
        }
   
        public new static List<ParameterInfo> GetParameters()
        {
            ParameterInfo parameterInfo = new ParameterInfo();
            parameterInfo.name = "NumberOfParachutes";
            parameterInfo.type = typeof(int);

            parameterInfo.tryParse = (string s, out object r) => {

                bool result = Int32.TryParse(s, out int v);
                r = v;
                return result;
            };

            List<string> arguments = new List<string>();
            arguments.Add("0 - 512");

            parameterInfo.arguments = arguments;

            List<ParameterInfo> parameters = Vehicle.GetParameters();
            parameters.Add(parameterInfo);

            return parameters;
        }
    }
}
