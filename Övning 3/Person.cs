using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace Test
{
    sealed class Person : IPerson
    {
        private Person(){}

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

        private String fname;

        public String Fname
        {
            get { return fname; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    fname = value;
                }
            }
        }

        private String lname;

        public String Lname
        {
            get { return lname; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    lname = value;
                }
            }
        }

        private double height;

        public double Height
        {
            get { return height; }
            set
            {
                if (value > 0)
                {
                    height = value;
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
    }
}
