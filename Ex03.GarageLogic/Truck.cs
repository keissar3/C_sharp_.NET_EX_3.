namespace Ex03.GarageLogic
{
    using System;
    using System.Text;
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

        public override string ToString()
        {
            string vehicleDescription = base.ToString();
            StringBuilder truckDescription = new StringBuilder();
            string hazardousHazardousMaterials = m_IsTransportingHazardousMaterials == true ? "yes" : "no";
            truckDescription.AppendFormat("Transport hazardous materials:{0} {1}", hazardousHazardousMaterials, Environment.NewLine);
            truckDescription.AppendFormat("Engine volume:                 {0} {1}", m_PayloadCapacity, Environment.NewLine);

            vehicleDescription += truckDescription.ToString();
            return vehicleDescription;
        }
    }
}
