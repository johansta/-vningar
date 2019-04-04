using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_3.UserErrors
{
    class EmptyInputError : UserError
    {
        public override string UEMessage()
        {
            return "Text is Empty. This fired an error!";
        }
    }
}
