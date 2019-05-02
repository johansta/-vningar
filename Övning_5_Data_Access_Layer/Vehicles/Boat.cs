using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Data_Access_Layer.Vehicles
{
    public class Boat : Vehicle
    {
        public int NumberOfEngines { get; set; }

        public Boat(ResourceManager resourceManager, String licence, int numberOfEngines) : base(resourceManager, licence)
        {
            NumberOfEngines = numberOfEngines;
        }

        public override String ToString()
        {
            return base.ToString() + Environment.NewLine + ResourceManager.GetString("Boat_NumberOfEngines") + ": " + NumberOfEngines;
        }
     
        public new static List<ParameterInfo> GetParameters()
        {
            ParameterInfo parameterInfo = new ParameterInfo();
            parameterInfo.name = "NumberOfEngines";
            parameterInfo.type = typeof(int);

            parameterInfo.tryParse = (string s, out object r) => {

                bool result = Int32.TryParse(s, out int v);
                r = v;
                return result;
            };

            List<ParameterInfo> parameters = Vehicle.GetParameters();
            parameters.Add(parameterInfo);

            return parameters;
        }
    }
}
