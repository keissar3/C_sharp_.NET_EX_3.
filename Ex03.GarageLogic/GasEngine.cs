using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class GasEngine : Engine
    {
        public enum eGasType
        {
            Octan98 = 1,
            Octan95,
            Soler
        };

        private eGasType m_GasType;
        private float m_GasGauge;
        private float m_GasCapacity;

        public GasEngine(eGasType i_GasType, float i_GasGauge, float i_GasCapacity)
        {
            m_GasType = i_GasType;
            m_GasGauge = i_GasGauge;
            m_GasCapacity = i_GasCapacity;
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
    }
}
