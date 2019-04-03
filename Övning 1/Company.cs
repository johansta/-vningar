using System;
using System.Collections.Generic;
using System.Text;

namespace Övning_1
{
    class Company
    {
        private String name;
        private Register register;

        public Company(String name)
        {
            this.name = name;
            this.register = new Register();
        }

        public String getName() { return name; }
        public Register getRegister() { return register; }
}
}
