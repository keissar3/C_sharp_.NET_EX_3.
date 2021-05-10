using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
