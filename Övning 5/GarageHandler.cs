using Övning_5_Bussiness_Logic;
using Övning_5_Bussiness_Logic.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Övning_5_Presentation_Logic
{
    class GarageHandler
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

        public Gararge<Vehicle> Garage { get; set; }


        public void SetCapacity(int capacity)
        {
            Garage = new Gararge<Vehicle>(capacity);
        }

        public Queue<Vehicle> GetTestData()
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
        }

        public void ListVehiclesByPredicate(Dictionary<String, object> predicate)
        {
            IEnumerable<Vehicle> result = Garage.Find(predicate).ToList();

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

            foreach (var viechle in Garage)
            {              
                stringBuilder.Append(viechle.ToString());
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(Environment.NewLine);
            }

            Console.WriteLine(stringBuilder);
        }

        public String ListByVehicleType()
        {
            StringBuilder stringBuilder = new StringBuilder();

            var viechleTypes = Garage.GroupByType();

            foreach (var viechleType in viechleTypes)
            {
                stringBuilder.Append("Vehicle Type: " + viechleType.Key);
                stringBuilder.Append("Vehicle Type: " + viechleTypes.Count());
            }

            return stringBuilder.ToString();
        }

        public void Drive()
        {
            bool validInput = false;

            while (validInput)
            {
                String licensePlate = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(licensePlate) && licensePlate.Length != 6)//Add regexp???
                {
                    Vehicle vehicle = Garage.Find(licensePlate);

                    if (vehicle != null)
                    {
                        Garage.Drive(vehicle);
                    }
                    else
                    {
                        Console.WriteLine("No vehicle in the garage with licensePlate: " + licensePlate);
                    }

                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again");
                }

            }
        }

        public void Park(Queue<Vehicle> queue)
        {
            if (queue.Count > 0)
            {
                Vehicle vehicle = queue.Dequeue();
                Console.WriteLine(Environment.NewLine + "Parking vehicle: " + vehicle + Environment.NewLine);

                Garage.Park(vehicle); 
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
