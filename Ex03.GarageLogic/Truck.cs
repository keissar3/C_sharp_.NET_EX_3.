using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        private bool m_IsTransportingHazardousMaterials;
        private float m_PayloadCapacity;

        public Truck(Wheel[] i_Wheels, Engine i_Engine,
            string i_ModelName, string i_LicensePlateNumber, bool i_IsTransportingHazardousMaterials,
            float i_PayloadCapacity)
        {
            Wheels = i_Wheels;
            Engine = i_Engine;
            ModelName = i_ModelName;
            LicensePlateNumber = i_LicensePlateNumber;
            m_IsTransportingHazardousMaterials = i_IsTransportingHazardousMaterials;
            m_PayloadCapacity = i_PayloadCapacity;
            WheelCount = 16;
        }



    }
}
