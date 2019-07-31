namespace Ex03.ConsoleUI
{
    using System.Text.RegularExpressions;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ex03.GarageLogic;

    public class MenuManager
    {
        private const int k_Exit = 8;

        // $G$ NTT-999 (-5) This kind of field should be readonly.
        private Garage m_OurGarage = new Garage();
        private VehicleFactory m_OurFactory = new VehicleFactory();

        private enum eFunctions
        {
            AddVehicle = 1,
            PrintLicense = 2,
            ChangeState = 3,
            FillVehicleWheelsToMax = 4,
            FillVehicleFuel = 5,
            ChargeVehicleBattery = 6,
            ShowVehicleDataAtGarage = 7
        }

        internal void StartProgram()
        {
            int functionChoose = 0;

            while (functionChoose != k_Exit)
            {
                functionChoose = showMenu();
                try
                {
                    switch ((eFunctions)functionChoose)
                    {
                        case eFunctions.AddVehicle:
                            {
                                addVehicle();
                                break;
                            }

                        case eFunctions.ChangeState:
                            {
                                changeState();
                                break;
                            }

                        case eFunctions.ChargeVehicleBattery:
                            {
                                chargeVehicleBattery();
                                break;
                            }

                        case eFunctions.FillVehicleFuel:
                            {
                                fillVehicleFuel();
                                break;
                            }

                        case eFunctions.FillVehicleWheelsToMax:
                            {
                                fillVehicleWheelsToMax();
                                break;
                            }

                        case eFunctions.PrintLicense:
                            {
                                printLicenseAsUserChoose();
                                break;
                            }

                        case eFunctions.ShowVehicleDataAtGarage:
                            {
                                string licenseNumber = getLicenseNumberFromUser();
                                string vehicleAtGarageDate = m_OurGarage.GetVehiclefullData(licenseNumber);
                                Console.WriteLine();
                                Console.WriteLine(vehicleAtGarageDate);
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    ///Catching the 3 kinds of exceptions.
                    Console.WriteLine(ex.Message);
                }
             
                Console.WriteLine();
            }
        }

        private int showMenu()
        {
            string UserOptions = string.Format(
@"-------------------------------------------------------------------------
Please Choose one of the following functions to apply:
1) Add a new car into the garage.
2) Display list of vehicle license numbers in the garage, 
   with the option to filter according to their condition in the garage.
3) Change the state of a car in the garage.
4) Fill air in the wheels of a vehicle to maximum.
5) Fuel a vehicle driven by fuel.
6) Charge an electric vehicle.
7) Display full data of vehicle according to license number.
8) EXIT.
-------------------------------------------------------------------------");
            Console.WriteLine(UserOptions);
            return getNumberFromUser(1, 8);
        }

        private int getVehicleTypeChoise(List<string> i_VehiclesTypes)
        {
            string msg;
            int choose;

            Console.WriteLine("Choose vehicle number to create: ");

            for (int i = 0; i < i_VehiclesTypes.Count; i++)
            {
                msg = string.Format("{0}. {1}", i + 1, i_VehiclesTypes[i]);
                Console.WriteLine(msg);
            }

            choose = getNumberFromUser(1, i_VehiclesTypes.Count);
            return choose;
        }

        private void getBasicDataFromOwner(
            out string o_OwnerName,
            out string o_OwnerCellphone,
            out string o_LicenseNumber,
            out string o_ModelName)
        {
            Console.Write("Please enter owner name: ");
            o_OwnerName = getLettersStringFromUser();
            Console.Write("Please enter owner cellphone: ");
            o_OwnerCellphone = getNumberString();
            Console.Write("Please enter license number: ");
            o_LicenseNumber = getNonEmptyStringFromUser();
            Console.Write("Please enter model name: ");
            o_ModelName = getNonEmptyStringFromUser();
        }

        private string getLettersStringFromUser()
        {
            string strFromUser = null;
            bool isValid = false;

            while(!isValid)
            {
                strFromUser = Console.ReadLine();
                isValid = Regex.IsMatch(strFromUser, @"^[a-zA-Z]+$");
                if (!isValid)
                {
                    Console.WriteLine("Invalid input, Please try again.");
                }
            }

            return strFromUser;
        }

        private string getNumberString()
        {
            string strFromUser = null;
            bool isValid = false;

            while (!isValid)
            {
                strFromUser = Console.ReadLine();
                isValid = Regex.IsMatch(strFromUser, @"^[0-9]+$");
                if (!isValid)
                {
                    Console.WriteLine("Invalid input, Please try again.");
                }
            }

            return strFromUser;
        }

        private string getNonEmptyStringFromUser()
        {
            string strFromUser = null;
            bool isValid = false;

            while (!isValid)
            {
                strFromUser = Console.ReadLine();
                strFromUser = strFromUser.Trim();
                isValid = !string.IsNullOrEmpty(strFromUser);
                if (!isValid)
                {
                    Console.WriteLine("Invalid input, Please try again.");
                }
            }

            return strFromUser;
        }

        private void addVehicle()
        {
            string ownerName, ownerCellphone, licenseNumber, modelName;

            getBasicDataFromOwner(out ownerName, out ownerCellphone, out licenseNumber, out modelName);

            if (m_OurGarage.IsVehicleinGarage(licenseNumber))
            {
                Console.WriteLine("This vehicle is already in the garage. State changed to: during a repair");
                m_OurGarage.ChangeVehicleState(licenseNumber, eVehicleState.DuringRepair);
            }
            else
            {
                int choose = getVehicleTypeChoise(m_OurFactory.VehiclesTypes);
                Vehicle newVehicle = m_OurFactory.CreateVehicle(choose, licenseNumber, modelName);
                string infoVehicleNeed = newVehicle.GetVehicleParamsNeeds();
                string msg = string.Format(
@"Please enter the follwing parameters:
using ',' (for example: Red, 4, 10).
{0}",
infoVehicleNeed);

                Console.WriteLine(msg);

                string allParams = Console.ReadLine();
                newVehicle.SetValues(makeCollectionFromString(allParams));
                m_OurGarage.AddToGarage(newVehicle, ownerName, ownerCellphone);
                Console.WriteLine("Yay! vehicle Car successfully added.");
            }
        }

        private void changeState()
        {
            int choose;
            string licenseNumber = getLicenseNumberFromUser();

            string msg = string.Format(
@"Please choose the state you want to change to:
1. Douring a Repair.
2. Fixed.
3. Paid");

            Console.WriteLine(msg);
            choose = getNumberFromUser(1, 3);

            m_OurGarage.ChangeVehicleState(licenseNumber, (eVehicleState)choose);
        }

        private void fillVehicleWheelsToMax()
        {
            m_OurGarage.FillWheelsWithMaxAir(getLicenseNumberFromUser());
            Console.WriteLine("The wheels were filled successfully!");
        }

        private void fillVehicleFuel()
        {
            string licenseNumber = getLicenseNumberFromUser();
            int choose;
            float amountOfFuelToAdd;
            string msg = string.Format(
@"Please choose the state you want to change to:
1. Soler,
2. Octan95,
3. Octan96,
4. Octan98");

            Console.WriteLine(msg);
            choose = getNumberFromUser(1, 4);

            Console.Write("Please enter the amount of fuel you want to add: ");
            amountOfFuelToAdd = getFloatFromUser();

            m_OurGarage.FillVehicleAtGarageWithFuel(licenseNumber, amountOfFuelToAdd, (Fuel.eFuelType)choose);
            Console.WriteLine("Vehicle was filled successfully!");
        }

        private void chargeVehicleBattery()
        {
            string licenseNumber = getLicenseNumberFromUser();
            float minutesToCharge;

            Console.Write("Please enter battery time in minutes you want to add: ");
            minutesToCharge = getFloatFromUser();

            m_OurGarage.ChargeVehicleAtGarage(licenseNumber, minutesToCharge);
            Console.WriteLine("Vehicle was Charged successfully!");
        }

        private string getLicenseNumberFromUser()
        {
            string licenseNumber;
            Console.Write("Please enter vehicle's license number: ");
            licenseNumber = getNonEmptyStringFromUser();
            return licenseNumber;
        }

        private float getFloatFromUser()
        {
            float choose;
            bool isValid = float.TryParse(Console.ReadLine(), out choose);

            while (!isValid)
            {
                Console.WriteLine("Invalid input, please try again.");
                isValid = float.TryParse(Console.ReadLine(), out choose);
            }

            return choose;
        }

        private void printLicenseAsUserChoose()
        {
            List<string> lstToPrint;

            int choose;
            string msg = string.Format(
@"Please choose one of the following options:
1. Show all during a repair vehicles.
2. Show all fixed vehicles.
3. Show all paid vehicles
4. Show all vehicles.");

            Console.WriteLine(msg);
            choose = getNumberFromUser(1, 4);

            if (choose == 4)
            {
                lstToPrint = m_OurGarage.GetAllVehiclesLicenseNumber();
            }
            else
            {
                lstToPrint = m_OurGarage.FilterVehiclesByState((eVehicleState)choose);
            }

            if (lstToPrint.Count > 0)
            {
                Console.WriteLine("License:");
                printList(lstToPrint);
            }
            else
            {
                Console.WriteLine("Non of the vehicles at the garage fits your state choise.");
            }
        }

        private void printList(List<string> i_LstToPrint)
        {
            foreach (string strToPrint in i_LstToPrint)
            {
                Console.WriteLine(strToPrint);
            }
        }

        private List<string> makeCollectionFromString(string i_StringToCollection)
        {
            List<string> paramsList = new List<string>();

            int i = i_StringToCollection.IndexOf(",");

            /// -1 is the return value when IndexOf() Can't find the string it's looking for.
            while (i != -1)
            {
                string strToCheck = i_StringToCollection.Substring(0, i);
                if (!string.IsNullOrEmpty(strToCheck.Trim()))
                {
                    paramsList.Add(i_StringToCollection.Substring(0, i));
                }

                i_StringToCollection = i_StringToCollection.Remove(0, i + 1);
                i_StringToCollection = i_StringToCollection.TrimStart();
                i = i_StringToCollection.IndexOf(",");
            }

            if (!string.IsNullOrEmpty(i_StringToCollection))
            {
                paramsList.Add(i_StringToCollection.Substring(0));
            }

            return paramsList;
        }

        private int getNumberFromUser(int i_MinValue, int i_MaxValue)
        {
            int choose;
            bool isValid = int.TryParse(Console.ReadLine(), out choose);

            while (!isValid || (choose < i_MinValue || choose > i_MaxValue))
            {
                Console.WriteLine("Invalid input, please try again.");
                isValid = int.TryParse(Console.ReadLine(), out choose);
            }

            return choose;
        }
    }
}
