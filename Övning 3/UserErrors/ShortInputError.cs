using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_3.UserErrors
{
    class ShortInputError : UserError
    {
        public override string UEMessage()
        {
            return "Your text is to short. This fired an error!";
        }
    }
}
