﻿using Övning_5_Data_Access_Layer;
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

        public void CreateGarage()
        {
            int capacity = InputHandler.InputGarageCapacity();
            Garage = new Gararge<Vehicle>(capacity);
        }

        public void FindVehicleByAttributes()
        {
            if (Garage.Count() == 0)
            {
                ConsoleWrapper.WritePreLinePostLine(ResourceContext.Language.GetString("Garage_Empty"));
                return;
            }

            Dictionary<String, String> attributes = InputHandler.InputAttributes(GetAllAttributes());                    
            ListVehicles(attributes);
        }

        public void FindVehicleByLicense()
        {          
            if (Garage.Count() == 0)
            {
                ConsoleWrapper.WritePreLinePostLine(ResourceContext.Language.GetString("Garage_Empty"));
                return;
            }

            ConsoleWrapper.WritePreLine(ResourceContext.Language.GetString("Input_License_Plate_To_Search_For"));
            string input = InputHandler.InputLicensePlate();

            ListVehicles(input);
        }

        private void ListVehicles(String licensePlate)
        {
            Vehicle vehicle = Garage.Find(licensePlate);
          
            if(vehicle != null)
            {
                Console.WriteLine();
                Write(vehicle);        
            }
            else
            {
                Console.WriteLine();
                ConsoleWrapper.WriteLine("{0}: {1}",
                                            new object[] { ResourceContext.Language.GetString("Search_Failed"), licensePlate },
                                            new ConsoleColor[] {ConsoleColor.White,ConsoleColor.Blue});
            }

        }

        public List<string> GetAllAttributes()
        {
            List<string> attributes = new List<string>();

            foreach (var vehicle in Garage)
            {
                foreach (var key in vehicle.GetProperties().Keys)
                {
                    attributes.Add(key);
                }           
            }

            return attributes.Distinct().ToList();
        }

        private void ListVehicles(Dictionary<String, String> attributes)
        {
            IEnumerable<Vehicle> result = Garage.Find(attributes).ToList();

            if(result.Count() == 0)
            {
                ConsoleWrapper.WritePreLinePostLine(ResourceContext.Language.GetString("Search_Attribute_Not_Found"));
                return;
            }

            Console.WriteLine();

            List<Vehicle> vehicles = result.ToList();
            
            for (int i = 0; i < vehicles.Count; i++)          
            {
                Write(vehicles[i]);

                if (i < (vehicles.Count - 1))
                {
                    Console.WriteLine();
                }
            }          
        }

        public void ListVehicles()
        {           
            foreach (var vehicle in Garage)
            {
                Console.WriteLine();
                Write(vehicle);
            }

            Console.WriteLine();
            ConsoleWrapper.WriteLine("Garaget har totalt {0} parkeringsplatser. {1} är nu upptagna!",
                                    new object[] { Garage.Capacity, Garage.Count() },
                                    new ConsoleColor[] { ConsoleColor.Blue,ConsoleColor.Blue});
        }

        public void ListByVehicleType()
        {
            if (Garage.Occupied == 0)
            {
                ConsoleWrapper.WritePreLinePostLine(ResourceContext.Language.GetString("Garage_Empty"));
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
            if (Garage.Occupied == 0)
            {
                ConsoleWrapper.WritePreLinePostLine(ResourceContext.Language.GetString("Garage_Empty"));
                return;
            }

            ConsoleWrapper.WritePreLine(ResourceContext.Language.GetString("Input_License_Plate_To_Drive"));
            string input = InputHandler.InputLicensePlate();

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
            if (Garage.Occupied >= Garage.Capacity)
            {
                ConsoleWrapper.WritePreLinePostLine(ResourceContext.Language.GetString("Garage_Full"));
                return;
            }

            Vehicle vehicle = InputHandler.InputVehicle();

            if (vehicle != null)          
            {
                Vehicle parkedVehicle = Garage.Find(vehicle.LicensePlate);

                if(parkedVehicle != null)
                {
                    ConsoleWrapper.WritePreLinePostLine(ResourceContext.Language.GetString("Parking_Failed"));
                    return;
                }

                ConsoleWrapper.WritePreLinePostLine(ResourceContext.Language.GetString("Parking_Vehicle"));
                Write(vehicle);
                Garage.Add(vehicle); 
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
