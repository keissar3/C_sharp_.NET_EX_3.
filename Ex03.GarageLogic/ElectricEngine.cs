using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricEngine : Engine
    {
        private float m_BatteryCharge;
        private float m_BatteryCapacity;

        public void ChargeBattery(float i_HoursToCharge)
        {
            if (m_BatteryCharge + i_HoursToCharge > m_BatteryCapacity)
            {
                throw new ValueOutOfRangeException("Too much power, can't charge so much!")
            }
            m_BatteryCharge += i_HoursToCharge;
        }
    }
}
