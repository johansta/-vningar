using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_3
{
    class TextInputError : UserError
    {
        public override string UEMessage()
        {         
            return "​You tried to use a text input in a numericonly field. This fired an error!";
        }
    }
}
