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
            Capacity = capacity;
            vehicles = new T[capacity];
            Occupied = 0;
        }

        private T[] vehicles;
        public int Capacity { get; private set; }
        public int Occupied { get; private set; }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < vehicles.Length; i++)
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

        public bool Add(T vehicle)
        {
            if(Occupied >= Capacity)
            {
                return false;
            }

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    Occupied++;
                    return true;
                }
            }

            return false;
        }

        public bool Remove(T vehicle)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i]?.LicensePlate == vehicle?.LicensePlate)
                {
                    vehicles[i] = null;
                    Occupied--;
                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                vehicles[i] = null;
            }

            Occupied = 0;
        }

        public T Find(string licensePlate)
        {
            IEnumerable<T> result = vehicles.Where((x) =>
            {               
                if (x?.LicensePlate == licensePlate.ToUpper())
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

        public IEnumerable<T> Find(Dictionary<string, string> attributes)
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
                        if (value == kvp.Value) {
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
            return vehicles.GroupBy(x => x?.GetType()).Where(x => x.Key != null);                        
        }
    }
}
