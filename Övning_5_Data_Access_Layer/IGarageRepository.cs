using System;
using System.Collections.Generic;
using System.Linq;

namespace Övning_5_Data_Access_Layer
{
    public interface IGarageRepository<T> : IEnumerable<T> where T : Vehicle
    {
        void Add(T vehicle);
        void Remove(T vehicle);

        T Find(String licensePlate);
        IEnumerable<T> Find(Dictionary<String, String> attributes);

        IEnumerable<IGrouping<Type, T>> GroupByType();
    }
}
