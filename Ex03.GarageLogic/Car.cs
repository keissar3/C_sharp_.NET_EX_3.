using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        public enum eColor
        {
            Red,
            Silver,
            White,
            Black
        }

        public enum eDoorCount
        {
            _2 = 2,
            _3 = 3,
            _4 = 4,
            _5 = 5,
        }


        private eColor m_Color;
        private eDoorCount m_DoorCount;

        public Car(Wheel[] i_Wheels, Engine i_Engine, string i_ModelName, string i_LicensePlateNumber, eColor i_Color, eDoorCount i_DoorCount)
        {
            Wheels = i_Wheels;
            Engine = i_Engine;
            ModelName = i_ModelName;
            LicensePlateNumber = i_LicensePlateNumber;
            m_Color = i_Color;
            m_DoorCount = i_DoorCount;
            WheelCount = 4;
        }

    }
}
