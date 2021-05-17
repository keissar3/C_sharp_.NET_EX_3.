using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
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

        public float CurrentTirePressure
        {
            get
            {
                return m_TirePressure;
            }
            set
            {
                m_TirePressure = value;
            }
        }

        public float MaxTirePressure
        {
            get
            {
                return m_MaxTirePressure;
            }
            set
            {
                m_MaxTirePressure = value;
            }
        }

        public void InflateTire(float i_AirToAdd)
        {
            if (m_TirePressure + i_AirToAdd > m_MaxTirePressure)
            {
                throw new ValueOutOfRangeException("Too much air, can't inflate so much!");
            }

            m_TirePressure += i_AirToAdd;
        }

        public override string ToString()
        {
            StringBuilder wheelDescription = new StringBuilder();
            wheelDescription.AppendFormat("Wheel manufacturer:    {0} {1}", m_Manufacturer, Environment.NewLine);
            wheelDescription.AppendFormat("Current tire pressure: {0} {1}", m_TirePressure, Environment.NewLine);
            wheelDescription.AppendFormat("Max tire pressure:     {0} {1}", m_MaxTirePressure, Environment.NewLine);
            return wheelDescription.ToString();
        }
    }
}
