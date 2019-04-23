using Övning_5_Bussiness_Logic;
using Övning_5_Bussiness_Logic.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Presentation_Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            GarageHandler garageHandler = GarageHandler.GetInstance();

            Queue<Vehicle> queue = garageHandler.GetTestData();
            garageHandler.SetCapacity(queue.Count);

            UI ui = new UI();

            while (true)
            {
                ui.PrintMainMenu();

                Console.Write("Input command: ");

                char command = Console.ReadLine()[0];

                switch (command)
                {
                    case 'c':
                        garageHandler.SetGarageCapacity();
                        break;
                    case 'p':
                        garageHandler.Park(queue);
                        break;
                    case 'd':
                        garageHandler.Drive();
                        break;
                    case 'l':
                        garageHandler.ListVehicles();
                        break;
                    case 'g':
                        garageHandler.ListByVehicleType();
                        break;
                    case 'f':
                        garageHandler.Garage.Find("Licence plate");
                        break;
                    case 'a':

                        Dictionary<String, object> predicate = new Dictionary<String, object>();
                       
                        predicate.Add("LicensePlate", "EFG123");
                        predicate.Add("FuelType", FuelType.DIESEL);
                       
                        garageHandler.ListVehiclesByPredicate(predicate);

                        break;
                    case 'q':
                        return;
                    default:
                        break;
                }

            }
        }

    }
}
