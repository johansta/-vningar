using System;
using System.Collections.Generic;
using System.Linq;

namespace Övning_5_Data_Access_Layer
{
    public interface IGarageRepository<T> : IEnumerable<T> where T : Vehicle
    {
        void Add(T vehicle);
        void Remove(T vehicle);
        void Clear();

        int Capacity { get; }
        int Occupied { get; }

        T Find(string licenseNumber);
        IEnumerable<T> Find(Dictionary<string, string> attributes);

        IEnumerable<IGrouping<Type, T>> GroupByType();
    }
}
