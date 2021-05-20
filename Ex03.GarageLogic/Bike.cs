namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Bike : Vehicle
    {
        internal enum eLicenseType
        {
            A = 1,
            B1,
            AA,
            BB,
        }

        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public Bike(eTypeOfEngine i_TypeOfEngine, string i_LicensePlateNumber)
        {
            Engine engine = null;
            switch (i_TypeOfEngine)
            {
                case eTypeOfEngine.Gas:
                    engine = new GasEngine(eGasType.Octan98, 6);
                    break;
                case eTypeOfEngine.Electric:
                    engine = new ElectricEngine(1.8f);
                    break;
            }

            LicensePlateNumber = i_LicensePlateNumber;
            Engine = engine;
            WheelCount = 2;
            Wheels = Wheel.CreateWheelsArray(30, WheelCount);
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }

            set
            {
                m_EngineVolume = value;
            }
        }

        internal eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        public override void SetProperties(string i_Property, string i_Value)
        {
            switch (i_Property)
            {
                case "Vehicle Model":
                    ModelName = (string)i_Value;
                    break;
                case "License Type":
                    LicenseType = CheckLicenseType((string)i_Value);
                    break;
                case "Wheels Manufacturer":
                    Wheel.SetWheelsManufacturer(Wheels, WheelCount, (string)i_Value);
                    break;
                case "Wheels Current Tire Pressure":
                    float currentTirePressure = ParsingHelper.ParseToIntAndThrowProvidedMessage((string)i_Value, "Wheels Current Tire Pressure must be a number");
                    Wheel.SetWheelsCurrentTirePressure(Wheels, WheelCount, currentTirePressure);
                    break;
                case "Engine Volume":
                    int engineVolume = ParsingHelper.ParseToIntAndThrowProvidedMessage((string)i_Value, "Engine volume must be a number.");
                    EngineVolume = engineVolume;
                    break;
                case "Gas Gauge":
                    float gasGauge = ParsingHelper.ParseToFloatAndThrowProvidedMessage((string)i_Value, "Gas gauge must be a number.");
                    GasEngine GasEngine = Engine as GasEngine;
                    GasEngine.GasGague = gasGauge;
                    break;
                case "Battery Charge":
                    float batteryCharge = ParsingHelper.ParseToFloatAndThrowProvidedMessage((string)i_Value, "Battery charge must be a number.");
                    ElectricEngine electricEngine = Engine as ElectricEngine;
                    electricEngine.BatteryCharge = batteryCharge;
                    break;
            }
        }

        public override string ToString()
        {
            string vehicleDescription = base.ToString();
            StringBuilder bikeDescription = new StringBuilder();
            bikeDescription.AppendFormat("License type:  {0} {1}", m_LicenseType, Environment.NewLine);
            bikeDescription.AppendFormat("Engine volume: {0} {1}", m_EngineVolume, Environment.NewLine);
            vehicleDescription += bikeDescription.ToString();
            return vehicleDescription;
        }

        public override List<string> GetsSpecs()
        {
            List<string> specsList = new List<string>();
            specsList.Add("Vehicle Model");
            specsList.Add("License Type");
            specsList.Add("Wheels Manufacturer");
            specsList.Add("Wheels Current Tire Pressure");
            specsList.Add("Engine Volume");

            if (Engine is GasEngine)
            {
                specsList.Add("Gas Gauge");
            }
            else if (Engine is ElectricEngine)
            {
                specsList.Add("Battery Charge");
            }

            return specsList;
        }

        private Bike.eLicenseType CheckLicenseType(string i_LicenseType)
        {
            Bike.eLicenseType licenseType;
            switch (i_LicenseType)
            {
                case "A":
                    licenseType = Bike.eLicenseType.A;
                    break;
                case "B1":
                    licenseType = Bike.eLicenseType.B1;
                    break;
                case "AA":
                    licenseType = Bike.eLicenseType.AA;
                    break;
                case "BB":
                    licenseType = Bike.eLicenseType.BB;
                    break;
                default:
                    throw new ValueOutOfRangeException(@"The licenses type we support is only: 
A
B1
AA
BB");
            }

            return licenseType;
        }
    }
}