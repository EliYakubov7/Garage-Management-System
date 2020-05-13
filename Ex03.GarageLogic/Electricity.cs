using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Electricity : EngineType
    {
        public override string ToString()
        {
            string message;
            message = string.Format("Battery Maximum capacity: {0}h" + Environment.NewLine + "Current battery capacity: {1:0.00}h", MaxEnergy, CurrentEnergy);
            return message;
        }

        public override void FillEnergy(float i_EnergyAmount)
        {
            if (this.CurrentEnergy + (i_EnergyAmount / 60) > this.MaxEnergy || this.CurrentEnergy + (i_EnergyAmount / 60) < 0)
            {
                throw new ValueOutOfRangeExeption(0, this.MaxEnergy);
            }
            else
            {
                this.CurrentEnergy += i_EnergyAmount / 60;
            }
        }
    }
}
