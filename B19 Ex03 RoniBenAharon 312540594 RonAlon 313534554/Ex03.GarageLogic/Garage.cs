namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Garage
    {
        private Dictionary<string, VehicleAtGarage> m_Vehicles;

        public Garage()
        {
           m_Vehicles = new Dictionary<string, VehicleAtGarage>();
        }

        public List<string> FilterVehiclesByState(eVehicleState i_VehicleState)
        {
            List<string> LicenseList = new List<string>();

            foreach(KeyValuePair<string, VehicleAtGarage> vehicleAtGarage in m_Vehicles)
            {
                if(vehicleAtGarage.Value.VehicleState == i_VehicleState)
                {
                    LicenseList.Add(vehicleAtGarage.Value.Vehicle.LicenseNumber);
                }
            }

            return LicenseList;
        }
       
        public List<string> GetAllVehiclesLicenseNumber()
        {
            List<string> LicenseList = new List<string>();

            foreach (KeyValuePair<string, VehicleAtGarage> vehicleAtGarage in m_Vehicles)
            {
                LicenseList.Add(vehicleAtGarage.Value.Vehicle.LicenseNumber);
            }

            return LicenseList;
        }

        public void ChangeVehicleState(string i_LicenseNumber, eVehicleState i_NewState)
        {
            if (IsVehicleinGarage(i_LicenseNumber))
            {
                m_Vehicles[i_LicenseNumber].VehicleState = i_NewState;
            }
            else
            {
                throw new ArgumentException("Couldn't find this license number.");
            }
        }

        public void FillWheelsWithMaxAir(string i_LicenseNumber)
        {
            if(IsVehicleinGarage(i_LicenseNumber))
            {
                Wheel[] wheelsToFill = m_Vehicles[i_LicenseNumber].Vehicle.Wheels;
                foreach(Wheel wheel in wheelsToFill)
                {
                    wheel.Fill(wheel.MaxCapacity - wheel.CurrentCapacity);
                }
            }
            else
            {
                throw new ArgumentException("Couldn't find this license number.");
            }
        }

        public void FillVehicleAtGarageWithFuel(string i_LicenseNumber, float i_AmountOfFuelToadd, Fuel.eFuelType i_FuelType)
        {
            if (IsVehicleinGarage(i_LicenseNumber))
            {
                Vehicle vehicleInRepair = m_Vehicles[i_LicenseNumber].Vehicle;
                Fuel fuelToCompare = vehicleInRepair.EnergySource as Fuel;
                if (fuelToCompare != null)
                {
                    if (fuelToCompare.FuelType == i_FuelType)
                    {
                        fuelToCompare.Fill(i_AmountOfFuelToadd);
                        vehicleInRepair.SetPrecentageOfEnergy();
                    }
                    else
                    {
                        throw new ArgumentException("Wrong fuel type!");
                    }
                }
                else
                {
                    throw new ArgumentException("This vehicle is NOT a fuel vehicle.");
                }
            }
            else
            {
                throw new ArgumentException("Couldn't find this license number.");
            }
        }

        public void ChargeVehicleAtGarage(string i_LicenseNumber, float i_MinutesToCharge)
        {
            if (IsVehicleinGarage(i_LicenseNumber))
            {
                Electricity electToCompare = m_Vehicles[i_LicenseNumber].Vehicle.EnergySource as Electricity;
                if (electToCompare != null)
                {
                    electToCompare.Fill(i_MinutesToCharge / 60f);
                }
                else
                {
                    throw new ArgumentException("This vehicle is NOT an electricity vehicle.");
                }
            }
            else
            {
                throw new ArgumentException("Couldn't find this license number.");
            }
        }

        public void AddToGarage(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerCellphone)
        {
            VehicleAtGarage newVehicleAtGarage = new VehicleAtGarage(
                i_OwnerName,
                i_OwnerCellphone,
                eVehicleState.DuringRepair,
                i_Vehicle);
            m_Vehicles.Add(i_Vehicle.LicenseNumber, newVehicleAtGarage);
        }

        public bool IsVehicleinGarage(string i_LicenseNumber)
        {
            return m_Vehicles.ContainsKey(i_LicenseNumber);
        }

        public string GetVehiclefullData(string i_LicenseNumber)
        {
            string fullData = null;

            if (IsVehicleinGarage(i_LicenseNumber))
            {
                fullData = m_Vehicles[i_LicenseNumber].ToString();
            }
            else
            {
                throw new ArgumentException("Couldn't find this license number.");
            }

            return fullData;
        }
    }
}
