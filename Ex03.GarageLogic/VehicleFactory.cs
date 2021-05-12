using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class VehicleFactory
    {
        private static readonly List<string> r_VehiclesList = new List<string>()
        {
            "GasBike",
            "ElectricBike",
            "GasCar",
            "ElectricCar",
            "GasTruck"
        };

        public static List<string> GetVehiclesList()
        {
            return r_VehiclesList;
        }

        public static List<string> GetVehicleSpecs(string i_VehicleToEnter)
        {
            List<string> vehicleSpecs = new List<string>();
            switch (i_VehicleToEnter)
            {
                case "GasBike":
                    vehicleSpecs = getGasBikeSpecs();
                    break;
                case "ElectricBike":
                    vehicleSpecs = getElectricBikeSpecs();
                    break;
                case "GasCar":
                    vehicleSpecs = getGasCarSpecs();
                    break;
                case "ElectricCar":
                    vehicleSpecs = getElectricCarSpecs();
                    break;
                case "GasTruck":
                    vehicleSpecs = getGasTruckSpecs();
                    break;
                default:
                    throw new ArgumentException("Vehicle type is not supported! ");
            }

            return vehicleSpecs;
        }

        private static List<string> getGasTruckSpecs() //TODO MAKE SURE SPECS MATCH WHAT IS NEEDED  
        {
            List<string> specsList = new List<string>();
            specsList.Add("Wheel Count");
            specsList.Add("Tire Pressure");
            specsList.Add("Gas Type");
            specsList.Add("Gas Capacity");
            return specsList;
        }

        private static List<string> getElectricCarSpecs() //TODO MAKE SURE SPECS MATCH WHAT IS NEEDED 
        {
            List<string> specsList = new List<string>();
            specsList.Add("Wheel Count");
            specsList.Add("Tire Pressure");
            specsList.Add("Gas Type");
            specsList.Add("Gas Capacity");
            return specsList;
        }

        private static List<string> getGasCarSpecs() //TODO MAKE SURE SPECS MATCH WHAT IS NEEDED 
        {
            List<string> specsList = new List<string>();
            specsList.Add("Wheel Count");
            specsList.Add("Tire Pressure");
            specsList.Add("Gas Type");
            specsList.Add("Gas Capacity");
            return specsList;
        }

        private static List<string> getElectricBikeSpecs() //TODO MAKE SURE SPECS MATCH WHAT IS NEEDED 
        {
            List<string> specsList = new List<string>();
            specsList.Add("Wheel Count");
            specsList.Add("Tire Pressure");
            specsList.Add("Gas Type");
            specsList.Add("Gas Capacity");
            return specsList;
        }
        private static List<string> getGasBikeSpecs() //TODO MAKE SURE SPECS MATCH WHAT IS NEEDED 
        {
            List<string> specsList = new List<string>();
            specsList.Add("Wheel Count");
            specsList.Add("Tire Pressure");
            specsList.Add("Gas Type");
            specsList.Add("Gas Capacity");
            return specsList;
        }

        public static Vehicle CreateVehicle(string i_VehicleToBuild, List<string> i_VehicleSpecs)
        {
            Vehicle vehicleToReturn;
            switch (i_VehicleToBuild)
            {
                case "GasBike":
                    vehicleToReturn = createGasBike(i_VehicleSpecs);
                    break;
                case "ElectricBike":
                    vehicleToReturn = createElectricBike(i_VehicleSpecs);
                    break;
                case "GasCar":
                    vehicleToReturn = createGasCar(i_VehicleSpecs);
                    break;
                case "ElectricCar":
                    vehicleToReturn = createElectricCar(i_VehicleSpecs);
                    break;
                case "GasTruck":
                    vehicleToReturn = createGasTruck(i_VehicleSpecs);
                    break;
                default:
                    throw new ArgumentException("Vehicle type is not supported! ");
            }

            return vehicleToReturn;

        }

        private static Vehicle createElectricCar(List<string> i_VehicleSpecs)
        {
            //TODO PARSE LIST TO VARIABLES AND THROW EXCEPTIONS OTHERWISE
            throw new NotImplementedException();
        }

        private static Vehicle createGasTruck(List<string> i_VehicleSpecs)
        {
            //TODO PARSE LIST TO VARIABLES AND THROW EXCEPTIONS OTHERWISE
            throw new NotImplementedException();
        }

        private static Vehicle createGasCar(List<string> i_VehicleSpecs)
        {
            //TODO PARSE LIST TO VARIABLES AND THROW EXCEPTIONS OTHERWISE
            throw new NotImplementedException();
        }

        private static Vehicle createElectricBike(List<string> i_VehicleSpecs)
        {
            //TODO PARSE LIST TO VARIABLES AND THROW EXCEPTIONS OTHERWISE
            throw new NotImplementedException();
        }

        private static Vehicle createGasBike(List<string> i_VehicleSpecs)
        {
            //TODO PARSE LIST TO VARIABLES AND THROW EXCEPTIONS OTHERWISE
            throw new NotImplementedException();
        }
    }
}
