using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Data_Access_Layer
{
    public delegate bool TryParse(string s, out object result);
   
    public class ParameterInfo
    {
        public String name;
        public Object value;
        public TryParse tryParse;
    }

    public abstract class Vehicle
    {

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
         
        public static List<ParameterInfo> GetParameters()
        {
            ParameterInfo parameterInfo = new ParameterInfo();
            parameterInfo.name = "LicensePlate";        

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
