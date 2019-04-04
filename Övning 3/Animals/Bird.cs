using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_3.Animals
{
    class Bird : Animal
    {
        public Bird(String name, int age, double weight, double wingspan) : base(name, age, weight)
        {
            Wingspan = wingspan;
        }

        private double wingspan;

        public double Wingspan
        {
            get { return wingspan; }
            set {
                if (value > 0)
                {
                    wingspan = value;
                }
            }
        }
        
        public override String Stats()
        {
            return base.Stats() + " Wingspan: " + Wingspan;
        }

    }
}
