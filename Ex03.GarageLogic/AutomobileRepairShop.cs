using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class AutomobileRepairShop
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_NewVehicle;

        public AutomobileRepairShop(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_NewVehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_NewVehicle = i_NewVehicle;
            m_VehicleStatus = eVehicleStatus.InRepair;
        }

        public enum eVehicleStatus
        {
            InRepair = 1,
            Repaired,
            Paied,
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
            set { m_OwnerPhoneNumber = value; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public override string ToString()
        {
            string message;
            message = string.Format("Owner name: {0}" + Environment.NewLine + "Owner phone number: {1}" + Environment.NewLine + "vehicle status: {2}" + Environment.NewLine + "{3}", m_OwnerName, m_OwnerPhoneNumber, m_VehicleStatus.ToString(), m_NewVehicle.ToString());
            
            return message.ToString();
        }

        public Vehicle newVehicle
        {
            get
            {
                return m_NewVehicle;
            }
        }
    }
}
