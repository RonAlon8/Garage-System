namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Electricity : VehicleEnergySource
    {
        public Electricity(float i_MaxBatteryTime) : base(i_MaxBatteryTime)
        {
        }

        public override string GetEnergySourceParamsNeeds()
        {
            string msg = "Battery time left in hours";
            return msg;
        }

        public override string ToString()
        {
            string electricityData = string.Format(
@"Battery time left in hours: {0}
Max battery time in hours: {1}",
CurrentCapacity,
MaxCapacity);

            return electricityData;
        }

        protected override float GetMaxValueToFill()
        {
            return (MaxCapacity - CurrentCapacity) * 60;
        }
    }
}
