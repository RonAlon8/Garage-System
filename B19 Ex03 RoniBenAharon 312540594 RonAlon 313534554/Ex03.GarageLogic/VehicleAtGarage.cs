namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class VehicleAtGarage
    {
        private string m_OwnerName;
        private string m_OwnerCellphone;
        private Vehicle m_Vehicle;
        private eVehicleState m_VehicleState;

        public VehicleAtGarage(
            string i_OwnerName,
            string i_OwnerCellphone,
            eVehicleState i_VehicleState,
            Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerCellphone = i_OwnerCellphone;
            m_VehicleState = i_VehicleState;
            m_Vehicle = i_Vehicle;
        }

        internal Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
        }

        internal string OwnerName
        {
            get
            {
                return m_OwnerName;
            }

            set
            {
                m_OwnerName = value;
            }
        }

        internal string OwnerCellphone
        {
            get
            {
                return m_OwnerCellphone;
            }

            set
            {
                m_OwnerCellphone = value;
            }
        }

        internal eVehicleState VehicleState
        {
            get
            {
                return m_VehicleState;
            }

            set
            {
                this.m_VehicleState = value;
            }
        }

        public override string ToString()
        {
            string fullData = string.Format(
@"Owner name: {0}
Owner Cellphone number: {1}
Vehicle state: {2}
{3}",
m_OwnerName,
m_OwnerCellphone, 
m_VehicleState.ToString(),
m_Vehicle.ToString());

            return fullData;
        }
    }
}
