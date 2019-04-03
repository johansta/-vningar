using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class PersonHandler
    {
        private class Person : IPerson
        {
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

        public IPerson CreatePerson(int age, string fname, string lname, double height, double weight)
        {
            var person = new Person()
            {
              Age = age,
              Fname = fname,
              Lname = lname,
              Height = height,
              Weight = weight
            };
          
            return person;
        }

        public void SetAge(IPerson pers, int age)
        {
            (pers as Person).Age = age;
        }

        public void SetFname(IPerson pers, String fname)
        {
            (pers as Person).Fname = fname;
        }

        public void SetLName(IPerson pers, String lname)
        {
            (pers as Person).Lname = lname;
        }

        public void SetHeight(IPerson pers, double height)
        {
            (pers as Person).Height = height;
        }

        public void SetWeight(IPerson pers, double weight)
        {
            (pers as Person).Weight = weight;
        }

        public int GetAge(IPerson pers)
        {
            return (pers as Person).Age;
        }

        public String GetFname(IPerson pers)
        {
            return (pers as Person).Fname;
        }

        public String GetLName(IPerson pers)
        {
            return (pers as Person).Lname;
        }

        public double GetHeight(IPerson pers)
        {
            return (pers as Person).Height;
        }

        public double GetWeight(IPerson pers)
        {
            return (pers as Person).Weight;
        }


    }
}
