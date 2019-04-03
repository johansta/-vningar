using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_3
{
    class Dog : Animal
    {
        public Dog(String name, int age, double weight, double tailLength) : base(name, age, weight)
        {
            TailLength = tailLength;
        }

        private double tailLength;

        public double TailLength
        {
            get { return tailLength; }
            set {
                if (value > 0)
                {
                    tailLength = value;
                }
            }
        }

        public override String Stats()
        {
            return base.Stats() + " TailLength: " + TailLength;
        }

        public String FavoritCandy()
        {
            return "Dry meat";
        }

    }
}
