using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        string m_ModelName;
        string m_LicensePlateNumber;
        float m_Energy;
        Wheel[] m_Wheels;
        Engine m_Engine;

        public string LicensePlateNumber
        {
            get
            {
                return LicensePlateNumber;
            }
            set
            {
                m_LicensePlateNumber = value;
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                m_ModelName = value;
            }
        }
        public float Energy
        {
            get
            {
                return m_Energy;
            }
            set
            {
                m_Energy = value;
            }
        }
    }
}
