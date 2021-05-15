using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    using GarageLogic;

    class OpenGarageAndShowMainMenu
    {
        // ------------------------------------------------------ enum for main menu
        private enum eMainGarageMenu
        {
            InsertVehicleToGarage = 1,
            ShowVehicles = 2,
            ChangeVehiclesStatus = 3,
            InflateVehicleTires = 4,
            FuelGasVehicle = 5,
            ChargeElectricVehicle = 6,
            ShowVehicleDetails = 7,
        }
        // -----------------------------------------------------END  enum for main menu 

        // ----------------------------------------------------- choose sub menus
        public static void PlayMainMenueAndOpenGarage()
        {

            GarageLogic MyGarage = new GarageLogic();
            int userSelection = 0;
            while (userSelection != 8)
            {
                userSelection = showMainGarageMenuAndGetUserInput();
                showSubMenuUsingUserSelection(userSelection, MyGarage);
                Console.Clear();
            }
        }

        private static void showSubMenuUsingUserSelection(int i_UserSelection, GarageLogic i_MyGarage)
        {
            switch (i_UserSelection)
            {
                case (int) eMainGarageMenu.InsertVehicleToGarage:
                {
                    InsertVehicleToGarageMenu.ShowInsertVehicleToGarageMenu(i_MyGarage);
                    break;
                }
                case (int) eMainGarageMenu.ShowVehicles:
                {
                    GetListOfVehiclePlateNumberMenu.ShowGetListOfVehiclePlateNumberMenu(i_MyGarage);
                    break;
                }
                case (int) eMainGarageMenu.ChangeVehiclesStatus:
                {
                    ChangeVehicleStatusInGarageMenu.showChangeVehiclesStatusMenu(i_MyGarage);
                    break;
                }
                case (int) eMainGarageMenu.InflateVehicleTires:
                {
                    showInflateVehicleTiresMenu();
                    break;
                }
                case (int) eMainGarageMenu.FuelGasVehicle:
                {
                    showFuelGasVehicleMenu();
                    break;
                }
                case (int) eMainGarageMenu.ChargeElectricVehicle:
                {
                    showChargeElectricVehicleMenu();
                    break;
                }
                case (int) eMainGarageMenu.ShowVehicleDetails:
                {
                    showShowVehicleDetailsMenu();
                    break;
                }
            }
        }

        // -----------------------------------------------------END choose sub menus

        // ----------------------------------------------------- sub menus



        private static void showShowVehiclesMenu()
        {
            throw new NotImplementedException();
        }

        private static void showInflateVehicleTiresMenu()
        {
            throw new NotImplementedException();
        }

        private static void showFuelGasVehicleMenu()
        {
            throw new NotImplementedException();
        }

        private static void showChargeElectricVehicleMenu()
        {
            throw new NotImplementedException();
        }

        private static void showShowVehicleDetailsMenu()
        {
            throw new NotImplementedException();
        }

        // -----------------------------------------------------END sub menus

        private static int showMainGarageMenuAndGetUserInput()
        {
            int userSelection = 1;
            bool validSelection = false;
            while (validSelection == false)
            {
                Console.WriteLine(
                    @"1. Insert new vehicle to the garage
2. Show vehicles in garage
3. Change vehicle status
4. Inflate vehicle tires
5. Fuel a gasoline vehicle
6. Charge an electric vehicle
7. Show vehicle details
8. Exit");
                string stringUserSelection = Console.ReadLine();
                validSelection = int.TryParse(stringUserSelection, out userSelection);
                if (validSelection == true)
                {
                    if (userSelection < 1 || userSelection > 8)
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

            return userSelection;
        }

    }

}
    
