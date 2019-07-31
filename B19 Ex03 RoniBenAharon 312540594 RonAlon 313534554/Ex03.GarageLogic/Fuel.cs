namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Fuel : VehicleEnergySource
    {
        private readonly eFuelType r_FuelType;

        public enum eFuelType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4
        }

        public Fuel(eFuelType i_FuelType, float i_MaxAmoutOfFuel) : base(i_MaxAmoutOfFuel)
        {
            r_FuelType = i_FuelType;
        }

        internal eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public override string GetEnergySourceParamsNeeds()
        {
            string msg = "Current amount of fuel";
            return msg;
        }

        public override string ToString()
        {
            string fuelData = string.Format(
@"Fuel Type: {0}
Current amount of fuel: {1}
Max amount of fuel: {2}",
r_FuelType.ToString(),
CurrentCapacity, 
MaxCapacity);

            return fuelData;
        }

        protected override float GetMaxValueToFill()
        {
            return MaxCapacity - CurrentCapacity;
        }
    }
}
