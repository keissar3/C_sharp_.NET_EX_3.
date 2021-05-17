namespace Ex03.GarageLogic
{
    using System;
    using System.Text;
    public class Record
    {
        public enum eVehicleStatus
        {
            inRepair,
            isFixed,
            isPaidUp
        }
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private Vehicle m_Vehicle;
        private eVehicleStatus m_VehicleStatus;

        public Record(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_Vehicle = i_Vehicle;
            m_VehicleStatus = eVehicleStatus.inRepair;
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
            set
            {
                m_OwnerName = value;
            }
        }
        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }
            set
            {
                m_OwnerPhoneNumber = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }

        public override string ToString()
        {
            StringBuilder recordDescription = new StringBuilder();
            recordDescription.AppendLine("--Garage Customer Report--");
            recordDescription.AppendFormat("Owner name:         {0} {1}", m_OwnerName, Environment.NewLine);
            recordDescription.AppendFormat("Owner phone number: {0} {1}", m_OwnerPhoneNumber, Environment.NewLine);
            recordDescription.AppendFormat("Vehicle status:     {0} {1}", m_VehicleStatus.ToString(), Environment.NewLine);
            return recordDescription + m_Vehicle.ToString();
        }
    }
}
