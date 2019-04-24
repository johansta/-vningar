using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Business_Logic
{   
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

        public override String ToString()
        {
            return "LicensePlate: " + licensePlate + Environment.NewLine + "Viechle Type: " + this.GetType().Name;
        }

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
