using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ex03.ConsoleUI
{
    using GarageLogic;
    
    
    
    public class InsertVehicleToGarageMenu
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
            }
            else
            {
                insertNewVehicleToGarage(licensePlateNumber, i_MyGarage);
                Console.WriteLine("The vehicle was successfully added to the garage.");
            }
            Thread.Sleep(3000);
        }

        private static void insertNewVehicleToGarage(string i_LicensePlate, GarageLogic i_MyGarage)
        {
            List<string> vehiclesList = VehicleFactory.GetVehiclesList();
            Console.Clear();
            Console.WriteLine("Please insert your name:");
            string ownerName = Console.ReadLine();
            Console.WriteLine("Please insert your phone number:");
            string ownerPhoneNumber = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("These are the vehicles that we support:");
            foreach (string vehicle in vehiclesList)
            {
                Console.WriteLine(vehicle);
            }

            Console.WriteLine("Which vehicle would you like to insert ?");
            string vehicleTypeToInsert = Console.ReadLine();
            Console.Clear();
            getInformationAboutTheVehicleFromUserAndCreateIt(i_LicensePlate,vehicleTypeToInsert,i_MyGarage,ownerName,ownerPhoneNumber);
            
            Console.Clear(); ;
           
        }

        private static void getInformationAboutTheVehicleFromUserAndCreateIt(string i_LicensePlate,string i_vehicleType, GarageLogic i_MyGarage,string i_OwnerName,string i_OwnerPhoneNumber)
        {
            List<string> vehicleSpecsNeeded = VehicleFactory.GetVehicleSpecs(i_vehicleType);

            Dictionary<string, string> specsOfVehicleToBuild = new Dictionary<string, string>();

            foreach (string specNeeded in vehicleSpecsNeeded)
            {
                Console.WriteLine("Please insert {0}", specNeeded);
                specsOfVehicleToBuild.Add(specNeeded, Console.ReadLine());
            }

            try
            {
                Vehicle vehicleToAdd=VehicleFactory.CreateVehicle(i_vehicleType, specsOfVehicleToBuild, i_LicensePlate);
                Record recordToAdd = new Record(i_OwnerName, i_OwnerPhoneNumber, vehicleToAdd);
                i_MyGarage.AddVehicleToGarageRecords(recordToAdd);
            }
            catch (FormatException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                specsOfVehicleToBuild.Clear();
                getInformationAboutTheVehicleFromUserAndCreateIt(i_LicensePlate, i_vehicleType,i_MyGarage,i_OwnerName,i_OwnerPhoneNumber);
            }
            catch (ValueOutOfRangeException exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                specsOfVehicleToBuild.Clear();
                getInformationAboutTheVehicleFromUserAndCreateIt(i_LicensePlate, i_vehicleType, i_MyGarage,i_OwnerName,i_OwnerPhoneNumber);
                
            }
            catch (Exception exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                specsOfVehicleToBuild.Clear();
                getInformationAboutTheVehicleFromUserAndCreateIt(i_LicensePlate, i_vehicleType, i_MyGarage, i_OwnerName,
                    i_OwnerPhoneNumber);
            }



        }
    }
}
