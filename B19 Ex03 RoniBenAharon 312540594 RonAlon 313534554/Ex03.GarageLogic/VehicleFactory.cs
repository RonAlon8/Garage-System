namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class VehicleFactory
    {
        private const int k_MotorcycleWheelsNumber = 2;
        private const Fuel.eFuelType k_MotorcycleFuleType = Fuel.eFuelType.Octan95;
        private const float k_MotorcycleMaxAirPressure = 33f;
        private const float k_MotorcycleMaxAmountOfFuel = 8f;
        private const float k_MotorcycleMaxBatteryTimeInHours = 1.4f;

        private const int k_CarWheelsNumber = 4;
        private const Fuel.eFuelType k_CarFuleType = Fuel.eFuelType.Octan96;
        private const float k_CarMaxAirPressure = 31f;
        private const float k_CarMaxAmountOfFuel = 55f;
        private const float k_CarMaxBatteryTimeInHours = 1.8f;

        private const int k_TruckWheelsNumber = 12;
        private const Fuel.eFuelType k_TruckFuleType = Fuel.eFuelType.Soler;
        private const float k_TruckMaxAirPressure = 26f;
        private const float k_TruckMaxAmountOfFuel = 110f;

        private List<string> m_VehiclesTypes = new List<string>()
        {
            "Fuel car",
            "Electricity car",
            "Fuel Motorcycle",
            "Electricity Motorcycle",
            "Truck"
        };

        public List<string> VehiclesTypes
        {
            get
            {
                return m_VehiclesTypes;
            }
        }

        public Vehicle CreateVehicle(int i_VehicleChoose, string i_LicenseNumber, string i_ModelNumber)
        {
            Vehicle newVehicle = null;
            Wheel[] wheels;
            switch (i_VehicleChoose)
            {
                case 1:
                    {
                        wheels = createWheels(k_CarWheelsNumber, k_CarMaxAirPressure);
                        newVehicle = new Car(
                            i_LicenseNumber,
                            i_ModelNumber,
                            new Fuel(k_CarFuleType, k_CarMaxAmountOfFuel),
                            wheels);
                        break;
                    }

                case 2:
                    {
                        wheels = createWheels(k_CarWheelsNumber, k_CarMaxAirPressure);
                        newVehicle = new Car(
                            i_LicenseNumber,
                            i_ModelNumber,
                            new Electricity(k_CarMaxBatteryTimeInHours),
                            wheels);
                        break;
                    }

                case 3:
                    {
                        wheels = createWheels(k_MotorcycleWheelsNumber, k_MotorcycleMaxAirPressure);
                        newVehicle = new Motorcycle(
                            i_LicenseNumber,
                            i_ModelNumber,
                            new Fuel(k_MotorcycleFuleType, k_MotorcycleMaxAmountOfFuel),
                            wheels);
                        break;
                    }

                case 4:
                    {
                        wheels = createWheels(k_MotorcycleWheelsNumber, k_MotorcycleMaxAirPressure);
                        newVehicle = new Motorcycle(
                            i_LicenseNumber,
                            i_ModelNumber,
                            new Electricity(k_MotorcycleMaxBatteryTimeInHours),
                            wheels);
                        break;
                    }

                case 5:
                    {
                        wheels = createWheels(k_TruckWheelsNumber, k_TruckMaxAirPressure);
                        newVehicle = new Truck(
                            i_LicenseNumber,
                            i_ModelNumber,
                            new Fuel(k_TruckFuleType, k_TruckMaxAmountOfFuel),
                            wheels);
                        break;
                    }
            }

            return newVehicle;
        }

        private Wheel[] createWheels(int i_WheelsNumber, float i_MaxAirPressure)
        {
            Wheel[] wheels = new Wheel[i_WheelsNumber];
            for (int i = 0; i < i_WheelsNumber; i++)
            {
                wheels[i] = new Wheel(i_MaxAirPressure);
            }

            return wheels;
        }
    }
}
