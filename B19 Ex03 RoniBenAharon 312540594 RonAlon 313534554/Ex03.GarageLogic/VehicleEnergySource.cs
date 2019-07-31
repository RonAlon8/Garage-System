namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class VehicleEnergySource : Fillable
    {
        public VehicleEnergySource(float m_MaxAmoutOfEnergy) : base(m_MaxAmoutOfEnergy)
        {
        }

        internal void SetEnergyValues(string i_CurrentAmountOfEnergy)
        {
            SetCurrentValues(i_CurrentAmountOfEnergy);
        }

        public abstract string GetEnergySourceParamsNeeds();

        protected abstract override float GetMaxValueToFill();
    }
}
