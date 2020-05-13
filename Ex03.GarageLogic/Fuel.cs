using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Fuel : EngineType
    {
       private eFuelType m_FuelType;
       private eFuelTankCapacity m_FuelTankCapacity;

       public enum eFuelType
        {
            Soler = 1,
            Octan95,
            Octan96,
            Octan98,
        }

       public enum eFuelTankCapacity
        {
            Motorcycle = 8,
            Car = 55,
            Truck = 110,
        }

       public eFuelType FuelType
       {
            get { return m_FuelType; }
            set { m_FuelType = value; }
        }

       public eFuelTankCapacity FuelTankCapacity
        {
            get { return m_FuelTankCapacity; }
            set { m_FuelTankCapacity = value; }
        }

        public void CheckFuelType(eFuelType i_FuelType)
        {
            if (m_FuelType != i_FuelType)
            {
                throw new ArgumentException("user try to refuel wrong fuel type");
            }
        }

        public override string ToString()
        {
            string message;
            message = string.Format("Fuel tank Maximum capacity: {0}" + Environment.NewLine + "Current Fuel tank capacity: {1}", this.MaxEnergy, this.CurrentEnergy);
            return message;
        }

        public override void FillEnergy(float i_EnergyAmount)
        {
            if (this.CurrentEnergy + i_EnergyAmount > this.MaxEnergy || this.CurrentEnergy + i_EnergyAmount < 0)
            {
                throw new ValueOutOfRangeExeption(0, this.MaxEnergy);
            }
            else
            {
                this.CurrentEnergy += i_EnergyAmount;
            }
        }
    }
}
