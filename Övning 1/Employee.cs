using System;
using System.Collections.Generic;
using System.Text;

namespace Övning_1
{
    class Employee
    {
        private String name;
        private int salary;

        public Employee(String name, int salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public override string ToString()
        {
            return "\nNamn: " + name + " Lön: " + salary;    
        }
    }
}
