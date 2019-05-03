using Övning_5_Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Övning_5_Presentation_Logic.UserInterfaces
{
    public class GarageMenu : UserInterface
    {
        public GarageMenu(ResourceManager resourceManager, GarageHandler garageHandler) : base(resourceManager)
        {
            ResourceManager = resourceManager;

            header = null;

            menuItems = new List<MenuItem>();

            menuItems.Add(new MenuItem('p', resourceManager.GetString("Menu_Park_Vehicle"), () => garageHandler.Park()));
            menuItems.Add(new MenuItem('d', resourceManager.GetString("Menu_Drive_Vehicle"), garageHandler.Drive));
            menuItems.Add(new MenuItem('l', resourceManager.GetString("Menu_List_Vehicles"), garageHandler.ListVehicles));
            menuItems.Add(new MenuItem('g', resourceManager.GetString("Menu_Group_Vehicles"), garageHandler.ListByVehicleType));
            menuItems.Add(new MenuItem('s', resourceManager.GetString("Menu_Search_License"), garageHandler.FindVehicleByLicense));
            menuItems.Add(new MenuItem('a', resourceManager.GetString("Menu_Search_Attribute"), garageHandler.FindVehicleByAttributes));
            menuItems.Add(new MenuItem('q', resourceManager.GetString("Menu_Return"), Exit));
        }
    }
}
