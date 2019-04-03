using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public interface IPerson
    {       
        int Age { get; }

        string Fname { get; }
        string Lname { get; }

        double Height { get; }
        double Weight { get; }       
    }
}
