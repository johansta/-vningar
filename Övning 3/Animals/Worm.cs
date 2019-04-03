using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_3
{
    class Worm : Animal
    {
        public Worm(String name, int age, double weight) : base(name, age, weight)
        {
        }

        public bool IsPoisones { get; set; }

        public override String Stats()
        {
            return base.Stats() + " IsPoisones: " + IsPoisones;
        }
    }
}
