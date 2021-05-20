using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    using System;
    using System.Text;

    class Truck : Vehicle
    {
        private bool m_IsTransportingHazardousMaterials;
        private float m_PayloadCapacity;

        public Truck(string i_LicensePlateNumber)
        {
            Engine = new GasEngine(eGasType.Soler, 120);
            LicensePlateNumber = i_LicensePlateNumber;

            WheelCount = 16;
            Wheels = Wheel.CreateWheelsArray(26, WheelCount);
        }

        public override void SetProperties(string i_Property, string i_Value)
        {
            switch (i_Property)
            {
                case "Vehicle Model":
                    ModelName = i_Value; 
                    break;
                case "Wheels Manufacturer":
                    Wheel.SetWheelsManufacturer(Wheels, WheelCount, i_Value);
                    break;
                case "Wheels Current Tire Pressure":
                    float currentTirePressure = ParsingHelper.ParseToFloatAndThrowProvidedMessage(i_Value, "Wheels Current Tire Pressure must be a number");
                    Wheel.SetWheelsCurrentTirePressure(Wheels, WheelCount, currentTirePressure);
                    break;
                case "Is Transporting Hazardous Materials?":
                    m_IsTransportingHazardousMaterials = checkIsTransportingHazardousMaterials(i_Value);
                    break;
                case "Payload Capacity":
                    m_PayloadCapacity = ParsingHelper.ParseToFloatAndThrowProvidedMessage(i_Value, "The payload capacity must be a number.");
                    break;
                case "Gas Gauge":
                    float gasGauge = ParsingHelper.ParseToFloatAndThrowProvidedMessage(i_Value, "Gas gauge must be a number.");
                    GasEngine GasEngine = Engine as GasEngine;
                    GasEngine.GasGague = gasGauge;
                    break;
            }
        }

        private bool checkIsTransportingHazardousMaterials(string i_IsTransportingHazardousMaterials)
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

        public override List<string> GetsSpecs()
        {
            List<string> specsList = new List<string>();

            specsList.Add("Vehicle Model");
            specsList.Add("Wheels Manufacturer");
            specsList.Add("Wheels Current Tire Pressure");
            specsList.Add("Gas Gauge");
            specsList.Add("Is Transporting Hazardous Materials?");
            specsList.Add("Payload Capacity");
            return specsList;
        }

        public override string ToString()
        {
            string vehicleDescription = base.ToString();
            StringBuilder truckDescription = new StringBuilder();
            string hazardousHazardousMaterials = m_IsTransportingHazardousMaterials == true ? "yes" : "no";
            truckDescription.AppendFormat("Transport hazardous materials:{0} {1}", hazardousHazardousMaterials, Environment.NewLine);
            truckDescription.AppendFormat("Engine volume:                 {0} {1}", m_PayloadCapacity, Environment.NewLine);

            vehicleDescription += truckDescription.ToString();
            return vehicleDescription;
        }
    }
}
