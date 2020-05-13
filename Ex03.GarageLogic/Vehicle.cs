using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly EngineType m_EnergySource;
        private readonly string m_VehicleModelName;
        private readonly string m_LicensePlate;
        // $G$ NTT-999 (-5) This kind of field should be readonly.
        private List<Wheel> m_Wheels = new List<Wheel>();
        private float m_EnergyPercent; 

        public Vehicle(string i_CarModelName, string i_LicensePlate, EngineType.eEnergySource i_EnergySource)
        {
            m_VehicleModelName = i_CarModelName;
            m_LicensePlate = i_LicensePlate;
            if (i_EnergySource == EngineType.eEnergySource.Fuel)
            {
                m_EnergySource = new Fuel();
            }
            else
            {
                m_EnergySource = new Electricity();
            }
        }

        public List<Wheel> Wheels
        {
            get { return m_Wheels; }
            set { m_Wheels = value; }
        }

        public string LicensePlate
        {
            get
            {
                return m_LicensePlate;
            }
        }

        public string CarModelName
        {
            get
            {
                return m_VehicleModelName;
            }
        }

        public float EnergyPercent
        {
            get { return m_EnergyPercent; }
            set { m_EnergyPercent = value; }
        }

        public void CalculateEnergyPercent()
        {
            float calculatedEnergyPercent = EnergySource.CurrentEnergy / EnergySource.MaxEnergy;
            EnergyPercent = calculatedEnergyPercent;
        }

        public EngineType EnergySource
        {
            get
            {
                return m_EnergySource;
            }         
        }

        public abstract void SetEnergy(float i_CurrentEnergyAmount);

        public string VehicleData()
        {
            CalculateEnergyPercent();
            string vehicleData = string.Format("Vehicle model name: {0}" + Environment.NewLine + "Vehicle license plate number: {1}" + Environment.NewLine + "Energy percentage: {2:0.00}" + Environment.NewLine + "{3}" + Environment.NewLine + "{4}", m_VehicleModelName, m_LicensePlate, EnergyPercent, m_Wheels[0].ToString(), m_EnergySource.ToString());
            return vehicleData;
        }
    }
}
