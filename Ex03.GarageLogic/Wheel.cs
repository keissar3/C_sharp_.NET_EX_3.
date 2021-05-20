namespace Ex03.GarageLogic
{
    using System;
    using System.Text;

    public class Wheel
    {
        private string m_Manufacturer;
        private float m_TirePressure;
        private float m_MaxTirePressure;

        public Wheel(float i_MaxTirePressure)
        {
            m_MaxTirePressure = i_MaxTirePressure;
        }

        public string WheelsManufacturer
        {
            get
            {
                return m_Manufacturer;
            }

            set
            {
                m_Manufacturer = value;
            }
        }

        public float CurrentTirePressure
        {
            get
            {
                return m_TirePressure;
            }

            set
            {
                if (value <= m_MaxTirePressure)
                {
                    m_TirePressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(string.Format("The current tire pressure need to be less than {0}.", m_MaxTirePressure));
                }
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

        public static Wheel[] CreateWheelsArray(float i_MaxTirePressure, int i_WheelsCount)
        {
            Wheel[] wheelsArray = new Wheel[i_WheelsCount];
            for (int i = 0; i < i_WheelsCount; i++)
            {
                wheelsArray[i] = new Wheel(i_MaxTirePressure);
            }

            return wheelsArray;
        }

        public static void SetWheelsManufacturer(Wheel[] i_WheelsArray, int i_WheelsCount, string i_WheelManufacturer)
        {
            for (int i = 0; i < i_WheelsCount; i++)
            {
                i_WheelsArray[i].WheelsManufacturer = i_WheelManufacturer;
            }
        }

        public static void SetWheelsCurrentTirePressure(Wheel[] i_WheelsArray, int i_WheelsCount, float i_CurrentTirePressure)
        {
            for (int i = 0; i < i_WheelsCount; i++)
            {
                i_WheelsArray[i].CurrentTirePressure = i_CurrentTirePressure;
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
