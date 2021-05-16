using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    using GarageLogic;
    internal class ChangeVehicleStatusInGarageMenu
    {
        enum eSetStatusMenu
        {
            inRepair = 1,
            isFixed,
            isPaidUp
        }
        public static void ShowChangeVehiclesStatusMenu(GarageLogic i_MyGarage)
        {
            Console.WriteLine("Please insert the plate number of the vehicle");
            string ownerPlateNumber = Console.ReadLine();
            if (i_MyGarage.CheckIfVehicleIsExists(ownerPlateNumber) == false)
            {
                Console.WriteLine("The vehicle isn't in the garage.");
            }
            else
            {
                getUserInputStatusAndChangeIt(i_MyGarage, ownerPlateNumber);
            }
        }
        private static void getUserInputStatusAndChangeIt(GarageLogic i_MyGarage, string i_OwnerPlateNumber)
        {
            int userSelection = 1;
            bool validSelection = false;

            while (validSelection == false)
            {
                Console.WriteLine(@"To which status would you like to change?
1. In repair
2. Is fixed,
3. Is paid up");

                string stringUserSelection = Console.ReadLine();
                validSelection = int.TryParse(stringUserSelection, out userSelection);
                if (validSelection == true)
                {
                    if (userSelection < 1 || userSelection > 3)
                    {
                        validSelection = false;
                    }
                }

                if (validSelection == false)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid selection please try again! ");
                }
            }

            setVehicleStatusInTheGarage(i_MyGarage, i_OwnerPlateNumber, userSelection);

        }

        private static void setVehicleStatusInTheGarage(GarageLogic i_MyGarage, string i_OwnerPlateNumber,
            int i_StatusToChange)
        {
            switch (i_StatusToChange)
            {
                case (int)eSetStatusMenu.inRepair:
                    {
                        i_MyGarage.SetStatusInVehicle(i_OwnerPlateNumber, Record.eVehicleStatus.inRepair);
                        break;
                    }
                case (int)eSetStatusMenu.isFixed:
                    {
                        i_MyGarage.SetStatusInVehicle(i_OwnerPlateNumber, Record.eVehicleStatus.isFixed);
                        break;
                    }
                case (int)eSetStatusMenu.isPaidUp:
                    {
                        i_MyGarage.SetStatusInVehicle(i_OwnerPlateNumber, Record.eVehicleStatus.isPaidUp);
                        break;
                    }
            }
        }
    }
}
