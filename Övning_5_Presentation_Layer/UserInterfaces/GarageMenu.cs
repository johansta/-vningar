using Övning_5_Data_Access_Layer;
using Övning_5_Resources;
using Övning_5_Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Presentation_Layer.UserInterfaces
{
    public class GarageMenu : UserInterface
    {
        public GarageMenu(ResourceContext resourceContext, InputHandler inputHandler, ValidationHandler validationHandler, GarageHandler garageHandler) : base(resourceContext, inputHandler, validationHandler)
        {           
            header = null;

            menuItems = new List<MenuItem>();

            menuItems.Add(new MenuItem('p', ResourceContext.Language.GetString("Menu_Park_Vehicle"), () => garageHandler.Park()));
            menuItems.Add(new MenuItem('d', ResourceContext.Language.GetString("Menu_Drive_Vehicle"), garageHandler.Drive));
            menuItems.Add(new MenuItem('l', ResourceContext.Language.GetString("Menu_List_Vehicles"), garageHandler.ListVehicles));
            menuItems.Add(new MenuItem('g', ResourceContext.Language.GetString("Menu_Group_Vehicles"), garageHandler.ListByVehicleType));
            menuItems.Add(new MenuItem('s', ResourceContext.Language.GetString("Menu_Search_License"), garageHandler.FindVehicleByLicense));
            menuItems.Add(new MenuItem('a', ResourceContext.Language.GetString("Menu_Search_Attribute"), garageHandler.FindVehicleByAttributes));
            menuItems.Add(new MenuItem('q', ResourceContext.Language.GetString("Menu_Return"), Exit));
        }
    }
}
