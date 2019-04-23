using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Bussiness_Logic
{
    public class Gararge<T> : IEnumerable<T> where T : Vehicle
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
            for (int i = 0; i < numVehicles; i++)
            {
                yield return vehicles[i];
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

        public T Find(String licensePlate)
        {
            return (T)vehicles.Where(x => x.LicensePlate.ToUpper() == licensePlate.ToUpper());
        }

        public IEnumerable<T> Find(Dictionary<String,object> predicate)
        {
            IEnumerable<T> result = vehicles;

            foreach (var kvp in predicate)
            {               
                result = result.Where((x) => 
                {
                    if (x == null)
                    {
                        return false; 
                    }

                    if(x.GetProperties().TryGetValue(kvp.Key, out object value))
                    {
                        if (value.Equals(kvp.Value)) {
                            return true;
                        }                  
                    }

                    return false;
                });
            }

            return result;
        }
      
        public IEnumerable<IGrouping<Type, T>> GroupByType()
        {
            return vehicles.GroupBy(x => x?.GetType());
        }
    }
}
