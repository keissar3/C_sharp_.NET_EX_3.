namespace Ex03.GarageLogic
{
    using System;

    public class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException(string i_Message) : base(i_Message)
        {
        }
    }
}
