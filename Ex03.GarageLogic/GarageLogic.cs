using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
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
