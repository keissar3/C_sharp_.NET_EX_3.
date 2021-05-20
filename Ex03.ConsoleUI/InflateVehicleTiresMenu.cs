namespace Ex03.ConsoleUI
{
    using System;
    using System.Threading;
    using GarageLogic;

    internal class InflateVehicleTiresMenu
    {
        internal static void ShowInflateVehicleTiresMenu(GarageLogic i_MyGarage)
        {
            Console.Clear();
            Console.WriteLine("Please enter vehicle license plate");
            string licensePlateNumber = Console.ReadLine();
            if (i_MyGarage.CheckIfVehicleIsExists(licensePlateNumber))
            {
                Console.Clear();
                Console.Write("How much air would you like to add ?");
                Vehicle userCar = i_MyGarage.GetVehicleByLicensePlate(licensePlateNumber);
                float validAirPressure = getValidAirPressure(userCar);
                userCar.InflateAllTires(validAirPressure);
            }
            else
            {
                Thread.Sleep(3000);
                Console.WriteLine("License plate doesn't exist in our system");
            }
        }

        private static float getValidAirPressure(Vehicle i_UserCar)
        {
            Console.Clear();
            Console.WriteLine("Please enter a number of how much air to add");
            float userSelection = -1;
            bool validSelection = false;
            while (validSelection == false)
            {
                string stringUserSelection = Console.ReadLine();
                validSelection = float.TryParse(stringUserSelection, out userSelection);
                if (validSelection == true)
                {
                    if (userSelection + i_UserCar.Wheels[0].CurrentTirePressure > i_UserCar.Wheels[0].MaxTirePressure)
                    {
                        validSelection = false;
                        Console.WriteLine("Too much air! ");
                        Console.WriteLine(
                            "Your car can only take {0} more air",
                            i_UserCar.Wheels[0].MaxTirePressure - i_UserCar.Wheels[0].CurrentTirePressure);
                    }
                }

                if (validSelection == false)
                {
                    Console.WriteLine("Please try again! ");
                }
            }

            Console.Clear();
            return userSelection;
        }
    }
}