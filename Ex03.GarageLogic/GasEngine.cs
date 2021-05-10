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

        FillUpGas(float i_GasLiters, eGasType i_GasType);
    }
}
