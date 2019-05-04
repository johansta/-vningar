using System.Globalization;
using System.Configuration;
using System.Threading;

using Övning_5_Presentation_Layer;
using Övning_5_Presentation_Layer.UserInterfaces;
using Övning_5_Resources;

namespace Övning_5_Bootstrapper
{
    class Bootstrapper
    {
        static void SetupConfiguration()
        {          
            string langauge = ConfigurationManager.AppSettings["language"];
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture(langauge);

            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }

        static void Main(string[] args)
        {
            ResourceContext resourceContext = new ResourceContext();
            resourceContext.Setup();

            SetupConfiguration();
           
            ValidationHandler validationHandler = new ValidationHandler(resourceContext);
            InputHandler inputHandler = new InputHandler(resourceContext, validationHandler);

            GarageHandler garageHandler = GarageHandler.GetInstance(resourceContext, inputHandler, validationHandler);
          
            UserInterface mainMenu = new MainMenu(resourceContext, inputHandler, validationHandler, garageHandler);       
            mainMenu.Run();   
            
        }

        
    }
}
