using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CreateVehicles
    {
        public enum eVehiclesType
        {
            Car = 1,
            Motorcycle,
            Truck,
        }
        
        public static Vehicle CreateVehicle(string i_LicensePlate, string i_ModelName, string i_WheelManufacturer, EngineType.eEnergySource i_EnergySource, eVehiclesType i_VehiclesType, float i_CurrentAirPressure, float i_CurrentEnergyAmount)
        {
            Vehicle newVehicle = null;
            switch (i_VehiclesType)
            {
                case eVehiclesType.Car:
                    newVehicle = new Car(i_ModelName, i_LicensePlate, i_EnergySource, i_WheelManufacturer, i_CurrentAirPressure, i_CurrentEnergyAmount);
                    break;
                case eVehiclesType.Motorcycle:
                    newVehicle = new Motorcycle(i_ModelName, i_LicensePlate, i_EnergySource, i_WheelManufacturer, i_CurrentAirPressure, i_CurrentEnergyAmount);
                    break;
                case eVehiclesType.Truck:
                    newVehicle = new Truck(i_ModelName, i_LicensePlate, i_WheelManufacturer, i_CurrentAirPressure, i_CurrentEnergyAmount);
                    break; 
            }

            return newVehicle;
        }
    }
}
