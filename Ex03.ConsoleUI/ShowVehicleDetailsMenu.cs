namespace Ex03.ConsoleUI
{
    using System;
    using GarageLogic;

    internal class ShowVehicleDetailsMenu
    {
        internal static void ShowShowVehicleDetailsMenu(GarageLogic i_MyGarage)
        {
            Console.Clear();
            Console.WriteLine("Please enter vehicle license plate");

            string licensePlateNumber = Console.ReadLine();
            if (i_MyGarage.CheckIfVehicleIsExists(licensePlateNumber))
            {
                Record vehicleRecord = i_MyGarage.GetRecordByLicensePlate(licensePlateNumber);
                Console.WriteLine(vehicleRecord.ToString());
            }
            else
            {
                Console.Clear();
                Console.WriteLine("This vehicle is not found in our garage ");
            }

            Console.Write("Press ENTER to continue");
            Console.ReadLine();
        }
    }
}