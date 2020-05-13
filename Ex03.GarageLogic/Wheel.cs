using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        // $G$ NTT-999 (-5) This kind of field should be readonly.
        private string m_ManufacturerName;
        private float m_CurrentAirPressure = 0;
        private float m_MaxAirPressure;

        public Wheel(string i_ManufacturerName, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_MaxAirPressure = i_MaxAirPressure;
            FillAir(i_CurrentAirPressure);
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public float MaxtAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
        }
        
        public void FillAir(float i_AirPressure)
        {
            if(CurrentAirPressure + i_AirPressure > MaxtAirPressure || CurrentAirPressure + i_AirPressure < 0)
            {
                throw new ValueOutOfRangeExeption(0, MaxtAirPressure);
            }
            else
            {
                m_CurrentAirPressure += i_AirPressure;
            }
        }

        public enum eMaxAirPressure
        {
            Motorcycle = 33,
            Car = 31,
            Truck = 26
        }

        public override string ToString()
        {
            string wheelInfo;
            wheelInfo = string.Format("Wheel manufacturer name: {0}" + Environment.NewLine + "Current wheel air pressure: {1}" + Environment.NewLine + "Maximum wheel air pressure: {2}", m_ManufacturerName, m_CurrentAirPressure, m_MaxAirPressure);
            return wheelInfo;
        }
    }
}
