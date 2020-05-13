using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_NumberOfWheels = 12;
        private bool m_IsLTransportDangerousMaterials;
        private float m_VolumeOfCargo;

        public Truck(string i_ModelName, string i_LicensePlate, string i_ManufacturerName, float i_CurrentAirPressure, float i_CurrentEnergyAmount) : base(i_ModelName, i_LicensePlate, EngineType.eEnergySource.Fuel)
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_ManufacturerName, (float)Wheel.eMaxAirPressure.Truck, i_CurrentAirPressure));
            }

            SetEnergy(i_CurrentEnergyAmount);
        }

        public float VolumeOfCargo
        {
            get { return m_VolumeOfCargo; }
            set { m_VolumeOfCargo = value; }
        }

        public bool IsLTransportDangerousMaterials
        {
            get { return m_IsLTransportDangerousMaterials; }
            set { m_IsLTransportDangerousMaterials = value; }
        }

        public override void SetEnergy(float i_CurrentEnergyAmount)
        {
            EnergySource.MaxEnergy = (float)Fuel.eFuelTankCapacity.Truck;
            ((Fuel)EnergySource).FuelType = Fuel.eFuelType.Soler;
            EnergySource.FillEnergy(i_CurrentEnergyAmount);
            CalculateEnergyPercent();
        }

        public override string ToString()
        {
            string truckInfo;
            truckInfo = string.Format("{0}" + Environment.NewLine + "Is transport dangerous materials : {1}" + Environment.NewLine + "Volume of cargo: {2}", VehicleData(), m_IsLTransportDangerousMaterials.ToString(), m_VolumeOfCargo);
            return truckInfo;
        }
    }
}
