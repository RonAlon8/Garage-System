namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car : Vehicle
    {
        private const int k_NumOfParams = 11;
        private const int k_MinNumOfDoors = 2;
        private const int k_MaxNumOfDoors = 5;
        private eNumOfDoors m_NumOfDoors;
        private eCarColor m_Color;

        internal enum eCarColor
        {
            Red,
            Blue,
            Black,
            Gray
        }

        internal enum eNumOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        public Car(
            string i_LicenseNumber,
            string i_ModelName,
            VehicleEnergySource i_EnergyManager,
            Wheel[] i_Weels) : base(i_LicenseNumber, i_ModelName, i_EnergyManager, i_Weels)
        {
        }

        internal eNumOfDoors NumOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }

            set
            {
                m_NumOfDoors = value;
            }
        }

        internal eCarColor CarColor
        {
            get
            {
                return m_Color;
            }

            set
            {
                m_Color = value;
            }
        }

        public override string GetVehicleParamsNeeds()
        {
            string whatINeedMsg, wheelsNeedsMsg, energyNeedsMsg;
            energyNeedsMsg = EnergySource.GetEnergySourceParamsNeeds();
            wheelsNeedsMsg = "4 wheels information: Model name, current amount of air";

            whatINeedMsg = string.Format(
@"Car color
Num of doors
{0}
{1}",
energyNeedsMsg,
wheelsNeedsMsg);

            return whatINeedMsg;
        }

        public override void SetMyValues(string i_CarColor, string i_NumOfDoors)
        {
            int numOfDoors;

            if (Enum.IsDefined(typeof(eCarColor), i_CarColor))
            {
                m_Color = (eCarColor)Enum.Parse(typeof(eCarColor), i_CarColor);
            }
            else
            {
                throw new FormatException("Invalid color choise");
            }

            if (int.TryParse(i_NumOfDoors, out numOfDoors) && numOfDoors >= k_MinNumOfDoors && numOfDoors <= k_MaxNumOfDoors)
            {
                m_NumOfDoors = (eNumOfDoors)numOfDoors;
            }
            else
            {
                throw new FormatException("Invalid num of doors choise");
            }
        }

        public override int GetHowManyParams()
        {
            return k_NumOfParams;
        }

        public override string ToString()
        {
            string carData = string.Format(
@"{0}
Car color: {1}
Num of doors: {2}",
base.ToString(),
m_Color.ToString(),
m_NumOfDoors.ToString());

            return carData;
        }
    }
}