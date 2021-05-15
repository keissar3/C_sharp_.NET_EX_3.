using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Bike : Vehicle
    {
        public enum eLicenseType
        {
            A = 1,
            B1,
            AA,
            BB,
        }

        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public Bike(eLicenseType i_LicenseType, int i_EngineVolume, Wheel[] i_Wheels, Engine i_Engine,
            string i_ModelName, string i_LicensePlateNumber)
        {
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
            Wheels = i_Wheels;
            Engine = i_Engine;
            ModelName = i_ModelName;
            LicensePlateNumber = i_LicensePlateNumber;
            WheelCount = 2;

        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
            set
            {
                m_EngineVolume = value;
            }

        }


    }


}