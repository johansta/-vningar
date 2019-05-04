using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Resources
{
    public class ResourceContext
    {
        public ResourceManager Language { get; private set; }
        public ResourceManager PropertyToRegExp { get; private set; }
        public ResourceManager PropertyToId { get; private set; }
       
        public void Setup()
        {
            Assembly resourcesAssembly = Assembly.Load("Övning_5_Resources");

            Language = new ResourceManager("Övning_5_Resources.Language.Resources", resourcesAssembly);
            PropertyToRegExp = new ResourceManager("Övning_5_Resources.PropertyMapping.PropertyToRegExp", resourcesAssembly);
            PropertyToId = new ResourceManager("Övning_5_Resources.PropertyMapping.PropertyToId", resourcesAssembly);
        }
    }
}
