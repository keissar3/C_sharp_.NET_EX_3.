using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private float m_BatteryCharge;
        private float m_BatteryCapacity;

        public float BatteryCharge
        {
            get
            {
                return m_BatteryCharge;
            }
            set
            {
                m_BatteryCharge = value;
            }
        }

        public float BatteryCapacity
        {
            get
            {
                return m_BatteryCapacity;
            }
            set
            {
                m_BatteryCapacity = value;
            }
        }
        
        public ElectricEngine(float i_BatteryCharge, float i_BatteryCapacity)
        {
            m_BatteryCharge = i_BatteryCharge;
            m_BatteryCapacity = i_BatteryCapacity;
        }

        public void ChargeBattery(float i_HoursToCharge)
        {
            if (m_BatteryCharge + i_HoursToCharge > m_BatteryCapacity)
            {
                throw new ValueOutOfRangeException("Too much power, can't charge so much!");
            }
            m_BatteryCharge += i_HoursToCharge;
        }

        public override string ToString()
        {
            StringBuilder engineDescription = new StringBuilder();
            engineDescription.AppendFormat("Battery charge:   {0} {1}", m_BatteryCharge, Environment.NewLine);
            engineDescription.AppendFormat("Battery Capacity: {0} {1}", m_BatteryCapacity, Environment.NewLine);
            return engineDescription.ToString();
        }
    }
}
