using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        private const float k_FullBatteryCapacity = 1.4f;
        private int m_EngineCapacity;
        private eLicenseType m_LicenseType;

        public Motorcycle(string i_ModelName, string i_LicensePlate, EngineType.eEnergySource i_EnergySource, string i_WheelManufacturerName, float i_CurrentAirPressure, float i_CurrentEnergyAmount) : base(i_ModelName, i_LicensePlate, i_EnergySource)
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_WheelManufacturerName, (float)Wheel.eMaxAirPressure.Motorcycle, i_CurrentAirPressure));
            }

            SetEnergy(i_CurrentEnergyAmount);
        }

       public enum eLicenseType
        {
            A = 1,
            A1,
            A2,
            B
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineCapacity
        {
            get { return m_EngineCapacity; }
            set { m_EngineCapacity = value; }
        }

        public override void SetEnergy(float i_CurrentEnergyAmount)
        {
            if (EnergySource is Fuel)
            {
                EnergySource.MaxEnergy = (float)Fuel.eFuelTankCapacity.Motorcycle;
                ((Fuel)EnergySource).FuelType = Fuel.eFuelType.Octan95;
                EnergySource.FillEnergy(i_CurrentEnergyAmount);
            }
            else
            {
                EnergySource.MaxEnergy = k_FullBatteryCapacity;
                EnergySource.FillEnergy(i_CurrentEnergyAmount / 60);
            }

            CalculateEnergyPercent();
        }

        public override string ToString()
        {
            string motorcucleInfo;
            motorcucleInfo = string.Format("{0}" + Environment.NewLine + "Engine capacity: {1}" + Environment.NewLine + "License type: {2}", VehicleData(), m_EngineCapacity, m_LicenseType.ToString());
            return motorcucleInfo;
        }
    }
}
