using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_3.Animals
{
    class Hedgehog : Animal
    {
        public Hedgehog(String name, int age, double weight) : base(name, age, weight)
        {

        }

        private int numSpikes;

        public int NumSpikes
        {
            get { return numSpikes; }
            set {
                if (value >= 1000)
                {
                    numSpikes = value;
                }
            }
        }

        public override String Stats()
        {
            return base.Stats() + " NumSpikes: " + NumSpikes;
        }

    }
}
