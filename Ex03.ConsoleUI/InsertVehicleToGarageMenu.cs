namespace Ex03.ConsoleUI
{
    using System;
    using System.Threading;
    using System.Collections.Generic;
    using GarageLogic;

    internal class InsertVehicleToGarageMenu
    {
        internal static void ShowInsertVehicleToGarageMenu(GarageLogic i_MyGarage)
        {
            Console.Clear();
            Console.WriteLine("Please enter vehicle license plate");
            string licensePlateNumber = Console.ReadLine();
            if (i_MyGarage.CheckIfVehicleIsExists(licensePlateNumber))
            {
                Console.Clear();
                Console.WriteLine("The vehicle is already exists");
                i_MyGarage.SetStatusInVehicle(licensePlateNumber, Record.eVehicleStatus.inRepair);
            }
            else
            {
                Console.WriteLine("Please insert your name:");
                string ownerName = Console.ReadLine();
                Console.WriteLine("Please insert your phone number:");
                string ownerPhoneNumber = Console.ReadLine();
                Console.Clear();
                insertNewVehicleToGarage(licensePlateNumber, i_MyGarage, ownerName, ownerPhoneNumber);
                Console.WriteLine("The vehicle was successfully added to the garage.");
            }
            Thread.Sleep(3000);
        }

        private static void insertNewVehicleToGarage(string i_LicensePlate, GarageLogic i_MyGarage, string i_OwnerName, string i_OwnerPhoneNumber)
        {

            string vehicleTypeToInsert = getFromUserTypeOfVehicle();
            try
            {
                getInformationAboutTheVehicleFromUserAndCreateIt(i_LicensePlate, vehicleTypeToInsert, i_MyGarage,
                    i_OwnerName, i_OwnerPhoneNumber);
            }
            catch (ArgumentException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                insertNewVehicleToGarage(i_LicensePlate, i_MyGarage, i_OwnerName, i_OwnerPhoneNumber);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
            Console.Clear(); ;
        }

        private static string getFromUserTypeOfVehicle()
        {
            List<string> vehiclesList = VehicleFactory.GetVehiclesList();
            Console.WriteLine("These are the vehicles that we support:");
            foreach (string vehicle in vehiclesList)
            {
                Console.WriteLine(vehicle);
            }

            Console.WriteLine("Which vehicle would you like to insert ?");
            string vehicleTypeToInsert = Console.ReadLine();


            return vehicleTypeToInsert;
        }

        private static void getInformationAboutTheVehicleFromUserAndCreateIt(string i_LicensePlate, string i_VehicleType, GarageLogic i_MyGarage, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            List<string> vehicleSpecsNeeded = VehicleFactory.GetVehicleSpecs(i_VehicleType);

            Dictionary<string, string> specsOfVehicleToBuild = new Dictionary<string, string>();

            foreach (string specNeeded in vehicleSpecsNeeded)
            {
                Console.WriteLine("Please insert {0}", specNeeded);
                specsOfVehicleToBuild.Add(specNeeded, Console.ReadLine());
            }

            try
            {
                Vehicle vehicleToAdd = VehicleFactory.CreateVehicle(i_VehicleType, specsOfVehicleToBuild, i_LicensePlate);
                Record recordToAdd = new Record(i_OwnerName, i_OwnerPhoneNumber, vehicleToAdd);
                i_MyGarage.AddVehicleToGarageRecords(recordToAdd);
            }
            catch (FormatException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                specsOfVehicleToBuild.Clear();
                getInformationAboutTheVehicleFromUserAndCreateIt(i_LicensePlate, i_VehicleType, i_MyGarage, i_OwnerName, i_OwnerPhoneNumber);
            }
            catch (ValueOutOfRangeException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                specsOfVehicleToBuild.Clear();
                getInformationAboutTheVehicleFromUserAndCreateIt(i_LicensePlate, i_VehicleType, i_MyGarage, i_OwnerName, i_OwnerPhoneNumber);

            }
            catch (Exception exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                specsOfVehicleToBuild.Clear();
                getInformationAboutTheVehicleFromUserAndCreateIt(i_LicensePlate, i_VehicleType, i_MyGarage, i_OwnerName,
                    i_OwnerPhoneNumber);
            }
        }
    }
}
