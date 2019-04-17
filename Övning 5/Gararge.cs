using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5
{
    class Gararge<T> : IEnumerable<T> where T : Vehicle
    {
        public Gararge(int capacity)
        {
            vehicles = new T[capacity];
            numVehicles = 0;
        }

        private T[] vehicles;
        public int numVehicles { get; private set; }
        
        public IEnumerator<T> GetEnumerator()
        {
            foreach(T vehicle in vehicles)
            {
                yield return vehicle;
            }           
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Park(T vehicle)
        {
            vehicles[numVehicles++] = vehicle;
        }

        public void Drive(T vehicle)
        {
            var cars = vehicles.Where(x => x.LicensePlate.ToUpper() != vehicle.LicensePlate.ToUpper());
            vehicles = cars.ToArray();

            numVehicles--;
        }

        public T Find(String LicensePlate)
        {
            return (T)vehicles.Where(x => x.LicensePlate.ToUpper() == LicensePlate.ToUpper());
        }

        public String ListVehicles()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var viechle in vehicles)
            {
                stringBuilder.Append(viechle.ToString());
            }

            return stringBuilder.ToString();
        }

        public String ListByVehicleType()
        {
            StringBuilder stringBuilder = new StringBuilder(); 

            var viechleTypes = vehicles.GroupBy(x => x.GetType());

            foreach(var viechleType in viechleTypes)
            {
                stringBuilder.Append("Vehicle Type: " + viechleType.Key);
                stringBuilder.Append("Vehicle Type: " + viechleTypes.Count());
            }

            return stringBuilder.ToString();
        }
    }
}
