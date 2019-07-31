namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Motorcycle : Vehicle
    {
        private const int k_NumOfParams = 7;
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;
        
        public Motorcycle(
            string i_LicenseNumber,
            string i_ModelName,
            VehicleEnergySource i_EnergyManager,
            Wheel[] i_Weels) : base(i_LicenseNumber, i_ModelName, i_EnergyManager, i_Weels)
        {
        }

        internal enum eLicenseType
        {
            A,
            A1,
            A2,
            B
        }

        internal eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        internal int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            set
            {
                m_EngineCapacity = value;
            }
        }

        public override string GetVehicleParamsNeeds()
        {
            string whatINeedMsg, wheelsNeedsMsg, energyNeedsMsg;
            energyNeedsMsg = EnergySource.GetEnergySourceParamsNeeds();
            wheelsNeedsMsg = "2 wheels information: Model name, current amount of air";

            whatINeedMsg = string.Format(
@"License type
Engine capacity
{0}
{1}",
energyNeedsMsg,
wheelsNeedsMsg);

            return whatINeedMsg;
        }

        public override void SetMyValues(string i_LicenseType, string i_EngineCapacity)
        {
            if (Enum.IsDefined(typeof(eLicenseType), i_LicenseType))
            {
                m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_LicenseType);
            }
            else
            {
                throw new FormatException("Invalid license type choise.");
            }

            if (!int.TryParse(i_EngineCapacity, out m_EngineCapacity))
            {
                throw new FormatException("Invalid engine capacity value type.");
            }
        }

        public override int GetHowManyParams()
        {
            return k_NumOfParams;
        }

        public override string ToString()
        {
            string motorcycleData = string.Format(
@"{0}
License type: {1}
Engine capacity: {2}",
base.ToString(),
m_LicenseType,
m_EngineCapacity);

            return motorcycleData;
        }
    }
}
