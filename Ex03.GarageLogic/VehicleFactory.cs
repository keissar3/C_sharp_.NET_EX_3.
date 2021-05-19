using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public enum eVehiclesSupported
        {
            GasBike=1,
            ElectricBike,
            GasCar,
            ElectricCar,
            Truck
        }
        public static Vehicle CreateVehicle(int i_VehicleToBuild, string i_LicensePlateNumber)
        {
            Vehicle vehicleToReturn;
            switch (i_VehicleToBuild)
            {
                case (int)eVehiclesSupported.GasBike:
                    vehicleToReturn = new Bike(eTypeOfEngine.Gas, i_LicensePlateNumber);
                    break;
                case (int)eVehiclesSupported.ElectricBike:
                    vehicleToReturn = new Bike(eTypeOfEngine.Electric, i_LicensePlateNumber);
                    break;
                case (int)eVehiclesSupported.GasCar:
                    vehicleToReturn = new Car(eTypeOfEngine.Gas, i_LicensePlateNumber);
                    break;
                case (int)eVehiclesSupported.ElectricCar:
                    vehicleToReturn = new Car(eTypeOfEngine.Electric, i_LicensePlateNumber);
                    break;
                case (int)eVehiclesSupported.Truck:
                    vehicleToReturn = new Truck(i_LicensePlateNumber);
                    break;
                default:
                    throw new ArgumentException("Vehicle type is not supported! ");
            }

            return vehicleToReturn;
        }
    }
}
