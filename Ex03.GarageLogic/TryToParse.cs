using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class TryToParse
        {
            public static int Int(string i_stringToParse, string i_MessageIfFailed)
            {
                if (int.TryParse(i_stringToParse, out int result) == false)
                {
                    throw new FormatException(i_MessageIfFailed);
                }
                return result;
            }
            public static float Float(string i_StringToParse, string i_MessageIfFailed)
            {
                if (float.TryParse(i_StringToParse, out float result) == false)
                {
                    throw new FormatException(i_MessageIfFailed);
                }

                return result;
            }
        }

}
