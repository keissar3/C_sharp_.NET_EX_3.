using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        string m_ModelName;
        string m_LicensePlateNumber;
      //  float m_Energy; //TODO need to decide whether to keep it or not 
        Wheel[] m_Wheels;
        Engine m_Engine; 
        int m_WheelsCount;

        
        public  string  LicensePlateNumber
        {
            get
            {
                return m_LicensePlateNumber;
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

        public int WheelCount
        {
            get
            {
                return m_WheelsCount;
            }
            set
            {
                m_WheelsCount = value;
            }
        }
        //public float Energy
        //{
        //    get
        //    {
        //        return m_Energy;
        //    }
        //    set
        //    {
        //        m_Energy = value;
        //    }
        //}

        public Wheel[] Wheels
        {
            get
            {
                return m_Wheels;
            }
            set
            {
                m_Wheels = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
            set
            {
                m_Engine = value;
            }
        }
    }
}
