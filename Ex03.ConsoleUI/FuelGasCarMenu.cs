namespace Ex03.ConsoleUI
{
    using System;
    using System.Threading;
    using GarageLogic;

    internal class FuelGasCarMenu
    {
        internal static void ShowFuelGasVehicleMenu(GarageLogic i_MyGarage)
        {
            Console.Clear();
            Console.WriteLine("Please enter vehicle license plate");

            string licensePlateNumber = Console.ReadLine();
            if (i_MyGarage.CheckIfVehicleIsExists(licensePlateNumber))
            {
                Vehicle userCar = i_MyGarage.GetVehicleByLicensePlate(licensePlateNumber);
                if (userCar.Engine is GasEngine == false)
                {
                    Console.Clear();
                    Console.WriteLine("This vehicle is not Gasoline vehicle ");
                }
                else
                {
                    GasEngine userEngine = (GasEngine)userCar.Engine;
                    float validFuelAmount = getValidFuelAmountOfValidFuelType(userEngine);
                    userEngine.FillUpGas(validFuelAmount, userEngine.GasType);
                    Console.WriteLine("Fueling...");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("This vehicle is not found in our garage ");
            }
        }

        private static void printGasTypeSelectionOptions()
        {
            int i = 1;
            foreach (var value in Enum.GetValues(typeof(eGasType)))
            {
                Console.WriteLine("{0}.{1}", i, value.ToString());
                i++;
            }
        }

        private static float getValidFuelAmountOfValidFuelType(GasEngine userEngine)
        {
            Console.Clear();
            int userSelection = -1;
            bool validSelection = false;

            Console.Clear();
            while (validSelection == false)
            {
                Console.WriteLine("Please enter the number next to which Gas Type you would like to fuel your car with");
                printGasTypeSelectionOptions();
                string stringUserSelection = Console.ReadLine();
                validSelection = int.TryParse(stringUserSelection, out userSelection);
                if (validSelection == true)
                {
                    if ((eGasType)userSelection != userEngine.GasType)
                    {
                        Console.Clear();
                        validSelection = false;
                        Console.WriteLine("Wrong Fuel Type!");
                        Console.WriteLine("Your car can only take {0} ", userEngine.GasType.ToString());
                    }
                }

                if (validSelection == false)
                {
                    Console.WriteLine("Please try again! ");
                }
            }

            validSelection = false;
            float fuelUserSelection = -1;
            Console.Clear();
            while (validSelection == false)
            {
                Console.WriteLine("Please enter How much fuel you would like to fuel");
                string stringUserSelection = Console.ReadLine();
                validSelection = float.TryParse(stringUserSelection, out fuelUserSelection);
                if (validSelection == true)
                {
                    if (fuelUserSelection + userEngine.GasGague > userEngine.GasCapacity)
                    {
                        validSelection = false;
                        Console.WriteLine("Too much Fuel! ");
                        Console.WriteLine("Your car can only take {0} more Fuel", userEngine.GasCapacity - userEngine.GasGague);
                    }
                }

                if (validSelection == false)
                {
                    Console.WriteLine("Please try again! ");
                }
            }

            Console.Clear();
            return fuelUserSelection;
        }
    }
}