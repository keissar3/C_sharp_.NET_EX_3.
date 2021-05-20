namespace Ex03.GarageLogic
{
    using System;

    internal class ParsingHelper
    {
        public static int ParseToIntAndThrowProvidedMessage(string i_StringToParse, string i_MessageIfFailed)
        {
            if (int.TryParse(i_StringToParse, out int result) == false)
            {
                throw new FormatException(i_MessageIfFailed);
            }

            return result;
        }

        public static float ParseToFloatAndThrowProvidedMessage(string i_StringToParse, string i_MessageIfFailed)
        {
            if (float.TryParse(i_StringToParse, out float result) == false)
            {
                throw new FormatException(i_MessageIfFailed);
            }

            return result;
        }
    }
}
