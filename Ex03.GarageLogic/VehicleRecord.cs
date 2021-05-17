namespace Ex03.GarageLogic
{
    class VehicleRecord
    {
        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            Completed,
        }
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;
        Vehicle m_Vehicle;
    }
}
