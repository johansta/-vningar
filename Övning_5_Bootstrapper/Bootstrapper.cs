using System.Globalization;
using System.Resources;

using Övning_5_Business_Logic;
using Övning_5_Presentation_Logic;
using System;
using System.Configuration;
using System.Threading;
using Övning_5_Tools;
using System.Reflection;

namespace Övning_5_Bootstrapper
{
    class Bootstrapper
    {
        static ResourceManager resourceManager;

        static void setupResources()
        {
            resourceManager = new ResourceManager("Övning_5_Resources.Resources.Resources", Assembly.Load("Övning_5_Resources"));

            string langauge = ConfigurationManager.AppSettings["language"];
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture(langauge);

            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }


        static void Main(string[] args)
        {
            setupResources();

            Input.ResourceManager = resourceManager;
            GarageHandler garageHandler = GarageHandler.GetInstance(resourceManager);       
            UserInterface userInterface = new UserInterface(resourceManager, garageHandler);

            userInterface.Run();        
        }

        
    }
}
