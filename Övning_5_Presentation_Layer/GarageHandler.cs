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

        private GarageHandler(ResourceContext resourceContext, InputHandler inputHandler)
        {
            ResourceContext = resourceContext;
            InputHandler = inputHandler;
        }

        public static GarageHandler GetInstance(ResourceContext resourceContext, InputHandler inputHandler)
        {
            if (GarageHandler.instance == null)
            {
                GarageHandler.instance = new GarageHandler(resourceContext, inputHandler);
            }

            return GarageHandler.instance;
        }

        public ResourceContext ResourceContext { get; private set; }
        public InputHandler InputHandler { get; private set; }

        public IGarageRepository<Vehicle> Garage { get; set; }

        public void SetCapacity(int capacity)
        {
            Garage = new Gararge<Vehicle>(capacity);
        }
        
        public void FindVehicleByAttributes()
        {           
            Dictionary<String, String> attributes = InputHandler.InputAttributes();                    
            ListVehiclesByPredicate(attributes);
        }

        public void FindVehicleByLicense()
        {
            String license = InputHandler.InputLicense();

            if(license != null)
            {
                ListVehiclesByLicensePlate(license);
            }
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
                ConsoleWrapper.WritePreLinePostLine(ResourceContext.Language.GetString("Search_Failed") + ": " + license, ConsoleColor.DarkRed, 1, 2);                
            }

        }

        private void ListVehiclesByPredicate(Dictionary<String, String> attributes)
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

                /*ConsoleWrapper.WritePreLinePostLine(ResourceManager.GetString("Vehicle_Type") + ": " + viechleType.Key.Name + 
                                                    Environment.NewLine +
                                                    ResourceManager.GetString("Vehicle_Count") + ": " + viechleType.Count(),                                                    
                                                    ConsoleColor.Green);*/
            }
        }

        public void Drive()
        {
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine(ResourceContext.Language.GetString("Input_License_Number") + ":");
                String licensePlate = ConsoleWrapper.ReadLine(ConsoleColor.Blue);

                String pattern = @"[a-zA-Z]{3}\d{3}";
                Regex regex = new Regex(pattern);

                if(!String.IsNullOrWhiteSpace(licensePlate) && licensePlate.Length == 6 && regex.IsMatch(licensePlate) )
                {
                    validInput = true;

                    Vehicle vehicle = Garage.Find(licensePlate);

                    if (vehicle != null)
                    {
                        Garage.Remove(vehicle);                    
                        ConsoleWrapper.WritePreLinePostLine(ResourceContext.Language.GetString("Leaving_Vehicle"));
                        Write(vehicle);                    
                    }
                    else
                    {
                        Console.WriteLine(ResourceContext.Language.GetString("Search_License_Not_Found") + ": " + licensePlate);
                    }                  
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(ResourceContext.Language.GetString("Invalid_Input"));
                    Console.ForegroundColor = ConsoleColor.White;
                }

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
     
        public void SetGarageCapacity()
        {         
            bool successfullParse = false;

            while (!successfullParse)
            {
                Console.Write(ResourceContext.Language.GetString("Menu_Input_Capacity") + ": ");

                successfullParse = Int32.TryParse(ConsoleWrapper.ReadLine(ConsoleColor.Blue), out int capacity);

                if (successfullParse)
                {
                    if (capacity >= 1)
                    {
                        SetCapacity(capacity);
                    }
                    else
                    {                        
                        ConsoleWrapper.WriteLine(ResourceContext.Language.GetString("Capacity_Failed_Validation"), ConsoleColor.Red);
                        successfullParse = false;
                    }
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
