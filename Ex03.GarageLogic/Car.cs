using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const int k_NumberOfWheels = 4;
        private const float k_MaxBatteryCapacity = 1.8f;
        private eColor m_Color;
        private eNumberOfDoors m_NumberOfDoors;
        
        public Car(string i_CarModelName, string i_LicensePlate, EngineType.eEnergySource i_EnergySource, string i_WheelManufacturerName, float i_CurrentAirPressure, float i_CurrentEnergyAmount) : base(i_CarModelName, i_LicensePlate, i_EnergySource)
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheels.Add(new Wheel(i_WheelManufacturerName, (float)Wheel.eMaxAirPressure.Car, i_CurrentAirPressure));
            }

            SetEnergy(i_CurrentEnergyAmount);
        }

        public enum eColor
        {
            Red = 1,
            Blue,
            Black,
            Gray,
        }

        public enum eNumberOfDoors
        {
            Two = 1, 
            Three,
            Four,
            Five,
        }

        public eColor CarColor
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }

        public override void SetEnergy(float i_CurrentEnergyAmount)
        {
            if (EnergySource is Fuel)
            {
                EnergySource.MaxEnergy = (float)Fuel.eFuelTankCapacity.Car;
                ((Fuel)EnergySource).FuelType = Fuel.eFuelType.Octan96;
                EnergySource.FillEnergy(i_CurrentEnergyAmount);
            }
            else
            {
                EnergySource.MaxEnergy = k_MaxBatteryCapacity;
                EnergySource.FillEnergy(i_CurrentEnergyAmount / 60); 
            }

            CalculateEnergyPercent();
        }

        public override string ToString()
        {
            string carInfo;
            carInfo = string.Format("{0}" + Environment.NewLine + "Car color: {1}" + Environment.NewLine + "Car number of doors: {2}", VehicleData(), m_Color.ToString(), m_NumberOfDoors.ToString());
            return carInfo;
        }
    }
}
