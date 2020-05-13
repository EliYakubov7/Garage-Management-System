using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ManageGarage
    {
        private Dictionary<string, AutomobileRepairShop> m_ManageGarageDictionary = new Dictionary<string, AutomobileRepairShop>();

        public Dictionary<string, AutomobileRepairShop> ManageGarageDictionary
        {
            get
            {
                return m_ManageGarageDictionary;
            }
        }

        public void UpdateStatus(string i_LicensePlate, AutomobileRepairShop.eVehicleStatus i_Status)
        {
            m_ManageGarageDictionary[i_LicensePlate].VehicleStatus = i_Status;
        }

        public void AddNewVhicle(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_NewVehicale)
        {
            AutomobileRepairShop newVehicle = new AutomobileRepairShop(i_OwnerName, i_OwnerPhoneNumber, i_NewVehicale);
            m_ManageGarageDictionary.Add(i_NewVehicale.LicensePlate, newVehicle);
        }

        public bool CheckIfVhicleAlredyExist(string i_LicensePlate)
        {
            bool returnValue = true;
            if (!m_ManageGarageDictionary.ContainsKey(i_LicensePlate))
            {
                returnValue = false;
            }

            return returnValue;
        }
    }
}
