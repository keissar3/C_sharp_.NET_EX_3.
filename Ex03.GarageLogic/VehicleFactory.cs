using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
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
            specsList.Add("License Type");
            specsList.Add("Wheels Manufacturer");
            specsList.Add("Wheels Count");
            specsList.Add("Wheels Current Tire Pressure");
            specsList.Add("Wheels Max Tire Pressure");
            specsList.Add("Engine Volume");
            specsList.Add("Gas Type");
            specsList.Add("Gas Gauge");
            specsList.Add("Gas Capacity");
            return specsList;
        }

        private static List<string> getGasTruckSpecs() //TODO MAKE SURE SPECS MATCH WHAT IS NEEDED  
        {
            List<string> specsList = new List<string>();

            specsList.Add("Vehicle Model");
            specsList.Add("Wheels Manufacturer");
            specsList.Add("Wheels Count");
            specsList.Add("Wheels Current Tire Pressure");
            specsList.Add("Wheels Max Tire Pressure");
            specsList.Add("Is Transporting Hazardous Materials?"); 
            specsList.Add("Payload Capacity");
            return specsList;
        }

        private static List<string> getElectricCarSpecs() //TODO MAKE SURE SPECS MATCH WHAT IS NEEDED 
        {
            List<string> specsList = new List<string>();
            specsList.Add("Vehicle Model");
            specsList.Add("Wheels Manufacturer");
            specsList.Add("Wheels Count");
            specsList.Add("Wheels Current Tire Pressure");
            specsList.Add("Wheels Max Tire Pressure");
            specsList.Add("Car Color");
            specsList.Add("Doors Count");
            specsList.Add("Battery Charge");
            specsList.Add("Battery Capacity");

            return specsList;
        }

        private static List<string> getGasCarSpecs() //TODO MAKE SURE SPECS MATCH WHAT IS NEEDED 
        {
            List<string> specsList = new List<string>();
            specsList.Add("Vehicle Model");
            specsList.Add("Wheels Manufacturer");
            specsList.Add("Wheels Count");
            specsList.Add("Wheels Current Tire Pressure");
            specsList.Add("Wheels Max Tire Pressure");
            specsList.Add("Car Color");
            specsList.Add("Doors Count");
            specsList.Add("Gas Type");
            specsList.Add("Gas Gauge");
            specsList.Add("Gas Capacity");

            return specsList;
        }

        private static List<string> getElectricBikeSpecs() //TODO MAKE SURE SPECS MATCH WHAT IS NEEDED 
        {
            List<string> specsList = new List<string>();
            specsList.Add("Vehicle Model");
            specsList.Add("License Type");
            specsList.Add("Wheels Manufacturer");
            specsList.Add("Wheels Count");
            specsList.Add("Wheels Current Tire Pressure");
            specsList.Add("Wheels Max Tire Pressure");
            specsList.Add("Engine Volume");
            specsList.Add("Battery Charge");
            specsList.Add("Battery Capacity");

            return specsList;
        }


        public static Vehicle CreateVehicle(string i_VehicleToBuild, Dictionary<string, string> i_VehicleSpecs,
            string i_LicensePlateNumber)
        {
            Vehicle vehicleToReturn;
            switch (i_VehicleToBuild)
            {
                case "Gas Bike":
                    vehicleToReturn = createBike(i_VehicleSpecs, i_LicensePlateNumber, 0);
                    break;
                case "Electric Bike":
                    vehicleToReturn = createBike(i_VehicleSpecs, i_LicensePlateNumber, 1);
                    break;
                case "Gas Car":
                    vehicleToReturn = createCar(i_VehicleSpecs, i_LicensePlateNumber,0);
                    break;
                case "Electric Car":
                    vehicleToReturn = createCar(i_VehicleSpecs, i_LicensePlateNumber,1);
                    break;
                case "Gas Truck":
                    vehicleToReturn = createGasTruck(i_VehicleSpecs, i_LicensePlateNumber);
                    break;
                default:
                    throw new ArgumentException("Vehicle type is not supported! ");
            }

            return vehicleToReturn;

        }

        private static GasEngine.eGasType getGasType(string i_GasType)
        {
            GasEngine.eGasType gasType;

            switch (i_GasType)
            {
                case "Octan 95":
                    gasType = GasEngine.eGasType.Octan95;
                    break;
                case "Octan 98":
                    gasType = GasEngine.eGasType.Octan98;
                    break;
                case "Soler":
                    gasType = GasEngine.eGasType.Soler;
                    break;
                default:
                    throw new ValueOutOfRangeException(@"The gas type we support is only: 
 Octan 98
 Octan 95
 Soler");


            }

            return gasType;

        }

        private static Bike.eLicenseType getLicenceType(string i_LicenceType)
        {
            Bike.eLicenseType licenceType;
            switch (i_LicenceType)
            {
                case "A":
                    licenceType = Bike.eLicenseType.A;
                    break;
                case "B1":
                    licenceType = Bike.eLicenseType.B1;
                    break;
                case "AA":
                    licenceType = Bike.eLicenseType.AA;
                    break;
                case "BB":
                    licenceType = Bike.eLicenseType.BB;
                    break;
                default:
                    throw new ValueOutOfRangeException(@"The licenses type we support is only: 
A
B1
AA
BB");

            }

            return licenceType;
        }

        private static int getNumOfWheels(string i_NumOfWheels, int i_NumOfWhellsSupported)
        {
            int numOfWheels;
            if (int.TryParse(i_NumOfWheels, out numOfWheels) == false)
            {
                throw new FormatException("Number of wheels must be a number");
            }

            if (numOfWheels != i_NumOfWhellsSupported)
            {
                throw new ValueOutOfRangeException(string.Format("The number of wheels required is {0}. ",
                    i_NumOfWhellsSupported));
            }

            return numOfWheels;
        }

        private static int getEngineVolume(string i_EngineVolume)
        {
            int engineVolume;
            if (int.TryParse(i_EngineVolume, out engineVolume) == false)
            {
                throw new FormatException("Engine volume must be a number");
            }

            return engineVolume;
        }

        private static float getMaxTirePressure(string i_MaxTirePressure, float i_MaxTireSupport)
        {
            float maxTirePressure;

            if (float.TryParse(i_MaxTirePressure, out maxTirePressure) == false)
            {
                throw new FormatException("The max tire pressure must be a number.");
            }

            if (maxTirePressure != i_MaxTireSupport)
            {
                throw new ValueOutOfRangeException(string.Format("The max tire pressure we support is {0}.",
                    i_MaxTireSupport));
            }

            return maxTirePressure;
        }

        private static float getCurrentTirePressure(string i_CurrentTirePressure, float maxTirePressure)
        {
            float currentTirePressure;
            if (float.TryParse(i_CurrentTirePressure, out currentTirePressure) == false)
            {
                throw new FormatException("The current tire pressure must be a number.");
            }

            if (currentTirePressure > maxTirePressure)
            {
                throw new ValueOutOfRangeException(String.Format("The current tire pressure need to be less than {0}.",
                    maxTirePressure));
            }

            return maxTirePressure;
        }

        private static float getCurrentChargeOrGauge(string i_ChargeOrGauge, float i_Capacity)
        {
            float currenyChargeOrGauge;
            if (float.TryParse(i_ChargeOrGauge, out currenyChargeOrGauge) == false)
            {
                throw new FormatException("Gas gauge must be a number.");
            }

            if (currenyChargeOrGauge > i_Capacity)
            {
                throw new ValueOutOfRangeException(string.Format("The gas gauge need to be less than {0}", i_Capacity));
            }

            return currenyChargeOrGauge;
        }

        private static float getCapacity(string i_Capacity, float i_CapcitySuppoted)
        {
            float capacity;
            if (float.TryParse(i_Capacity, out capacity) == false)
            {
                throw new FormatException("The capacity must be a number.");
            }

            if (capacity != i_CapcitySuppoted)
            {
                throw new ValueOutOfRangeException(String.Format("The capacity we support is {0}.", i_CapcitySuppoted));
            }

            return capacity;
        }
        private static Car.eColor getCarColor(string i_CarColor)
        {
            Car.eColor carColor;

            switch (i_CarColor)
            {
                case "Black":
                    carColor = Car.eColor.Black;
                    break;
                case "Red":
                    carColor = Car.eColor.Red;
                    break;
                case "Silver":
                    carColor = Car.eColor.Silver;
                    break;
                case "White":
                    carColor = Car.eColor.White;
                    break;
                default:
                    throw new ValueOutOfRangeException(@"The color type we support is only: 
Black
Red
Silver
White");


            }

            return carColor;

        }
        private static Car.eDoorCount getCarDoorCount(string i_DoorsCount)
        {
            Car.eDoorCount carDoorsCount;

            switch (i_DoorsCount)
            {
                case "2":
                    carDoorsCount = Car.eDoorCount._2;
                    break;
                case "3":
                    carDoorsCount = Car.eDoorCount._3;
                    break;
                case "4":
                    carDoorsCount = Car.eDoorCount._4;
                    break;
                case "5":
                    carDoorsCount = Car.eDoorCount._5;
                    break;
                default:
                    throw new ValueOutOfRangeException(@"The number of doors we support is only:
2
3
4
5");


            }

            return carDoorsCount;

        }

        private static float getPayLoadCapacity(string iPayloadCapacity)
        {
            float payloadCapacity;
            if (float.TryParse(iPayloadCapacity, out payloadCapacity) == false)
            {
                throw new FormatException("The capacity must be a number.");
            }

            return payloadCapacity;
        }
        private static bool getIsTransportingHazardousMaterials(string i_IsTransportingHazardousMaterials)
        {
            bool isTransportingHazardousMaterials;
            switch (i_IsTransportingHazardousMaterials)
            {
                case "Yes":
                    isTransportingHazardousMaterials = true;
                    break;
                case "No":
                    isTransportingHazardousMaterials = false;
                    break;
                default:
                    throw new ValueOutOfRangeException(@"Is a Yes or No question so please insert:
Yes
No");

            }

            return isTransportingHazardousMaterials;
        }
        private static Vehicle createCar(Dictionary<string, string> i_VehicleSpecs, string i_LicensePlateNumber,int i_TypeOfCar)
        {
            string vehicleModel = i_VehicleSpecs["Vehicle Model"];
            string wheelsManufacturer = i_VehicleSpecs["Wheels Manufacturer"];
            int numOfWheels = getNumOfWheels(i_VehicleSpecs["Wheels Count"], 4);
            float wheelsMaxTirePressure = getMaxTirePressure(i_VehicleSpecs["Wheels Max Tire Pressure"], 32);
            float wheelsCurrentTirePressure = getCurrentTirePressure(i_VehicleSpecs["Wheels Current Tire Pressure"], wheelsMaxTirePressure);

            Car.eColor carColor = getCarColor(i_VehicleSpecs["Car Color"]);
            Car.eDoorCount carDoorCount = getCarDoorCount(i_VehicleSpecs["Doors Count"]);
            
            Engine engine = null;
            if (i_TypeOfCar == 0)
            {
                GasEngine.eGasType gasType = getGasType(i_VehicleSpecs["Gas Type"]);
                float gasCapacity = getCapacity(i_VehicleSpecs["Gas Capacity"], 45);
                float gasGauge = getCurrentChargeOrGauge(i_VehicleSpecs["Gas Gauge"], gasCapacity);
                engine = new GasEngine(gasType, gasGauge, gasCapacity);
            }
            else if (i_TypeOfCar == 1)
            {
                float batteryCapacity = getCapacity(i_VehicleSpecs["Battery Capacity"], 3.2f);
                float batteryCharge = getCurrentChargeOrGauge(i_VehicleSpecs["Battery Charge"], batteryCapacity);
                engine = new ElectricEngine(batteryCharge, batteryCapacity);
            }

            Wheel[] arrayOfWheels = getArrayOfWheels(wheelsManufacturer, wheelsCurrentTirePressure,
                wheelsMaxTirePressure, numOfWheels);
           

            Car resultCar = new Car(arrayOfWheels, engine, vehicleModel, i_LicensePlateNumber, carColor, carDoorCount);

            return resultCar;
        }

        private static Vehicle createGasTruck(Dictionary<string, string> i_VehicleSpecs, string i_LicensePlateNumber)
        {
            string vehicleModel = i_VehicleSpecs["Vehicle Model"];
            string wheelsManufacturer = i_VehicleSpecs["Wheels Manufacturer"];
            int numOfWheels = getNumOfWheels(i_VehicleSpecs["Wheels Count"], 16);
            float wheelsMaxTirePressure = getMaxTirePressure(i_VehicleSpecs["Wheels Max Tire Pressure"], 26);
            float wheelsCurrentTirePressure = getCurrentTirePressure(i_VehicleSpecs["Wheels Current Tire Pressure"], wheelsMaxTirePressure);

            bool isTransportingHazardousMaterials = getIsTransportingHazardousMaterials(i_VehicleSpecs["Is Transporting Hazardous Materials?"]);
            float payloadCapacity = getPayLoadCapacity(i_VehicleSpecs["Payload Capacity"]);
            GasEngine.eGasType gasType = getGasType(i_VehicleSpecs["Gas Type"]);
            float gasCapacity = getCapacity(i_VehicleSpecs["Gas Capacity"], 120);
            float gasGauge = getCurrentChargeOrGauge(i_VehicleSpecs["Gas Gauge"], gasCapacity);
            GasEngine engine = new GasEngine(gasType, gasGauge, gasCapacity);

            Wheel[] arrayOfWheels = getArrayOfWheels(wheelsManufacturer, wheelsCurrentTirePressure, wheelsMaxTirePressure,
                numOfWheels);
            Truck resultTruck = new Truck(arrayOfWheels, engine,vehicleModel,i_LicensePlateNumber,isTransportingHazardousMaterials,payloadCapacity);
            return resultTruck;
        }

        private static Wheel[] getArrayOfWheels(string i_WheelsManufacturer, float i_WheelsCurrentTirePressure,
            float i_WheelsMaxTirePressure, int i_NumOfWheels)
        {
            Wheel[] wheels = new Wheel[i_NumOfWheels];
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                wheels[i] = new Wheel(i_WheelsManufacturer, i_WheelsCurrentTirePressure, i_WheelsMaxTirePressure);
            }

            return wheels;
        }

        private static Vehicle createBike(Dictionary<string, string> i_VehicleSpecs, string i_LicensePlateNumber,
            int i_TypeOfBike)
        {
            string vehicleModel = i_VehicleSpecs["Vehicle Model"];
            Bike.eLicenseType licenseType = getLicenceType(i_VehicleSpecs["License Type"]);
            string wheelsManufacturer = i_VehicleSpecs["Wheels Manufacturer"];
            int numOfWheels = getNumOfWheels(i_VehicleSpecs["Wheels Count"], 2);
            float wheelsMaxTirePressure = getMaxTirePressure(i_VehicleSpecs["Wheels Max Tire Pressure"], 30);
            float wheelsCurrentTirePressure = getCurrentTirePressure(i_VehicleSpecs["Wheels Current Tire Pressure"], wheelsMaxTirePressure);
            int engineVolume = getEngineVolume(i_VehicleSpecs["Engine Volume"]);
            Engine engine = null;
            if (i_TypeOfBike == 0)
            {
                GasEngine.eGasType gasType = getGasType(i_VehicleSpecs["Gas Type"]);
                float gasCapacity = getCapacity(i_VehicleSpecs["Gas Capacity"], 6);
                float gasGauge = getCurrentChargeOrGauge(i_VehicleSpecs["Gas Gauge"], gasCapacity);
                engine = new GasEngine(gasType, gasGauge, gasCapacity);
            }
            else if (i_TypeOfBike == 1)
            {
                float batteryCapacity = getCapacity(i_VehicleSpecs["Battery Capacity"], 1.8f);
                float batteryCharge = getCurrentChargeOrGauge(i_VehicleSpecs["Battery Charge"], batteryCapacity);
                engine = new ElectricEngine(batteryCharge, batteryCapacity);
            }

            Wheel[] arrayOfWheels = getArrayOfWheels(wheelsManufacturer, wheelsCurrentTirePressure,
                wheelsMaxTirePressure, numOfWheels);

            Bike resultBike = new Bike(licenseType, engineVolume, arrayOfWheels, engine, vehicleModel, i_LicensePlateNumber);

            return resultBike;

        }
    }
}
