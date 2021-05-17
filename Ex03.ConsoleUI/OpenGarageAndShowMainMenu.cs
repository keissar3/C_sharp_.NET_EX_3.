namespace Ex03.ConsoleUI
{
    using System;
    using GarageLogic;

    internal class OpenGarageAndShowMainMenu
    {
        private enum eMainGarageMenu
        {
            InsertVehicleToGarage = 1,
            ShowVehicles = 2,
            ChangeVehiclesStatus = 3,
            InflateVehicleTires = 4,
            FuelGasVehicle = 5,
            ChargeElectricVehicle = 6,
            ShowVehicleDetails = 7,
            Exit = 8
        }

        public static void PlayMainMenuAndOpenGarage()
        {
            GarageLogic myGarage = new GarageLogic();
            int userSelection = 0;
            while (userSelection != (int)eMainGarageMenu.Exit)
            {
                userSelection = showMainGarageMenuAndGetUserInput();
                showSubMenuUsingUserSelection(userSelection, myGarage);
                Console.Clear();
            }
        }

        private static void showSubMenuUsingUserSelection(int i_UserSelection, GarageLogic i_MyGarage)
        {
            switch (i_UserSelection)
            {
                case (int)eMainGarageMenu.InsertVehicleToGarage:
                    {
                        InsertVehicleToGarageMenu.ShowInsertVehicleToGarageMenu(i_MyGarage);
                        break;
                    }
                case (int)eMainGarageMenu.ShowVehicles:
                    {
                        GetListOfVehiclePlateNumberMenu.ShowGetListOfVehiclePlateNumberMenu(i_MyGarage);
                        break;
                    }
                case (int)eMainGarageMenu.ChangeVehiclesStatus:
                    {
                        ChangeVehicleStatusInGarageMenu.ShowChangeVehiclesStatusMenu(i_MyGarage);
                        break;
                    }
                case (int)eMainGarageMenu.InflateVehicleTires:
                    {
                        InflateVehicleTiresMenu.ShowInflateVehicleTiresMenu(i_MyGarage);
                        break;
                    }
                case (int)eMainGarageMenu.FuelGasVehicle:
                    {
                        FuelGasCarMenu.ShowFuelGasVehicleMenu(i_MyGarage);
                        break;
                    }
                case (int)eMainGarageMenu.ChargeElectricVehicle:
                    {
                        ChargeElectricCarMenu.ShowChargeElectricVehicleMenu(i_MyGarage);
                        break;
                    }
                case (int)eMainGarageMenu.ShowVehicleDetails:
                    {
                        ShowVehicleDetailsMenu.ShowShowVehicleDetailsMenu(i_MyGarage);
                        break;
                    }
            }
        }

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

