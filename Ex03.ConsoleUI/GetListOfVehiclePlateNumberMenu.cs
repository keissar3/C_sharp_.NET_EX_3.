namespace Ex03.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using GarageLogic;

    enum eGetVehiclesListMenu
    {
        AllVehicles = 1,
        RepairedVehicles,
        FixedVehicles,
        PaidVehicles
    }

    internal class GetListOfVehiclePlateNumberMenu
    {
        public static void ShowGetListOfVehiclePlateNumberMenu(GarageLogic i_MyGarage)
        {
            Console.Clear();
            int userSelection = getUserSelection();
            string messege=null;
            switch (userSelection)
            {
                case (int) eGetVehiclesListMenu.AllVehicles:
                {
                    presentVehiclesPlateNumberList(i_MyGarage.Records);
                    break;
                }
                case (int) eGetVehiclesListMenu.FixedVehicles:
                {
                    List<Record> fixedVehicleList =
                        i_MyGarage.GetListAccordingToStatus(Record.eVehicleStatus.isFixed, ref messege);
                    Console.WriteLine(messege);
                    presentVehiclesPlateNumberList(fixedVehicleList);
                    break;
                }
                case (int) eGetVehiclesListMenu.PaidVehicles:
                {
                    List<Record> paidVehicleList =
                        i_MyGarage.GetListAccordingToStatus(Record.eVehicleStatus.isPaidUp, ref messege);
                    Console.WriteLine(messege);
                    presentVehiclesPlateNumberList(paidVehicleList);
                    break;
                }
                case (int) eGetVehiclesListMenu.RepairedVehicles:
                {
                    List<Record> repairedVehicleList =
                        i_MyGarage.GetListAccordingToStatus(Record.eVehicleStatus.inRepair, ref messege);
                    Console.WriteLine(messege);
                    presentVehiclesPlateNumberList(repairedVehicleList) ;
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
2. Repaired vehicles
3. Fixed vehicles 
4. Paid vehicles");
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
