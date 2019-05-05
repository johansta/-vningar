using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Data_Access_Layer.Vehicles
{
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public Bus(String licence, int numberOfSeats) : base(licence)
        {
            NumberOfSeats = numberOfSeats;
        }       
     
        public new static List<ParameterInfo> GetParameters()
        {
            ParameterInfo parameterInfo = new ParameterInfo();
            parameterInfo.name = "NumberOfSeats";
            parameterInfo.type = typeof(int);

            parameterInfo.tryParse = (string s, out object r) => {

                bool result = Int32.TryParse(s, out int v);
                r = v;
                return result;
            };

            /*List<string> arguments = new List<string>();
            arguments.Add("1 - 512");

            parameterInfo.arguments = arguments;*/

            List<ParameterInfo> parameters = Vehicle.GetParameters();
            parameters.Add(parameterInfo);

            return parameters;
        }


    }
}
