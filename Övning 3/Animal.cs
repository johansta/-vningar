using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_3
{
    class Animal
    {
        public Animal(String name, int age, double weight)
        {
            this.name = name;
            this.age = age;
            this.weight = weight;
        }

        private string name;

        public string Name
        {
            get { return name; }
            set {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
            }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0)
                {
                    age = value;
                }
            }
        }

        private double weight;

        public double Weight
        {
            get { return weight; }
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }
        
        public virtual String Stats()
        {
            return "Name: " + Name + " Age: " + Age + " Weight: " + Weight;
        }

    }
}
