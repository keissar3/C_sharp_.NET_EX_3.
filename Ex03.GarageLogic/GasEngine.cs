namespace Ex03.GarageLogic
{
    using System;
    using System.Text;

    public class GasEngine : Engine
    {
        private eGasType m_GasType;
        private float m_GasGauge;
        private float m_GasCapacity;

        public GasEngine(eGasType i_GasType, float i_GasCapacity)
        {
            m_GasType = i_GasType;
            m_GasCapacity = i_GasCapacity;
        }

        public eGasType GasType
        {
            get
            {
                return m_GasType;
            }

            set
            {
                m_GasType = value;
            }
        }

        public float GasGague
        {
            get
            {
                return m_GasGauge;
            }

            set
            {
                if (value <= m_GasCapacity)
                {
                    m_GasGauge = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(string.Format("The Gas Gauge need to be less than {0}", m_GasCapacity));
                }
            }
        }

        public float GasCapacity
        {
            get
            {
                return m_GasCapacity;
            }

            set
            {
                m_GasCapacity = value;
            }
        }

        public void FillUpGas(float i_GasLiters, eGasType i_GasType)
        {
            if (m_GasType != i_GasType)
            {
                throw new ArgumentException("Wrong Gas Type");
            }

            if (m_GasGauge + i_GasLiters > m_GasCapacity)
            {
                throw new ValueOutOfRangeException("Too much gas, can't fuel so much!");
            }

            m_GasGauge += i_GasLiters;
        }

        public override string ToString()
        {
            StringBuilder engineDescription = new StringBuilder();
            engineDescription.AppendFormat("Gas type:     {0} {1}", m_GasType, Environment.NewLine);
            engineDescription.AppendFormat("Gas gauge:    {0} {1}", m_GasGauge, Environment.NewLine);
            engineDescription.AppendFormat("Gas capacity: {0} {1}", m_GasCapacity, Environment.NewLine);

            return engineDescription.ToString();
        }
    }
}
