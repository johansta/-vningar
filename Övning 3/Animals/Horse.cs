using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_3
{
    class Horse : Animal
    {
        public Horse(String name, int age, double weight) : base(name,age,weight)
        {
    
        }

        public bool IsFat { get; set; }

        public override String Stats()
        {
            return base.Stats() + " IsFat: " + IsFat;
        }
    }
}