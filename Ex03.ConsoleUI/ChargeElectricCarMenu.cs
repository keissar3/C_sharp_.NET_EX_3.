namespace Ex03.ConsoleUI
{
    using System;
    using System.Threading;
    using GarageLogic;

    internal class ChargeElectricCarMenu
    {
        internal static void ShowChargeElectricVehicleMenu(GarageLogic i_MyGarage)
        {
            Console.Clear();
            Console.WriteLine("Please enter vehicle license plate");

            string licensePlateNumber = Console.ReadLine();
            if (i_MyGarage.CheckIfVehicleIsExists(licensePlateNumber))
            {
                Vehicle userCar = i_MyGarage.GetVehicleByLicensePlate(licensePlateNumber);
                if (userCar.Engine is ElectricEngine == false)
                {
                    Console.Clear();
                    Console.WriteLine("This vehicle is not and electric vehicle ");
                }
                else
                {
                    ElectricEngine userEngine = (ElectricEngine)userCar.Engine;
                    float validMinutesToCharge = getValidMinutesToCharge(userEngine);
                    userEngine.ChargeBattery(validMinutesToCharge);
                    Console.WriteLine("Charging...");
                    Thread.Sleep(2000);
                    Console.Clear();
                }

            }

            else
            {
                Console.Clear();
                Console.WriteLine("This vehicle is not found in our garage ");
            }

            Thread.Sleep(2000);
        }

        private static float getValidMinutesToCharge(ElectricEngine i_UserEngine)
        {
            Console.Clear();
            float userSelection = -1;
            bool validSelection = false;

            Console.Clear();
            while (validSelection == false)
            {
                Console.WriteLine("Please enter how many minutes would you like to charge you car");
                string stringUserSelection = Console.ReadLine();
                validSelection = float.TryParse(stringUserSelection, out userSelection);
                if (validSelection == true)
                {
                    if (((userSelection / 60) + i_UserEngine.BatteryCharge) > i_UserEngine.BatteryCapacity)
                    {
                        validSelection = false;
                        Console.WriteLine("Too many minutes to charge! ");
                        Console.WriteLine("Your car can only take {0} more minutes of charging",
                            (i_UserEngine.BatteryCapacity - i_UserEngine.BatteryCharge) * 60);
                    }
                }

                if (validSelection == false)
                {
                    Console.WriteLine("Please try again! ");
                }
            }

            return userSelection / 60;
        }
    }
}