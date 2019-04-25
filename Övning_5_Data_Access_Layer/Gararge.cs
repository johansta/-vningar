using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Data_Access_Layer
{
    public class Gararge<T> : IGarageRepository<T> where T : Vehicle
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
                if (vehicles[i] != null)
                {
                    yield return vehicles[i];
                }
            }       
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T vehicle)
        {
            vehicles[numVehicles++] = vehicle;
        }

        public void Remove(T vehicle)
        {
            var cars = vehicles.Where(x => x?.LicensePlate.ToUpper() != vehicle.LicensePlate.ToUpper());
            vehicles = cars.ToArray();

            numVehicles--;
        }

        public T Find(String licensePlate)
        {
            IEnumerable<T> result = vehicles.Where((x) =>
            {
                if (x == null)
                {
                    return false;
                }

                if (x.LicensePlate.ToUpper() == licensePlate.ToUpper())
                {
                    return true;
                }

                return false;
            }
            );

            if(result.Count() == 1)
            {
                return result.ToArray()[0];
            }

            return null;
        }

        public IEnumerable<T> Find(Dictionary<String,String> attributes)
        {
            IEnumerable<T> result = vehicles;

            foreach (var kvp in attributes)
            {               
                result = result.Where((x) => 
                {
                    if (x == null)
                    {
                        return false; 
                    }

                    if(x.GetProperties().TryGetValue(kvp.Key, out string value))
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
