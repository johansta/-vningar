using Övning_3.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_3.Birds
{
    class Pelican : Bird
    {
        public Pelican(String name, int age, double weight, double wingspan, bool isFat) : base(name, age, weight, wingspan)
        {
            IsFat = isFat;
        }

        public bool IsFat { get; set; }

        public override String Stats()
        {
            return base.Stats() + " IsFat: " + IsFat;
        }
    }
}
