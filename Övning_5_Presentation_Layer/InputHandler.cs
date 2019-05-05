using Övning_5_Data_Access_Layer;
using Övning_5_Data_Access_Layer.Vehicles;
using Övning_5_Resources;
using Övning_5_Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Presentation_Layer
{
    public class InputHandler
    {

        public InputHandler(ResourceContext resourceContext, ValidationHandler validationHandler)
        {
            ResourceContext = resourceContext;
            ValidationHandler = validationHandler;
        }

        public static ResourceContext ResourceContext { get; private set; }
        public static ValidationHandler ValidationHandler { get; private set; }

        private void ListVehiclesTypes()
        {
            Console.WriteLine(Environment.NewLine + ResourceContext.Language.GetString("Menu_Vehicle_Types") + Environment.NewLine);

            foreach (VehicleType vehicleType in Enum.GetValues(typeof(VehicleType)))
            {
                ConsoleWrapper.WriteLine("{0} -> {1}",
                   new object[] { (int)vehicleType, vehicleType },
                   new ConsoleColor[] { ConsoleColor.Green, ConsoleColor.White });

            }
        }

        private VehicleType ValidateAndInputVehicleEnum(int input)
        {
            while (!Enum.IsDefined(typeof(VehicleType), input))
            {
                ConsoleWrapper.WritePreLinePostLine(ResourceContext.Language.GetString("Invalid_Option"), ConsoleColor.Red);
                ConsoleWrapper.WritePreLine(ResourceContext.Language.GetString("Menu_Input_Integer") + ":");

                input = ConsoleWrapper.ReadLine(ConsoleColor.Green)[0] - 48;
            }

            return (VehicleType)input;
        }

        private void ListArgumentOptions(ParameterInfo param)
        {
            string resourceId = ResourceContext.PropertyToId.GetString(param.name);
            string name = ResourceContext.Language.GetString(resourceId);

            ConsoleWrapper.Write(Environment.NewLine + ResourceContext.Language.GetString("Input_Value_For") + " {0} ",
               new object[] { name },
               new ConsoleColor[] { ConsoleColor.Yellow });

            ConsoleWrapper.Write("(", ConsoleColor.White);         
            ConsoleWrapper.Write(ResourceContext.Language.GetString(param.name + "_Range"), ConsoleColor.Blue);           
            ConsoleWrapper.WriteLine("):", ConsoleColor.White);
        }

        private void ValidateAndInputArgument(ParameterInfo param, string input)
        {
            while (String.IsNullOrWhiteSpace(input) ||
                                    !ValidationHandler.Validate(input, param.name) ||
                                    !param.tryParse(input, out param.value))
            {
                ConsoleWrapper.WritePreLine(ResourceContext.Language.GetString("Invalid_Option"));
                input = ConsoleWrapper.ReadLine(ConsoleColor.Blue);
            }
        }

        public Vehicle InputVehicle()
        {
            ListVehiclesTypes();

            ConsoleWrapper.WritePreLine(ResourceContext.Language.GetString("Menu_Input_Integer") + ":");

            int inputEnum = ConsoleWrapper.ReadLine(ConsoleColor.Green)[0] - 48;
            VehicleType inputVehicleType = ValidateAndInputVehicleEnum(inputEnum);

            VehicleFactory vehicleFactory = new VehicleFactory();
            List<ParameterInfo> parameters = vehicleFactory.GetParameters(inputVehicleType);

            for (int i = 0; i < parameters.Count; i++)
            {            
                ListArgumentOptions(parameters[i]);

                string input = ConsoleWrapper.ReadLine(ConsoleColor.Blue);
                ValidateAndInputArgument(parameters[i], input);
            }

            return vehicleFactory.GetVehicle(inputVehicleType, parameters);
        }
        
        public string InputAndValidateLicense()
        {           
            ConsoleWrapper.WritePreLine(ResourceContext.Language.GetString("Input_License_Number_To_Search_For"));
            ConsoleWrapper.WritePreLine(ResourceContext.Language.GetString("Vehicle_License_Plate") + ":", ConsoleColor.Yellow);
            string input = ConsoleWrapper.ReadLine(ConsoleColor.Blue);

            while (String.IsNullOrWhiteSpace(input) || !ValidationHandler.Validate(input, "LicensePlate"))
            {
                ConsoleWrapper.WriteLine(ResourceContext.Language.GetString("Invalid_Input"), ConsoleColor.Red);
                ConsoleWrapper.Write(ResourceContext.Language.GetString("Vehicle_License_Plate") + ":", ConsoleColor.Yellow);
                input = ConsoleWrapper.ReadLine(ConsoleColor.Blue);
            }                    

            return input;
        }

        public Dictionary<string, string> InputAttributes()//TODO:Validation code
        {
            Dictionary<string, string> attributeDictionary = new Dictionary<string, string>();
           
            ConsoleWrapper.WritePreLine(ResourceContext.Language.GetString("Input_Number_Of_Attributes_To_Search_For") + ":");

            if (Int32.TryParse(ConsoleWrapper.ReadLine(ConsoleColor.Blue), out int numberOfAttributes))
            {
                for (int i = 0; i < numberOfAttributes; i++)
                {
                    ConsoleWrapper.WritePreLine(ResourceContext.Language.GetString("Attribute_Name") + ":");
                    string name = ConsoleWrapper.ReadLine(ConsoleColor.Blue);

                    ConsoleWrapper.WritePreLine(ResourceContext.Language.GetString("Attribute_Value") + ":");
                    string value = ConsoleWrapper.ReadLine(ConsoleColor.Blue);

                    attributeDictionary.Add(name, value);
                }               
            }

            return attributeDictionary;
        }

        //Using reflection
        /*public Vehicle InputVehicle()
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
        }*/
    }
}
