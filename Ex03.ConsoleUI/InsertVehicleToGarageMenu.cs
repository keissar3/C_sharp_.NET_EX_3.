using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    using GarageLogic;
    public class InsertVehicleToGarageMenu
    {
        internal static void ShowInsertVehicleToGarageMenu()
        {
            Console.Clear();
            Console.WriteLine("Please enter vehicle license plate");
            string licensePlateNumber = Console.ReadLine();
            // TODO CHECK IF VEHICLE ALREADY EXSITS IN GARAGE.
            insertNewVehicleToGarage(licensePlateNumber);
        }

        private static void insertNewVehicleToGarage(string i_LicensePlate)
        {
            List<string> vehiclesList = VehicleFactory.GetVehiclesList();

            Console.Clear();
            Console.WriteLine("These are the vehicles that we support:");
            foreach (string vehicle in vehiclesList)
            {
                Console.WriteLine(vehicle);
            }

            Console.WriteLine("Which vehicle would you like to insert ?");
            string vehicleTypeToInsert = Console.ReadLine();


            Console.Clear(); ;
            List<string> vehicleSpecsNeeded = VehicleFactory.GetVehicleSpecs(vehicleTypeToInsert);

            Dictionary<string, string> specsOfVehicleToBuild = new Dictionary<string, string>();

            foreach (string specNeeded in vehicleSpecsNeeded)
            {
                Console.WriteLine("Please insert {0}", specNeeded);
                specsOfVehicleToBuild.Add(specNeeded, Console.ReadLine());
            }

            VehicleFactory.CreateVehicle(vehicleTypeToInsert, specsOfVehicleToBuild, i_LicensePlate);


        }
    }
}
