using System;
using System.Collections.Generic;
using System.Text;

namespace Övning_1
{
    class Register
    {
        private List<Employee> emplyees = new List<Employee>();

        public void add(Employee emplyee)
        {
            emplyees.Add(emplyee);
        }

        public void list()
        {
            foreach(Employee emplyee in emplyees)
            {
                System.Console.Write(emplyee);    
            }
        }
    }
}
