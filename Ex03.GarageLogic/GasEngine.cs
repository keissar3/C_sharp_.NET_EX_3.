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
            Octan96,
            Octan95,
            Octan98,
        }

        private eGasType m_GasType;
        private float m_GasGauge;
        private float m_GasCapacity;

        public void FillUpGas(float i_GasLiters, eGasType i_GasType)
        {
            if (m_GasType != i_GasType)
            {
                throw new ArgumentException("Wrong Gas Type"))
            }

            if (m_GasGauge + i_GasLiters > m_GasCapacity)
            {
                throw new ValueOutOfRangeException("Too much gas, can't fuel so much!");
            }

            m_GasGauge += i_GasLiters;
        }
    }
}
