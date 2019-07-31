namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    // $G$ DSN-001 (-10) There is no appropriate use of polymorphism. - this why so many parameters in the constructor
    public class Truck : Vehicle
    {
        private const int k_NumOfParams = 27;
        private bool m_IsCarryingDangerousMaterials;
        private float m_VolumeOfCargo;

        public Truck(
            string i_LicenseNumber,
            string i_ModelName,
            VehicleEnergySource i_EnergyManager,
            Wheel[] i_Weels) : base(i_LicenseNumber, i_ModelName, i_EnergyManager, i_Weels)
        {
        }

        internal bool IsCarryingDangerousMaterials
        {
            get
            {
                return m_IsCarryingDangerousMaterials;
            }

            set
            {
                m_IsCarryingDangerousMaterials = value;
            }
        }

        internal float VolumeOfCargo
        {
            get
            {
                return m_VolumeOfCargo;
            }

            set
            {
                m_VolumeOfCargo = value;
            }
        }

        public override string GetVehicleParamsNeeds()
        {
            string whatINeedMsg, wheelsNeedsMsg, energyNeedsMsg;
            energyNeedsMsg = EnergySource.GetEnergySourceParamsNeeds();
            wheelsNeedsMsg = "12 wheels information: Model name, current amount of air";

            whatINeedMsg = string.Format(
@"Is carrying dangerous materials (True/False)
Volume of cargo
{0}
{1}",
energyNeedsMsg,
wheelsNeedsMsg);

            return whatINeedMsg;
        }

        public override void SetMyValues(string i_IsCarryingDangerousMaterials, string i_VolumeOfCargo)
        {
            if(!bool.TryParse(i_IsCarryingDangerousMaterials, out m_IsCarryingDangerousMaterials))
            {
                throw new FormatException(
                    "Invalid input. To answer Is carrying dangerous materials enter True/False.");
            }

            if (!float.TryParse(i_VolumeOfCargo, out m_VolumeOfCargo))
            {
                throw new FormatException("Invalid volume of cargo type.");
            }
        }

        public override int GetHowManyParams()
        {
            return k_NumOfParams;
        }

        public override string ToString()
        {
            string truckData = string.Format(
@"{0}
Is carrying dangerous materials: {1}
Volume of cargo: {2}",
base.ToString(),
m_IsCarryingDangerousMaterials,
m_VolumeOfCargo);

            return truckData;
        }
    }
}
