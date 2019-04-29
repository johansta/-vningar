using Övning_5_Data_Access_Layer;
using Övning_5_Data_Access_Layer.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Tools
{
    public class Input
    {
        public static Vehicle InputVehicle2()
        {
            Console.Write(Environment.NewLine + "Choose vehicle type to park:");

            foreach (VehicleType vehicleType in Enum.GetValues(typeof(VehicleType)))
            {
                Console.Write(Environment.NewLine + vehicleType);
            }

            int input = Console.Read();

            while (!Enum.IsDefined(typeof(VehicleType), input))
            {
                Console.Write(Environment.NewLine + "Invalid option, try again:");
                input = Console.Read();
            }

            VehicleType inputVehicleType = (VehicleType)input;

            VehicleFactory vehicleFactory = new VehicleFactory();

            List<ParameterInfo> parameters = vehicleFactory.GetParameters(inputVehicleType);

            foreach (var param in parameters)
            {
                String input2 = Console.ReadLine();

                //TryParse(input2, param);

                /*while (parameters)
                {
                    Console.Write(Environment.NewLine + "Invalid option, try again:");
                    input = Console.Read();
                }*/
            }

            return vehicleFactory.GetVehicle(inputVehicleType);

            
        }

        /*private static bool TryParse(String input, ParameterInfo param, out Object output)
        {
            if (param.type is Int32)
            {
                if (Int32.TryParse(input, out int result))
                {
                    output = result;
                    return true;
                }

            }
            else if (param.type is bool)
            {
                if (bool.TryParse(input, out bool result))
                {
                    output = result;
                    return true;
                }
            }
            else if (param.type is FuelType)
            {
                if (Enum.TryParse(input, out FuelType result))
                {
                    output = result;
                    return true;
                }
            }
            else if (param.type is String)
            {
                output = input;
                return true;
            }

            output = null;
            return false;
        }*/

        //Using reflection
        public static Vehicle InputVehicle()
        {
            Dictionary<String, object> paramDictionary = new Dictionary<String, object>();

            Console.Write(Environment.NewLine + "Input vehicle type to park:");
            String vehicleType = Console.ReadLine();

            String fullVehicleType = "Övning_5_Business_Logic.Vehicles." + vehicleType + ", Övning_5_Business_Logic";

            Type vehicle = Type.GetType(fullVehicleType,true,true);

            var ctors = vehicle.GetConstructors();
            var ctor = ctors[0];

            foreach(var param in ctor.GetParameters())
            {
                bool success = false;

                while (!success)
                {
                    Console.Write(Environment.NewLine + "Input value of parameter " + param.Name + " of type " + param.ParameterType.Name + ":");
                    String value = Console.ReadLine();

                    object paramInstance = null;

                    if (param.ParameterType.Name == "String")
                    {
                        paramInstance = "";
                    }
                    else
                    {
                        paramInstance = Activator.CreateInstance(param.ParameterType);
                    }
                                    
                    if (paramInstance is Int32)
                    {
                        if (Int32.TryParse(value, out int result))
                        {
                            paramInstance = result;
                            success = true;
                        }

                    }
                    else if (paramInstance is bool)
                    {
                        if (bool.TryParse(value, out bool result))
                        {
                            paramInstance = result;
                            success = true;
                        }
                    }
                    else if (paramInstance is FuelType)
                    {
                        if (Enum.TryParse(value, out FuelType result))
                        {
                            paramInstance = result;
                            success = true;
                        }
                    }
                    else if (paramInstance is String)
                    {
                        paramInstance = value;
                        success = true;
                    }

                    if (success)
                    {
                        paramDictionary.Add(param.Name, paramInstance);
                    }
                }
            }
           
            Vehicle instance = (Vehicle)ctor.Invoke(paramDictionary.Values.ToArray());

            return instance;
        }

        public static String InputLicense()
        {           
            Console.Write(Environment.NewLine + "Input the license plate to search for:");
                   
            Console.Write(Environment.NewLine + "License plate:");
            String license = Console.ReadLine();      
            
            if(!String.IsNullOrWhiteSpace(license) && license.Length == 6)
            {
                return license;
            }

            return null;
        }

        public static Dictionary<String, String> InputAttributes()
        {
            Dictionary<String, String> attributeDictionary = new Dictionary<String, String>();

            Console.Write(Environment.NewLine + "Input the number of attributes to search for:");
        
            if(Int32.TryParse(Console.ReadLine(), out int numberOfAttributes))
            {
                for (int i = 0; i < numberOfAttributes; i++)
                {
                    Console.Write(Environment.NewLine + "Attribute name:");
                    String name = Console.ReadLine();

                    Console.Write(Environment.NewLine + "Attribute value:");
                    String value = Console.ReadLine();

                    attributeDictionary.Add(name, value);
                }               
            }

            return attributeDictionary;
        }

    }
}
