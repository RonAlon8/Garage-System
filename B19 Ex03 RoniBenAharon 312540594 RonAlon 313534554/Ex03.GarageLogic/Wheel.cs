namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Wheel : Fillable
    {
        private string m_ManufacturerName;
        
        public Wheel(float i_MaxAirPressure) : base(i_MaxAirPressure)
        {
        }

        internal void SetWheelValues(string i_ManufacturerName, string i_CurrentAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;

            SetCurrentValues(i_CurrentAirPressure);
        }

        public override string ToString()
        {
            string wheelData = string.Format(
@"Manufacturer name: {0}
Current air pressure: {1}
Max air pressure: {2}",
m_ManufacturerName, 
CurrentCapacity,
MaxCapacity);

            return wheelData;
        }
    }
}
