using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
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

        public static List<string> GetVehicleSpecs(string i_VehicleTypeToInsert)
        {
            List<string> vehicleSpecs = new List<string>();
            switch (i_VehicleTypeToInsert)
            {
                case "Gas Bike":
                    {
                        vehicleSpecs = getGasBikeSpecs();
                        break;
                    }
                case "Electric Bike":
                    {
                        vehicleSpecs = getElectricBikeSpecs();
                        break;
                    }
                case "Gas Car":
                    {
                        vehicleSpecs = getGasCarSpecs();
                        break;
                    }
                case "Electric Car":
                    {
                        vehicleSpecs = getElectricCarSpecs();
                        break;
                    }
                case "Gas Truck":
                    {
                        vehicleSpecs = getGasTruckSpecs();
                        break;
                    }
                default:
                    throw new ArgumentException("Vehicle type is not supported! ");
            }

            return vehicleSpecs;
        }

        private static List<string> getGasBikeSpecs() //TODO MAKE SURE SPECS MATCH WHAT IS NEEDED  
        {
            List<string> specsList = new List<string>();
            specsList.Add("Vehicle Model");
            specsList.Add("Wheels Manufacturer");
            specsList.Add("Wheels Count");
            specsList.Add("Wheels Current Tire Pressure");
            specsList.Add("Wheels Max Tire Pressure");
            specsList.Add("Gas Type");
            specsList.Add("Gas Capacity");
            return specsList;
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


        public static Vehicle CreateVehicle(string i_VehicleToBuild, Dictionary<string, string> i_VehicleSpecs, string i_LicensePlateNumber)
        {
            Vehicle vehicleToReturn;
            switch (i_VehicleToBuild)
            {
                case "Gas Bike":
                    vehicleToReturn = createGasBike(i_VehicleSpecs, i_LicensePlateNumber);
                    break;
                case "Electric Bike":
                    vehicleToReturn = createElectricBike(i_VehicleSpecs, i_LicensePlateNumber);
                    break;
                case "Gas Car":
                    vehicleToReturn = createGasCar(i_VehicleSpecs, i_LicensePlateNumber);
                    break;
                case "Electric Car":
                    vehicleToReturn = createElectricCar(i_VehicleSpecs, i_LicensePlateNumber);
                    break;
                case "Gas Truck":
                    vehicleToReturn = createGasTruck(i_VehicleSpecs, i_LicensePlateNumber);
                    break;
                default:
                    throw new ArgumentException("Vehicle type is not supported! ");
            }

            return vehicleToReturn;

        }
        private static Vehicle createGasBike(Dictionary<string, string> i_VehicleSpecs, string i_LicensePlateNumber)
        {
            //List<string> specsList = new List<string>();
            //specsList.Add("Vehicle Model");
            //specsList.Add("Wheels Manufacturer");
            //specsList.Add("Wheels Count");
            //specsList.Add("Wheels Current Tire Pressure");
            //specsList.Add("Wheels Max Tire Pressure");
            //specsList.Add("Gas Type");
            //specsList.Add("Gas Capacity");
            //return specsList;
            Bike resultBike = new Bike();
                

            //need to read the data and make the bike 

            return resultBike;
        }

        private static Vehicle createElectricCar(Dictionary<string, string> i_VehicleSpecs, string i_LicensePlateNumber)
        {
            //TODO PARSE LIST TO VARIABLES AND THROW EXCEPTIONS OTHERWISE
            throw new NotImplementedException();
        }

        private static Vehicle createGasTruck(Dictionary<string, string> i_VehicleSpecs, string i_LicensePlateNumber)
        {
            //TODO PARSE LIST TO VARIABLES AND THROW EXCEPTIONS OTHERWISE
            throw new NotImplementedException();
        }

        private static Vehicle createGasCar(Dictionary<string, string> i_VehicleSpecs, string i_LicensePlateNumber)
        {
            //TODO PARSE LIST TO VARIABLES AND THROW EXCEPTIONS OTHERWISE
            throw new NotImplementedException();
        }

        private static Vehicle createElectricBike(Dictionary<string, string> i_VehicleSpecs, string i_LicensePlateNumber)
        {
            //TODO PARSE LIST TO VARIABLES AND THROW EXCEPTIONS OTHERWISE
            throw new NotImplementedException();
        }

    }
}
