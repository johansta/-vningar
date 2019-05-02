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
            Vehicle viechle = Garage.Find(license);

            if (viechle != null)
            {
                /*StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(viechle.ToString());
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(Environment.NewLine);

                ConsoleWrapper.WriteLine(stringBuilder.ToString(), ConsoleColor.Green);*/

                ConsoleWrapper.WritePreLinePostLine(viechle + ": " + license, ConsoleColor.Green, 1, 3);
            }
            else
            {
                //Console.ForegroundColor = ConsoleColor.Red;

                ConsoleWrapper.WritePreLinePostLine(ResourceManager.GetString("Search_Failed") + ": " + license, ConsoleColor.DarkRed, 1, 2);

                //ConsoleWrapper.WritePreLine(ResourceManager.GetString("Search_Failed") +": ");
                //ConsoleWrapper.WritePostLine(license, 2);
                //Console.WriteLine(Environment.NewLine + "Could not find any vehicles with the license plate: " + license + Environment.NewLine);
                //Console.ForegroundColor = ConsoleColor.White;
            }

        }

        private void ListVehiclesByPredicate(Dictionary<String, String> attributes)
        {
            IEnumerable<Vehicle> result = Garage.Find(attributes).ToList();

            /*StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(Environment.NewLine);

            foreach (var viechle in result)
            {
                stringBuilder.Append(viechle.ToString());
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(Environment.NewLine);
            }

            Console.WriteLine(stringBuilder);*/

            Console.WriteLine();

            foreach (var viechle in result)
            {
                ConsoleWrapper.WritePostLine(viechle.ToString(),2);
            }

            Console.WriteLine();
        }

        public void ListVehicles()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(Environment.NewLine);

            if(Garage.Count() == 0)
            {
                ConsoleWrapper.WritePreLinePostLine(ResourceManager.GetString("Empty_Garage"),ConsoleColor.Red);

                //Console.ForegroundColor = ConsoleColor.Red;
                //ConsoleWrapper.WritePreLinePostLine(ResourceManager.GetString("Empty_Garage"));
                //Console.WriteLine(Environment.NewLine + "The garage is empty!" + Environment.NewLine);
                //Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            /*foreach (var viechle in Garage)
            {              
                stringBuilder.Append(viechle.ToString());
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(Environment.NewLine);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(stringBuilder);
            Console.ForegroundColor = ConsoleColor.White;*/
        
            foreach (var viechle in Garage)
            {
                ConsoleWrapper.WritePostLine(viechle.ToString(), ConsoleColor.Green, 2);
            }

            Console.WriteLine();
        }

        public void ListByVehicleType()
        {
            StringBuilder stringBuilder = new StringBuilder();

            var viechleTypes = Garage.GroupByType();

            foreach (var viechleType in viechleTypes)
            {
                /*stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(ResourceManager.GetString("Vehicle_Type") +  ": " + viechleType.Key);
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(ResourceManager.GetString("Vehicle_Count") + ": " + viechleType.Count());
                stringBuilder.Append(Environment.NewLine);*/

                ConsoleWrapper.WritePreLinePostLine(ResourceManager.GetString("Vehicle_Type") + ": " + viechleType.Key + 
                                                    Environment.NewLine +
                                                    ResourceManager.GetString("Vehicle_Count") + ": " + viechleType.Count(),                                                    
                                                    ConsoleColor.Green);
            }

            /*Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(stringBuilder);
            Console.ForegroundColor = ConsoleColor.White;*/
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
                /*Console.ForegroundColor = ConsoleColor.Green;
                ConsoleWrapper.WritePreLinePostLine(ResourceManager.GetString("Parking_Vehicle") + ": ");
                Console.WriteLine(vehicle);
                //Console.WriteLine(Environment.NewLine + "Parking vehicle: " + Environment.NewLine + vehicle + Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.White;*/

                ConsoleWrapper.WritePreLinePostLine(ResourceManager.GetString("Parking_Vehicle") + ": " + Environment.NewLine + vehicle, ConsoleColor.Green);

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
    }
}
