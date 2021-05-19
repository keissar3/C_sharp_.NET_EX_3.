namespace Ex03.GarageLogic
{
    using System.Collections.Generic;
    public class GarageLogic
    {
        private List<Record> m_Records = new List<Record>();

        public void AddVehicleToGarageRecords(Record i_Record)
        {
            m_Records.Add(i_Record);
        }

        public bool CheckIfVehicleIsExists(string i_LicensePlateNumber)
        {
            bool isFound = false;
            foreach (var record in m_Records)
            {
                if (record.Vehicle.LicensePlateNumber == i_LicensePlateNumber)
                {
                    isFound = true;
                }
            }

            return isFound;
        }

        public Vehicle GetVehicleByLicensePlate(string i_LicensePlateNumber)
        {
            Vehicle carToReturn = null;
            foreach (var record in m_Records)
            {
                if (record.Vehicle.LicensePlateNumber == i_LicensePlateNumber)
                {
                    carToReturn = record.Vehicle;
                }
            }

            return carToReturn;
        }

        public Record GetRecordByLicensePlate(string i_LicensePlateNumber)
        {
            Record recordToReturn = null;
            foreach (var record in m_Records)
            {
                if (record.Vehicle.LicensePlateNumber == i_LicensePlateNumber)
                {
                    recordToReturn = record;
                }
            }

            return recordToReturn;
        }

        public List<Record> GetListAccordingToStatus(Record.eVehicleStatus i_Status,ref string io_Meesage)
        {
            List<Record> listToReturn = new List<Record>();
            foreach (Record record in m_Records)
            {
                if (record.VehicleStatus == i_Status)
                {
                    listToReturn.Add(record);
                }
            }

            if (listToReturn.Count == 0)
            {
                io_Meesage = "There is no vehicle in this status.";
            }
            else
            {
                io_Meesage = string.Format("The vehicle that their status is {0} are:", i_Status.ToString());
            }
            return listToReturn;
        }

        public List<Record> Records
        {
            get
            {
                return m_Records;
            }
        }

        public void SetStatusInVehicle(string i_LicensePlateNumber, Record.eVehicleStatus i_Status)
        {
            foreach (var record in m_Records)
            {
                if (record.Vehicle.LicensePlateNumber == i_LicensePlateNumber)
                {
                    record.VehicleStatus = i_Status;
                }
            }
        }
    }
}
