using Övning_5_Data_Access_Layer;
using Övning_5_Data_Access_Layer.Vehicles;
using Övning_5_Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;

namespace Övning_5_Business_Logic
{
    public class GarageHandler
    {
        private static GarageHandler instance;

        private GarageHandler(ResourceManager resourceManager)
        {
            ResourceManager = resourceManager;
        }

        public static GarageHandler GetInstance(ResourceManager resourceManager)
        {
            if (GarageHandler.instance == null)
            {
                GarageHandler.instance = new GarageHandler(resourceManager);
            }

            return GarageHandler.instance;
        }

        public ResourceManager ResourceManager { get; private set; }

        public IGarageRepository<Vehicle> Garage { get; set; }

        public void SetCapacity(int capacity)
        {
            Garage = new Gararge<Vehicle>(capacity);
        }
        
        public void FindVehicleByAttributes()
        {           
            Dictionary<String, String> attributes = Input.InputAttributes();                    
            ListVehiclesByPredicate(attributes);
        }

        public void FindVehicleByLicense()
        {
            String license = Input.InputLicense();

            if(license != null)
            {
                ListVehiclesByLicensePlate(license);
            }
        }

        private void ListVehiclesByLicensePlate(String license)
        {
            Vehicle vehicle = Garage.Find(license);

            if (vehicle != null)
            {
                Write(vehicle);        
            }
            else
            {              
                ConsoleWrapper.WritePreLinePostLine(ResourceManager.GetString("Search_Failed") + ": " + license, ConsoleColor.DarkRed, 1, 2);                
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
                ConsoleWrapper.WritePreLinePostLine(ResourceManager.GetString("Empty_Garage"),ConsoleColor.Red);
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
            StringBuilder stringBuilder = new StringBuilder();

            var viechleTypes = Garage.GroupByType();

            foreach (var viechleType in viechleTypes)
            {               
                ConsoleWrapper.WritePreLinePostLine(ResourceManager.GetString("Vehicle_Type") + ": " + viechleType.Key + 
                                                    Environment.NewLine +
                                                    ResourceManager.GetString("Vehicle_Count") + ": " + viechleType.Count(),                                                    
                                                    ConsoleColor.Green);
            }           
        }

        public void Drive()
        {
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine(ResourceManager.GetString("Input_License_Number") + ":");
                String licensePlate = Console.ReadLine();

                String pattern = @"[a-zA-Z]{3}\d{3}";
                Regex regex = new Regex(pattern);

                if(!String.IsNullOrWhiteSpace(licensePlate) && licensePlate.Length == 6 && regex.IsMatch(licensePlate) )
                {
                    validInput = true;

                    Vehicle vehicle = Garage.Find(licensePlate);

                    if (vehicle != null)
                    {
                        Garage.Remove(vehicle);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        ConsoleWrapper.WritePreLinePostLine(ResourceManager.GetString("Leaving_Vehicle") + ": ");
                        Console.WriteLine(vehicle);
                        //Console.WriteLine(Environment.NewLine + "Leaving vehicle: " + Environment.NewLine + vehicle + Environment.NewLine);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(ResourceManager.GetString("Search_License_Not_Found") + ": " + licensePlate);
                    }                  
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(ResourceManager.GetString("Invalid_Input"));
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
        }
        
        public void Park()
        {
            Vehicle vehicle = Input.InputVehicle2();//Input.InputVehicle();

            if (vehicle != null)          
            {              
                ConsoleWrapper.WritePreLinePostLine(ResourceManager.GetString("Parking_Vehicle"));
                Write(vehicle);
                Garage.Add(vehicle); 
            }
        }
     
        public void SetGarageCapacity()
        {         
            bool successfullParse = false;

            while (!successfullParse)
            {
                Console.Write(ResourceManager.GetString("Menu_Input_Capacity") + ": ");

                successfullParse = Int32.TryParse(ConsoleWrapper.ReadLine(ConsoleColor.Blue), out int capacity);

                if (successfullParse)
                {
                    if (capacity >= 1)
                    {
                        SetCapacity(capacity);
                    }
                    else
                    {                        
                        ConsoleWrapper.WriteLine(ResourceManager.GetString("Capacity_Failed_Validation"), ConsoleColor.Red);
                        successfullParse = false;
                    }
                }
                else
                {
                    ConsoleWrapper.WriteLine(ResourceManager.GetString("Invalid_Input"), ConsoleColor.Red);
                }
            }
        }

        private void Write(Vehicle vehicle)
        {
            ConsoleWrapper.WriteLine("{0}: {1}", new object[] {    ResourceManager.GetString("Vehicle_Type"),
                                                                        vehicle.GetType().Name},
                                                     new ConsoleColor[] {  ConsoleColor.Yellow,
                                                                            ConsoleColor.Blue});

            foreach (var prop in vehicle.GetProperties())
            {
                string resource = vehicle.propertyNameToResource[prop.Key];

                ConsoleWrapper.WriteLine("{0}: {1}", new object[] {ResourceManager.GetString(resource),
                                                                       prop.Value},
                                                 new ConsoleColor[] { ConsoleColor.Yellow, ConsoleColor.Blue });
            }
        }
    }
}
