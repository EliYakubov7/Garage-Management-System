using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class EngineType
    {
        private float m_CurrentEnergy = 0;
        private float m_MaxEnergy;

        public enum eEnergySource
        {
            Fuel = 1,
            Electricity,
        }

        public float CurrentEnergy
        {
            get { return m_CurrentEnergy; }
            set
            {
                if (value > MaxEnergy)
                {
                    throw new ValueOutOfRangeExeption(0, MaxEnergy);
                }
                else
                {
                    m_CurrentEnergy = value;
                }
            }
        }

        public float MaxEnergy
        {
            get { return m_MaxEnergy; }
            set { m_MaxEnergy = value; }
        }

        public abstract void FillEnergy(float i_EnergyAmount);
    }
}
