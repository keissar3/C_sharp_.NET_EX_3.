using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Bike : Vehicle
    {
        public enum eLicenseType
        {
            A,
            B1,
            AA,
            BB,
        }

        private eLicenseType m_LicenseType;
        private int m_EngineVolume;
    }
}
