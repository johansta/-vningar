using Övning_3.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_3.Birds
{
    class Swan : Bird
    {
        public Swan(String name, int age, double weight, double wingspan, bool isWhite) : base(name, age, weight, wingspan)
        {
            IsWhite = isWhite;       
        }

        public bool IsWhite { get; set; }

        public override String Stats()
        {
            return base.Stats() + " IsWhite: " + IsWhite;
        }
    }
}
