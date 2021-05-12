using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_Manufacturer;
        private float m_TirePressure;
        private float m_MaxTirePressure;

        public Wheel(string i_Manufacturer, float i_TirePressure, float i_MaxTirePressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_TirePressure = i_TirePressure;
            m_MaxTirePressure = i_MaxTirePressure;
        }


        public void InflateTire(float i_AirToAdd)
        {
            if (m_TirePressure + i_AirToAdd > m_MaxTirePressure)
            {
                throw new ValueOutOfRangeException("Too much air, can't inflate so much!");
            }

            m_TirePressure += i_AirToAdd;
        }
    }

}
