using System.Globalization;
using System.Resources;
using System.Configuration;
using System.Threading;
using System.Reflection;

using Övning_5_Tools;
using Övning_5_Business_Layer;
using Övning_5_Presentation_Layer;
using Övning_5_Presentation_Layer.UserInterfaces;

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
            
            UserInterface mainMenu = new MainMenu(resourceManager, garageHandler);
            mainMenu.Run();   
            
        }

        
    }
}
