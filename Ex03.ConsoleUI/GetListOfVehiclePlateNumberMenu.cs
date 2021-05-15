using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    using GarageLogic;
    enum eGetVehiclesListMenu
    {
        AllVehicles=1,
        RepairedVehicles,
        FixedVehicles, 
        PaidVehicles
    }
    class GetListOfVehiclePlateNumberMenu
    {
        public static void ShowGetListOfVehiclePlateNumberMenu(GarageLogic i_MyGarage)
        {
            Console.Clear();
            int userSelection = getUserSelection();
            switch (userSelection)
            {
                case (int) eGetVehiclesListMenu.AllVehicles:
                {
                    presentVehiclesPlateNumberList(i_MyGarage);
                    break;
                }
                case (int) eGetVehiclesListMenu.FixedVehicles:
                {
                    presentFixedVehiclesPlateNumberList(i_MyGarage);
                    break;
                }
                case (int) eGetVehiclesListMenu.PaidVehicles:
                {
                    presentPaidVehiclesPlateNumberList(i_MyGarage);
                    break;
                }
                case (int) eGetVehiclesListMenu.RepairedVehicles:
                {
                    presentRepairedVehiclesPlateNumberList(i_MyGarage);
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
        private static void presentVehiclesPlateNumberList(GarageLogic i_MyGarage)
        {
            List<Record> records = i_MyGarage.Records;
            foreach (var record in records)
            {
                Console.WriteLine(record.Vehicle.LicensePlateNumber);
            }
            Console.Write("Press any key to continue");
            string k = Console.ReadLine();
        }
        private static void presentFixedVehiclesPlateNumberList(GarageLogic i_MyGarage)
        {
            List<Record> records = i_MyGarage.Records;
            foreach (var record in records)
            {
                if (record.VehicleStatus == Record.eVehicleStatus.isFixed)
                {
                    Console.WriteLine(record.Vehicle.LicensePlateNumber);
                }
            }
            Console.Write("Press any key to continue");
            string k = Console.ReadLine();
        }
        private static void presentPaidVehiclesPlateNumberList(GarageLogic i_MyGarage)
        {
            List<Record> records = i_MyGarage.Records;
            foreach (var record in records)
            {
                if (record.VehicleStatus == Record.eVehicleStatus.isPaidUp)
                {
                    Console.WriteLine(record.Vehicle.LicensePlateNumber);
                }
            }
            Console.Write("Press any key to continue");
            string k = Console.ReadLine();
        }
        private static void presentRepairedVehiclesPlateNumberList(GarageLogic i_MyGarage)
        {
            List<Record> records = i_MyGarage.Records;
            foreach (var record in records)
            {
                if (record.VehicleStatus == Record.eVehicleStatus.inRepair)
                {
                    Console.WriteLine(record.Vehicle.LicensePlateNumber);
                }
            }
            Console.Write("Press any key to continue");
            string k = Console.ReadLine();
        }
    }
}
