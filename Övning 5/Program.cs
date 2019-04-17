using Övning_5.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Vehicle> queue = new Queue<Vehicle>();

            queue.Enqueue(new Car("ABC123"));
            queue.Enqueue(new Car("EFG123"));
            queue.Enqueue(new Boat("HIJ123"));
            queue.Enqueue(new Boat("KLM123"));
            queue.Enqueue(new Airplane("NOP123"));
            queue.Enqueue(new Airplane("NOP456"));
            queue.Enqueue(new Motorcycle("NOP789"));
            queue.Enqueue(new Motorcycle("QRS123"));
            queue.Enqueue(new Bus("QRS456"));
            queue.Enqueue(new Bus("QRS789"));

            Gararge<Vehicle> garage = new Gararge<Vehicle>(queue.Count);

            UI ui = new UI();

            while (true)
            {
                ui.PrintMainMenu();

                Console.Write("Input command: ");

                char command = Console.ReadLine()[0];

                switch (command)
                {

                    case 'c':

                        Console.WriteLine("Input capacity: ");

                        bool successfullParse = false;

                        while(!successfullParse)
                        {
                            successfullParse = Int32.TryParse(Console.ReadLine(), out int capacity);

                            if(successfullParse)
                            {
                                if (capacity >= 1)
                                {
                                    garage = new Gararge<Vehicle>(capacity);
                                }
                                else
                                {
                                    Console.WriteLine("Capacity failed validation. Try again");
                                    successfullParse = false;
                                }
                            }                       
                        }
                                       
                        break;
                    case  'p':
                                           
                        if (queue.Count > 0)
                        {
                            Vehicle vehicle = queue.Dequeue();
                            Console.WriteLine("Parking vehicle: " + vehicle);

                            garage.Park(vehicle);
                        }

                        break;
                    case  'd':
                        bool validInput = false;

                        while (validInput)
                        {
                            String licensePlate = Console.ReadLine();

                            if(!String.IsNullOrWhiteSpace(licensePlate) && licensePlate.Length != 6)//Add regexp???
                            {
                                Vehicle vehicle = garage.Find(licensePlate);

                                if (vehicle != null)
                                {
                                    garage.Drive(vehicle);
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
                                            
                        break;
                    case  'l':
                        garage.ListVehicles();
                        break;
                    case  'g':
                        garage.ListByVehicleType();
                        break;
                    case  'f':
                        garage.Find("Licence plate");
                        break;
                    case  'q':
                        return;
                    default:
                        break;
                }

            }          
        }
    }
}
