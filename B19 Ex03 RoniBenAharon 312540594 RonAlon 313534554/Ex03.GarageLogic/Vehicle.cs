namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vehicle
    {
        private readonly string r_LicenseNumber;
        private readonly string r_ModelName;
        private readonly VehicleEnergySource r_EnergySource;
        private float m_PercentageOfEnergyLeft;
        // $G$ DSN-999 (-3) This List should be readonly
        private Wheel[] m_Wheels;

        public Vehicle(
            string i_LicenseNumber, 
            string i_ModelName, 
            VehicleEnergySource i_EnergySource,
            Wheel[] i_Weels)
        {
            r_LicenseNumber = i_LicenseNumber;
            r_ModelName = i_ModelName;
            r_EnergySource = i_EnergySource;
            m_Wheels = i_Weels;
        }

        internal VehicleEnergySource EnergySource
        {
            get
            {
                return r_EnergySource;
            }
        }

        internal Wheel[] Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        internal string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public abstract string GetVehicleParamsNeeds();

        public void SetValues(List<string> i_ParamsList)
        {
            int numOfValues = GetHowManyParams();
            if (i_ParamsList.Count == numOfValues)
            {
                SetMyValues(i_ParamsList[0], i_ParamsList[1]);
                EnergySource.SetEnergyValues(i_ParamsList[2]);
                SetPrecentageOfEnergy();

                for (int i = 0; i < Wheels.Length; i++)
                {
                    ///Wheels params at indexes 3 and up
                    Wheels[i].SetWheelValues(i_ParamsList[3 + (i * 2)], i_ParamsList[4 + (i * 2)]);
                }
            }
            else if (i_ParamsList.Count < numOfValues) 
            {
                throw new FormatException("Not enough parameters were sent.");
            }
            else
            {
                throw new FormatException("Too many parameters were sent.");
            }
        }

        public override string ToString()
        {
            StringBuilder wheelsData = new StringBuilder();
            foreach(Wheel wheel in m_Wheels)
            {
                wheelsData.AppendLine(wheel.ToString());
            }

            string vehicleData = string.Format(
@"License Number: {0}
Model name: {1}
Percentage of energy left: {2}%
{3}{4}",
r_LicenseNumber, 
r_ModelName,
m_PercentageOfEnergyLeft,
wheelsData,
r_EnergySource.ToString());

            return vehicleData;
        }

        public void SetPrecentageOfEnergy()
        {
            m_PercentageOfEnergyLeft = (r_EnergySource.CurrentCapacity / r_EnergySource.MaxCapacity) * 100f;
        }

        public abstract int GetHowManyParams();

        public abstract void SetMyValues(string i_Param1, string i_Param2);
    }
}
