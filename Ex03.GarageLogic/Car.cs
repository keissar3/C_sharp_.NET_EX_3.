namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Car : Vehicle
    {
        internal enum eColor
        {
            Red,
            Silver,
            White,
            Black
        }
        internal enum eDoorCount
        {
            _2 = 2,
            _3 = 3,
            _4 = 4,
            _5 = 5,
        }

        private eColor m_Color;
        private eDoorCount m_DoorCount;

        public eColor CarColor
        {
            get
            {
                return m_Color;
            }

            set
            {
                m_Color = value;
            }
        }

        public eDoorCount DoorCount
        {
            get
            {
                return m_DoorCount;
            }

            set
            {
                m_DoorCount = value;
            }
        }

        public override List<string> GetsSpecs()
        {
            List<string> specsList = new List<string>();
            specsList.Add("Vehicle Model");
            specsList.Add("Wheels Manufacturer");
            specsList.Add("Wheels Current Tire Pressure");
            specsList.Add("Car Color");
            specsList.Add("Doors Count");
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

        public override string ToString()
        {
            string vehicleDescription = base.ToString();
            StringBuilder carDescription = new StringBuilder();
            carDescription.AppendFormat("Door count:   {0} {1}", m_DoorCount, Environment.NewLine);
            carDescription.AppendFormat("Doors color:  {0} {1}", m_Color, Environment.NewLine);
            vehicleDescription += carDescription.ToString();
            return vehicleDescription;
        }

        public Car(eTypeOfEngine i_TypeOfEngine, string i_LicensePlateNumber)
        {

            Engine engine = null;
            switch (i_TypeOfEngine)
            {
                case eTypeOfEngine.Gas:
                    engine = new GasEngine(eGasType.Octan95, 45);
                    break;
                case eTypeOfEngine.Electric:
                    engine = new ElectricEngine(3.2f);
                    break;
            }

            Engine = engine;
            LicensePlateNumber = i_LicensePlateNumber;
            WheelCount = 4;
            Wheels = Wheel.CreateWheelsArray(32, WheelCount);
        }

        public override void SetProperties(string i_Property, string i_Value)
        {
            switch (i_Property)
            {
                case "Vehicle Model":
                    ModelName = i_Value;
                    break;
                case "Wheels Manufacturer":
                    Wheel.SetWheelsManufacturer(Wheels, WheelCount, (string)i_Value);
                    break;
                case "Wheels Current Tire Pressure":
                    float currentTirePressure = ParsingHelper.ParseToFloatAndThrowProvidedMessage((string)i_Value, "Wheels Current Tire Pressure must be a number");
                    Wheel.SetWheelsCurrentTirePressure(Wheels, WheelCount, currentTirePressure);
                    break;
                case "Car Color":
                    CarColor = CheckCarColor((string)i_Value);
                    break;
                case "Doors Count":
                    DoorCount = CheckDoorCount((string)i_Value);
                    break;
                case "Gas Gauge":
                    float gasGauge = ParsingHelper.ParseToFloatAndThrowProvidedMessage((string)i_Value, "Gas gauge must be a number.");
                    GasEngine gasEngine = Engine as GasEngine;
                    gasEngine.GasGague = gasGauge;
                    break;
                case "Battery Charge":
                    float batteryCharge = ParsingHelper.ParseToFloatAndThrowProvidedMessage((string)i_Value, "Battery charge must be a number.");
                    ElectricEngine electricEngine = Engine as ElectricEngine;
                    electricEngine.BatteryCharge = batteryCharge;
                    break;
            }
        }

        private Car.eColor CheckCarColor(string i_CarColor)
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

        private Car.eDoorCount CheckDoorCount(string i_DoorsCount)
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
    }
}