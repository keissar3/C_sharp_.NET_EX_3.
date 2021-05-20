namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;

    public class VehicleFactory
    {
        private static readonly List<string> r_VehiclesList = new List<string>()
        {
            "Gas Bike",
            "Electric Bike",
            "Gas Car",
            "Electric Car",
            "Gas Truck"
        };

        public static List<string> GetVehiclesList()
        {
            return r_VehiclesList;
        }

        public static Vehicle CreateVehicle(string i_VehicleToBuild, string i_LicensePlateNumber)
        {
            Vehicle vehicleToReturn;
            switch (i_VehicleToBuild)
            {
                case "Gas Bike":
                    vehicleToReturn = new Bike(eTypeOfEngine.Gas, i_LicensePlateNumber);
                    break;
                case "Electric Bike":
                    vehicleToReturn = new Bike(eTypeOfEngine.Electric, i_LicensePlateNumber);
                    break;
                case "Gas Car":
                    vehicleToReturn = new Car(eTypeOfEngine.Gas, i_LicensePlateNumber);
                    break;
                case "Electric Car":
                    vehicleToReturn = new Car(eTypeOfEngine.Electric, i_LicensePlateNumber);
                    break;
                case "Gas Truck":
                    vehicleToReturn = new Truck(i_LicensePlateNumber);
                    break;
                default:
                    throw new ArgumentException("Vehicle type is not supported! ");
            }

            return vehicleToReturn;
        }
    }
}
