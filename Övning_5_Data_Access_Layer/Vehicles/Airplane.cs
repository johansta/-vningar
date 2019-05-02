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

        public Airplane(ResourceManager resourceManager, String licence, int numberOfParachutes) : base(resourceManager, licence)
        {
            NumberOfParachutes = numberOfParachutes;
        }

        public override String ToString()
        {
            return base.ToString() + Environment.NewLine + ResourceManager.GetString("Airplane_NumberOfParachutes") + ": " + NumberOfParachutes;
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

            List<ParameterInfo> parameters = Vehicle.GetParameters();
            parameters.Add(parameterInfo);

            return parameters;
        }
    }
}
