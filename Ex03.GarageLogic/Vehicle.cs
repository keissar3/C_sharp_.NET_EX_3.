using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    using System.Text;
    using System;
    public abstract class Vehicle
    {
        string m_ModelName;
        string m_LicensePlateNumber;
        Wheel[] m_Wheels;
        Engine m_Engine;
        int m_WheelsCount;

        public abstract List<string> GetsSpecs();
        public abstract void SetProperties(string i_Property, object i_Value);
        public string LicensePlateNumber
        {
            get
            {
                return m_LicensePlateNumber;
            }
            set
            {
                m_LicensePlateNumber = value;
            }
        }
        public void InflateAllTires(float i_AirToAdd)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateTire(i_AirToAdd);
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }

        public int WheelCount
        {
            get
            {
                return m_WheelsCount;
            }
            set
            {
                m_WheelsCount = value;
            }
        }
        public float Energy
        {
            get
            {
                float energyPercentage = 0;
                if(Engine is GasEngine)
                {
                    energyPercentage = (Engine as GasEngine).GasGague / (Engine as GasEngine).GasCapacity * 100;
                }
                if (Engine is ElectricEngine)
                {
                    energyPercentage = (Engine as ElectricEngine).BatteryCharge / (Engine as ElectricEngine).BatteryCapacity * 100;
                }
                return energyPercentage;
            }
        }

        public Wheel[] Wheels
        {
            get
            {
                return m_Wheels;
            }
            set
            {
                m_Wheels = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
            set
            {
                m_Engine = value;
            }
        }

        public override string ToString()
        {

            StringBuilder vehicleDescription = new StringBuilder();
            vehicleDescription.AppendLine("Vehicle Description:");
            vehicleDescription.AppendFormat("Vehicle Type          {0} {1}", GetType().Name, Environment.NewLine);
            vehicleDescription.AppendFormat("Engine Type           {0} {1}", m_Engine.GetType().Name, Environment.NewLine);
            vehicleDescription.AppendFormat("Model:                {0} {1}", m_ModelName, Environment.NewLine);
            vehicleDescription.AppendFormat("License plate number: {0} {1}", m_LicensePlateNumber, Environment.NewLine);
            vehicleDescription.AppendFormat("Wheels count:         {0} {1}", m_WheelsCount, Environment.NewLine);
            vehicleDescription.AppendFormat("Energy left :{0:00.00}% {1}", this.Energy, Environment.NewLine);
            vehicleDescription.AppendFormat(m_Wheels[0].ToString());
            vehicleDescription.AppendFormat(m_Engine.ToString());

            return vehicleDescription.ToString();
        }
    }
}
