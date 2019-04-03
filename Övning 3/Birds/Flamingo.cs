using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_3.Birds
{
    class Flamingo : Bird
    {
        public Flamingo(String name, int age, double weight, double wingspan, bool isPink) : base(name, age, weight, wingspan)
        {
            IsPink = isPink;                                      
        }

        public bool IsPink { get; set; }

        public override String Stats()
        {
            return base.Stats() + " IsPink: " + IsPink;
        }
    }
}
