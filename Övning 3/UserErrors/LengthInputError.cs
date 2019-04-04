using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_3.UserErrors
{
    class LengthInputError : UserError
    {
        public override string UEMessage()
        {
            return "Your text is to long. This fired an error!";
        }
    }
}
