using Övning_5_Data_Access_Layer;
using Övning_5_Data_Access_Layer.Vehicles;
using Övning_5_Resources;
using Övning_5_Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;

namespace Övning_5_Presentation_Layer
{
    public class GarageHandler
    {
        private static GarageHandler instance;

        private GarageHandler(ResourceContext resourceContext, InputHandler inputHandler, ValidationHandler validationHandler)
        {
            ResourceContext = resourceContext;
            InputHandler = inputHandler;
            ValidationHandler = validationHandler;
        }

        public static GarageHandler GetInstance(ResourceContext resourceContext, InputHandler inputHandler, ValidationHandler validationHandler)
        {
            if (GarageHandler.instance == null)
            {
                GarageHandler.instance = new GarageHandler(resourceContext, inputHandler, validationHandler);
            }

            return GarageHandler.instance;
        }

        public ResourceContext ResourceContext { get; private set; }
        public InputHandler InputHandler { get; private set; }
        public ValidationHandler ValidationHandler { get; private set; }

        public IGarageRepository<Vehicle> Garage { get; set; }

        public void SetCapacity(int capacity)
        {
            Garage = new Gararge<Vehicle>(capacity);
        }
        
        public void FindVehicleByAttributes()
        {           
            Dictionary<String, String> attributes = InputHandler.InputAttributes();                    
            ListVehiclesWithAttributes(attributes);
        }

        public void FindVehicleByLicense()
        {
            string input = InputHandler.InputAndValidateLicense();
            ListVehiclesByLicensePlate(input);
        }

        private void ListVehiclesByLicensePlate(String license)
        {
            Vehicle vehicle = Garage.Find(license);
          
            if(vehicle != null)
            {
                Console.WriteLine();
                Write(vehicle);        
            }
            else
            {
                Console.WriteLine();
                ConsoleWrapper.WriteLine("{0}: {1}",
                                            new object[] { ResourceContext.Language.GetString("Search_Failed"), license },
                                            new ConsoleColor[] {ConsoleColor.White,ConsoleColor.Blue});
            }

        }

        private void ListVehiclesWithAttributes(Dictionary<String, String> attributes)
        {
            IEnumerable<Vehicle> result = Garage.Find(attributes).ToList();

            Console.WriteLine();

            foreach (var vehicle in result)
            {
                Write(vehicle);
            }

            Console.WriteLine();
        }

        public void ListVehicles()
        {           
            if(Garage.Count() == 0)
            {
                ConsoleWrapper.WritePreLinePostLine(ResourceContext.Language.GetString("Empty_Garage"),ConsoleColor.Red);
                return;
            }

            foreach (var vehicle in Garage)
            {
                Console.WriteLine();
                Write(vehicle);
            }
        }

        public void ListByVehicleType()
        {

            if (Garage.Count() == 0)
            {
                ConsoleWrapper.WritePreLinePostLine(ResourceContext.Language.GetString("Empty_Garage"), ConsoleColor.Red);
                return;
            }

            var viechleTypes = Garage.GroupByType();

            foreach (var viechleType in viechleTypes)
            {
                Console.WriteLine();
                WriteType(viechleType.Key);
                Console.WriteLine(ResourceContext.Language.GetString("Vehicle_Count") + ": " + viechleType.Count());
            }
        }

        public void Drive()
        {
            Console.WriteLine(ResourceContext.Language.GetString("Input_License_Plate") + ":");
            ConsoleWrapper.Write(ResourceContext.Language.GetString("Vehicle_License_Plate") + ":", ConsoleColor.Yellow);
            string input = ConsoleWrapper.ReadLine(ConsoleColor.Blue);
      
            while (String.IsNullOrWhiteSpace(input) || !ValidationHandler.Validate(input, "LicensePlate"))
            {             
                ConsoleWrapper.WriteLine(ResourceContext.Language.GetString("Invalid_Input"), ConsoleColor.Red);
                ConsoleWrapper.Write(ResourceContext.Language.GetString("Vehicle_License_Plate") + ":", ConsoleColor.Yellow);
                input = ConsoleWrapper.ReadLine(ConsoleColor.Blue);
            }

            Vehicle vehicle = Garage.Find(input);

            if (vehicle != null)
            {
                Garage.Remove(vehicle);
                ConsoleWrapper.WritePreLinePostLine(ResourceContext.Language.GetString("Leaving_Vehicle"));
                Write(vehicle);
            }
            else
            {
                ConsoleWrapper.Write(ResourceContext.Language.GetString("Search_License_Plate_Not_Found") + ": ", ConsoleColor.White);
                ConsoleWrapper.WriteLine(input, ConsoleColor.Blue);
            }
        }
        
        public void Park()
        {
            Vehicle vehicle = InputHandler.InputVehicle();

            if (vehicle != null)          
            {              
                ConsoleWrapper.WritePreLinePostLine(ResourceContext.Language.GetString("Parking_Vehicle"));
                Write(vehicle);
                Garage.Add(vehicle); 
            }
        }
     
        public void InputGarageCapacity()
        {         
            bool validInput = false;

            while (!validInput)
            {
                Console.Write(ResourceContext.Language.GetString("Menu_Input_Capacity"));

                ConsoleWrapper.Write("(", ConsoleColor.White);
                ConsoleWrapper.Write(ResourceContext.Language.GetString("Capacity_Range"), ConsoleColor.Blue);
                ConsoleWrapper.WriteLine("):", ConsoleColor.White);

                string input = ConsoleWrapper.ReadLine(ConsoleColor.Blue);

                if (!String.IsNullOrWhiteSpace(input) && 
                    ValidationHandler.Validate(input, "Capacity") && 
                    Int32.TryParse(input, out int capacity))
                {
                    validInput = true;
                    SetCapacity(capacity);
                }
                else
                {
                    ConsoleWrapper.WriteLine(ResourceContext.Language.GetString("Invalid_Input"), ConsoleColor.Red);
                }
            }
        }

        private void Write(Vehicle vehicle)
        {          
            WriteType(vehicle.GetType());

            foreach (var prop in vehicle.GetProperties())
            {
                string resourceId = ResourceContext.PropertyToId.GetString(prop.Key);                

                ConsoleWrapper.WriteLine("{0}: {1}",    new object[] {  ResourceContext.Language.GetString(resourceId),
                                                                        prop.Value},
                                                        new ConsoleColor[] { ConsoleColor.Yellow, ConsoleColor.Blue });
            }
        }

        private void WriteType(Type type)
        {
            ConsoleWrapper.WriteLine("{0}: {1}",    new object[] {  ResourceContext.Language.GetString("Vehicle_Type"),
                                                                    type.Name},
                                                    new ConsoleColor[] {  ConsoleColor.Yellow, ConsoleColor.Blue});
        }
    }
}
