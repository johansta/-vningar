using Övning_5_Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Övning_5_Presentation_Layer
{
    public class ValidationHandler
    {
        public ValidationHandler(ResourceContext resourceContext)
        {
            ResourceContext = resourceContext;
        }

        public ResourceContext ResourceContext { get; private set; }

        public  bool Validate(String input, String property)
        {
            String pattern = ResourceContext.PropertyToRegExp.GetString(property);           
            Regex regex = new Regex(pattern);

            return regex.IsMatch(input);           
        }        
    }
}
