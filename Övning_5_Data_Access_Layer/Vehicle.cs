using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Data_Access_Layer
{

    public delegate bool TryParse(string s, out object result);
   
    public class ParameterInfo
    {
        public String name;
        public Type type;
        public TryParse tryParse;
        public Object value;
    }

    public abstract class Vehicle
    {
        /*public Vehicle()
        {

        }*/

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
            return "LicensePlate: " + licensePlate + Environment.NewLine + "Viechle Type: " + this.GetType().Name;
        }

        public static List<ParameterInfo> GetParameters()
        {
            ParameterInfo parameterInfo = new ParameterInfo();
            parameterInfo.name = "LicensePlate";
            parameterInfo.type = typeof(String);

            parameterInfo.tryParse = (string s, out object r) => {                           
                r = s;
                return true;
            };

            List<ParameterInfo> parameters = new List<ParameterInfo>();
            parameters.Add(parameterInfo);

            return parameters; 
        }
        
        //Using reflection
        public Dictionary<String, String> GetProperties()
        {
            PropertyInfo[] props = GetType().GetProperties();

            Dictionary<String, String> result = new Dictionary<String, String>();

            foreach (var prop in props)
            {
                result.Add(prop.Name, prop.GetValue(this).ToString());
            }

            return result;
        }
    }
}
