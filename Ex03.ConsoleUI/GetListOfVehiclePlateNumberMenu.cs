namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using GarageLogic;

    internal enum eGetVehiclesListMenu
    {
        AllVehicles = 1,
        IsBeingRepairedVehicles,
        FixedVehicles,
        PaidForVehicles
    }

    internal class GetListOfVehiclePlateNumberMenu
    {
        public static void ShowGetListOfVehiclePlateNumberMenu(GarageLogic i_MyGarage)
        {
            Console.Clear();
            int userSelection = getUserSelection();
            string message = null;
            switch (userSelection)
            {
                case (int)eGetVehiclesListMenu.AllVehicles:
                    {
                        presentVehiclesPlateNumberList(i_MyGarage.Records);
                        break;
                    }

                case (int)eGetVehiclesListMenu.FixedVehicles:
                    {
                        List<Record> fixedVehicleList =
                            i_MyGarage.GetListAccordingToStatus(Record.eVehicleStatus.isFixed, ref message);
                        Console.WriteLine(message);
                        presentVehiclesPlateNumberList(fixedVehicleList);
                        break;
                    }

                case (int)eGetVehiclesListMenu.PaidForVehicles:
                    {
                        List<Record> paidVehicleList =
                            i_MyGarage.GetListAccordingToStatus(Record.eVehicleStatus.isPaidUp, ref message);
                        Console.WriteLine(message);
                        presentVehiclesPlateNumberList(paidVehicleList);
                        break;
                    }

                case (int)eGetVehiclesListMenu.IsBeingRepairedVehicles:
                    {
                        List<Record> repairedVehicleList =
                            i_MyGarage.GetListAccordingToStatus(Record.eVehicleStatus.inRepair, ref message);
                        Console.WriteLine(message);
                        presentVehiclesPlateNumberList(repairedVehicleList);
                        break;
                    }
            }
        }

        private static int getUserSelection()
        {
            int userSelection = 1;
            bool validSelection = false;
            while (validSelection == false)
            {
                Console.WriteLine(
                    @"Which vehicle would you like to get?
1. All Vehicles
2. Being repaired vehicles
3. Fixed vehicles 
4. Paid for vehicles");
                string stringUserSelection = Console.ReadLine();
                validSelection = int.TryParse(stringUserSelection, out userSelection);
                if (validSelection == true)
                {
                    if (userSelection < 1 || userSelection > 4)
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

            Console.Clear();
            return userSelection;
        }

        private static void presentVehiclesPlateNumberList(List<Record> i_Records)
        {
            foreach (var record in i_Records)
            {
                Console.WriteLine(record.Vehicle.LicensePlateNumber);
            }

            Console.Write("Press any key to continue");
            string k = Console.ReadLine();
        }
    }
}