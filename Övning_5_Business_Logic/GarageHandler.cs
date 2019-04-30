using Övning_5_Data_Access_Layer;
using Övning_5_Data_Access_Layer.Vehicles;
using Övning_5_Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Övning_5_Business_Logic
{
    public class GarageHandler
    {
        private static GarageHandler instance;

        private GarageHandler()
        {          
           
        }

        public static GarageHandler GetInstance()
        {
            if (GarageHandler.instance == null)
            {
                GarageHandler.instance = new GarageHandler();
            }

            return GarageHandler.instance;
        }

        public IGarageRepository<Vehicle> Garage { get; set; }


        public void SetCapacity(int capacity)
        {
            Garage = new Gararge<Vehicle>(capacity);
        }

        /*public Queue<Vehicle> GetTestData()
        {
            Queue<Vehicle> queue = new Queue<Vehicle>();

            queue.Enqueue(new Car("ABC123", FuelType.GASOLINE));
            queue.Enqueue(new Car("EFG123",FuelType.DIESEL));
            queue.Enqueue(new Boat("HIJ123",3));
            queue.Enqueue(new Boat("KLM123",2));
            queue.Enqueue(new Airplane("NOP123",100));
            queue.Enqueue(new Airplane("NOP456",42));
            queue.Enqueue(new Motorcycle("NOP789",true));
            queue.Enqueue(new Motorcycle("QRS123",false));
            queue.Enqueue(new Bus("QRS456",66));
            queue.Enqueue(new Bus("QRS789", 90));

            return queue;
        }*/

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
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(viechle.ToString());
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(Environment.NewLine);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(stringBuilder);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(Environment.NewLine + "Could not find any vehicles with the license plate: " + license + Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        private void ListVehiclesByPredicate(Dictionary<String, String> attributes)
        {
            IEnumerable<Vehicle> result = Garage.Find(attributes).ToList();

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(Environment.NewLine);

            foreach (var viechle in result)
            {
                stringBuilder.Append(viechle.ToString());
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(Environment.NewLine);
            }

            Console.WriteLine(stringBuilder);
        }

        public void ListVehicles()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(Environment.NewLine);

            if(Garage.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(Environment.NewLine + "The garage is empty!" + Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            foreach (var viechle in Garage)
            {              
                stringBuilder.Append(viechle.ToString());
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(Environment.NewLine);
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(stringBuilder);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ListByVehicleType()
        {
            StringBuilder stringBuilder = new StringBuilder();

            var viechleTypes = Garage.GroupByType();

            foreach (var viechleType in viechleTypes)
            {
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append("Vehicle Type: " + viechleType.Key);
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append("Count: " + viechleType.Count());
                stringBuilder.Append(Environment.NewLine);
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(stringBuilder);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Drive()
        {
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Input license plate:");
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
                        Console.WriteLine(Environment.NewLine + "Leaving vehicle: " + Environment.NewLine + vehicle + Environment.NewLine);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine("No vehicle in the garage with licensePlate: " + licensePlate);
                    }                  
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Invalid input. Try again");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
        }
        
        public void Park()
        {
            Vehicle vehicle = Input.InputVehicle2();//Input.InputVehicle();

            if (vehicle != null)          
            {               
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(Environment.NewLine + "Parking vehicle: " + Environment.NewLine + vehicle + Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.White;

                Garage.Add(vehicle); 
            }
        }

        public void Park(Queue<Vehicle> queue)
        {
            if (queue.Count > 0)
            {
                Vehicle vehicle = queue.Dequeue();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(Environment.NewLine + "Parking vehicle: " + Environment.NewLine + vehicle + Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.White;

                Garage.Add(vehicle); 
            }
        }

        public void SetGarageCapacity()
        {
            Console.WriteLine("Input capacity: ");

            bool successfullParse = false;

            while (!successfullParse)
            {
                successfullParse = Int32.TryParse(Console.ReadLine(), out int capacity);

                if (successfullParse)
                {
                    if (capacity >= 1)
                    {
                        SetCapacity(capacity);
                    }
                    else
                    {
                        Console.WriteLine("Capacity failed validation. Try again");
                        successfullParse = false;
                    }
                }
            }
        }
    }
}
