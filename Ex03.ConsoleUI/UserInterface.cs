using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        public enum eSelectOptions
        {
            AddNewVehicle = 1,
            DisplayVehicles,
            ChangeVehicleStatus,
            InflateAirInTheWheelsToTheMaximum,
            RefuelVehicle,
            ChargeElectricVehicle,
            DisplayFullData,
            Exit,
        }

        public void PrintMenu()
        {
            string menu;
            menu = string.Format(@"1.Add new vehicle
2.Display vehicles
3.Change vehicle status
4.Inflate air to the maximum
5.Refuel vehicle
6.Charge electric vehicle
7.Display full data
8.Exit");
            System.Console.WriteLine(menu);
        }

        public eSelectOptions GetUserChoice()
        {
            string input;
            int userChoice;
            System.Console.WriteLine("Please select your choice ");
            input = System.Console.ReadLine();
            checkUserSelection(input, 8);
            userChoice = int.Parse(input);
            return (eSelectOptions)userChoice;
            }

        private void checkUserSelection(string i_Input, int i_MaxSelectedOption)
        {
            if (i_Input.Length > 1)
            {
                throw new FormatException("User didn't entered a valid input");
            }

            bool result;
            int selectedNumber;
            result = int.TryParse(i_Input, out selectedNumber);
            if (!result)
            {
                throw new FormatException("User didn't entered a number in menu selection");
            }

            if (selectedNumber < 1 || selectedNumber > i_MaxSelectedOption)
            {
                throw new ArgumentOutOfRangeException("User didn't entered a menu selection");
            }
        }

        // $G$ CSS-014 (-5) Bad variable name (should be in the form of: o_CamelCase).
        public void ScanLicensePlate(out string i_LicensePlate)
        {
            string input;
            System.Console.WriteLine("Please enter license plate");
            input = System.Console.ReadLine();
            checkIfLicensePlateOk(input);
            i_LicensePlate = input;
        }

        private void checkIfLicensePlateOk(string i_Input) 
        {
            int LicensePlateNumber;
            const int maximumLicensePlateNumber = 8;
            const int minimumLicensePlateNumber = 7;
            bool result = int.TryParse(i_Input, out LicensePlateNumber);
            if (!result)
            {
                throw new FormatException("User didn't entered a number");
            }

            if (i_Input.Length != maximumLicensePlateNumber && i_Input.Length != minimumLicensePlateNumber)
            {
                throw new FormatException("License plate can be only 7 or 8 number!");
            }
        }

        public void Print(string i_Message)
        {
            System.Console.WriteLine(i_Message);
        }

        public void ScanOwnerDetails(out string i_OwnerName, out string i_OwnerPhoneNumber)
        {
            string ownerName;
            string ownerPhoneNumber;
            System.Console.WriteLine("Enter owner name");
            ownerName = System.Console.ReadLine();
            checkIfNameISOk(ownerName);
            i_OwnerName = ownerName;
            System.Console.WriteLine("Enter owner phone number");
            ownerPhoneNumber = System.Console.ReadLine();
            checkIfPhoneNumberIsOk(ownerPhoneNumber);
            i_OwnerPhoneNumber = ownerPhoneNumber;
        }

        private void checkIfNameISOk(string i_Name)
        {
            if (i_Name.Length == 0)
            {
                throw new Exception("Name lenght can't be with zero letters");
            }

            foreach (char letter in i_Name)
            {
                if ((letter < 'a' || letter > 'z') && (letter < 'A' || letter > 'Z') && (letter != ' '))
                {
                    throw new FormatException("Name Must Contain only letters");
                }
            }
        }

        private void checkIfPhoneNumberIsOk(string i_OwnerPhoneNumber)
        {
            const float minimumDigits = 9;
            const float maximumDigits = 10;
            uint phoneNumber;
            bool result = uint.TryParse(i_OwnerPhoneNumber, out phoneNumber);

            if (i_OwnerPhoneNumber.Length > 10 || i_OwnerPhoneNumber.Length<9)
            {
                throw new ValueOutOfRangeExeption(minimumDigits, maximumDigits);
            }
            if (!result)
            {
                throw new FormatException("User did not enter valid phone number");
            }
        }

        // $G$ CSS-011 (-5) Public methods should start with an Uppercase letter.
        public CreateVehicles.eVehiclesType getVehicle()
        {
            const int numberOfMenuOptions = 3;
            string VehicalMenu = string.Format(@"Please select which vehical you want to insert :
1.Car
2.Motorcycle
3.Truck");
            Print(VehicalMenu);
            string selectedChoice = System.Console.ReadLine();
            checkUserSelection(selectedChoice, numberOfMenuOptions);
            int selectedVehicle = int.Parse(selectedChoice);
            return (CreateVehicles.eVehiclesType)selectedVehicle;        
        }

        public void ScanVehicleDetails(out string i_VehicleModelName, out string i_WheelManufacturer, out float i_CurrentAirPressure, out float i_CurrentEnergyAmount)
        {
            string input;
            System.Console.WriteLine("Enter vehicle model name");
            input = System.Console.ReadLine();
            checkIfVehicleNameISOk(input);
            i_VehicleModelName = input;
            System.Console.WriteLine("Enter wheel manufacturer name");
            input = System.Console.ReadLine();
            checkIfNameISOk(input);
            i_WheelManufacturer = input;
            System.Console.WriteLine("Please enter current wheel air pressure");
            input = System.Console.ReadLine();
            checkIfinputIsFloatNumber(input);
            i_CurrentAirPressure = float.Parse(input);
            System.Console.WriteLine("Please enter current energy amount");
            input = System.Console.ReadLine();
            checkIfinputIsFloatNumber(input);
            i_CurrentEnergyAmount = float.Parse(input);
        }

        private void checkIfVehicleNameISOk(string i_Name)
        {
            if (i_Name.Length == 0)
            {
                throw new Exception("Name lenght can't be zero letters");
            }
        }

        // $G$ CSS-013 (-5) Bad variable name (should be in the form of: i_CamelCase).
        private void checkIfinputIsFloatNumber(string i_input)
        {
            float number;
            bool result = float.TryParse(i_input, out number);
            if (!result)
            {
                throw new FormatException("User enterd not valid number");
            }
        }

        public void GetMotorcycleParametrs(Vehicle i_NewVehicle)
        {
            int engineCapacity;
            const int numberOfMotorcycleLicendeType = 4;
            int selectedlicendeType;
            string input;
            string motorcycleLicenseTypeMenu = string.Format(@"Please select motorcycle license type
1.A
2.A1
3.A2
4.B");
            System.Console.WriteLine("Enter engine capacity");
            input = System.Console.ReadLine();
            checkisEngineCapacity(input);
            engineCapacity = int.Parse(input);
            ((Motorcycle)i_NewVehicle).EngineCapacity = engineCapacity;
            System.Console.WriteLine(motorcycleLicenseTypeMenu);
            input = System.Console.ReadLine();
            checkUserSelection(input, numberOfMotorcycleLicendeType);
            selectedlicendeType = int.Parse(input);
            ((Motorcycle)i_NewVehicle).LicenseType = (Motorcycle.eLicenseType)selectedlicendeType;
            Console.Clear();
        }

        // $G$ CSS-013 (-5) Bad variable name (should be in the form of: i_CamelCase).
        private void checkisEngineCapacity(string I_input)
        {
            int engineCapacity;
            bool result = int.TryParse(I_input, out engineCapacity);
            if (!result || engineCapacity <= 0)
            {
                throw new FormatException("User didn't entered valid number for engine capacity");
            }
        }

        private void checkCargoVolumeInput(string i_Input)
        {
            float cargoVolume;
            bool result = float.TryParse(i_Input, out cargoVolume);
            if (!result || cargoVolume < 0)
            {
                throw new FormatException("User cargo volume not valid");
            }
        }

        public void DisplayVehiclesInTheGarage(Dictionary<string, AutomobileRepairShop> i_VehicleDictionary)
        {
            bool vehivleInCurrentStatus = false;
            string input;
            const short numberOfMenuOptions = 4;
            int userSelection;
            AutomobileRepairShop.eVehicleStatus vehicleStatus;
            string menu = string.Format(@"Please select your filter
1.In repair
2.repaired
3.paied
4.No filter");
            System.Console.WriteLine(menu);
            input = System.Console.ReadLine();
            checkUserSelection(input, numberOfMenuOptions);
            userSelection = int.Parse(input);
            if (userSelection == 4)
            {
                if (i_VehicleDictionary.Count == 0)
                {
                    System.Console.WriteLine("There are zero vehicles in the garage");
                }

                foreach (KeyValuePair<string, AutomobileRepairShop> keyAndValue in i_VehicleDictionary)
                {
                    System.Console.WriteLine(keyAndValue.Key);
                }
            }
            else
            {
                vehicleStatus = (AutomobileRepairShop.eVehicleStatus)userSelection;
                foreach (KeyValuePair<string, AutomobileRepairShop> keyAndValue in i_VehicleDictionary)
                {
                    if (keyAndValue.Value.VehicleStatus == vehicleStatus)
                    {
                        System.Console.WriteLine(keyAndValue.Key);
                        vehivleInCurrentStatus = true;
                    }
                }

                if (!vehivleInCurrentStatus)
                {
                    System.Console.WriteLine("There are zero vehicles in the garage with your selected filter");
                }
            }
        }

        public void ScanNewVehicleStatus(out AutomobileRepairShop.eVehicleStatus i_NewStatus)
        {
            int vehicalStatusNumber;
            const int userMenueNumberOptions = 3; 
            string input;
            string statusMenu = string.Format(@"Please select the new status
1.In repair
2.Repaired
3.Paied");
            System.Console.WriteLine(statusMenu);
            input = System.Console.ReadLine();
            checkUserSelection(input, userMenueNumberOptions);
            vehicalStatusNumber = int.Parse(input);
            i_NewStatus = (AutomobileRepairShop.eVehicleStatus)vehicalStatusNumber;
        }

        public void GetfuelType(out Fuel.eFuelType i_FuelType)
        {
            int userSelectedOption;
            const int userOptionsNumber = 4;
            string input;
            string menu = string.Format(@"Please select fuel type
1.Soler
2.Octan95
3.Octan96
4.Octan98");
            System.Console.WriteLine(menu);
            input = System.Console.ReadLine();
            checkUserSelection(input, userOptionsNumber);
            userSelectedOption = int.Parse(input);
            i_FuelType = (Fuel.eFuelType)userSelectedOption;
        }

        public void GetAmountOfFuel(out float i_AmountOfFuel)
        {
            System.Console.WriteLine("Please enter amount of fuel");
            string input = System.Console.ReadLine();
            checkIfinputIsFloatNumber(input);
            i_AmountOfFuel = float.Parse(input);
        }

        public void GetminuteToCharge(out float i_MinuteToCharge)
        {
            System.Console.WriteLine("Please enter how much minutes to charge");
            string input = System.Console.ReadLine();
            checkIfinputIsFloatNumber(input);
            i_MinuteToCharge = float.Parse(input);
        }

        public void GetEnergySource(out EngineType.eEnergySource i_EnergySource)
        {
            const int numberOfUserOptions = 2;
            int userSelection;
            string menu = string.Format(@"Please select engine type
1.Fuel
2.Electricity");
            System.Console.WriteLine(menu);
            string input = System.Console.ReadLine();
            checkUserSelection(input, numberOfUserOptions);
            userSelection = int.Parse(input);
            i_EnergySource = (EngineType.eEnergySource)userSelection;
        }

        public void GetCarParametrs(Vehicle i_NewVehicle)
        {
            const int numberOfCarColors = 4;
            const int numberOfCarDoorsOption = 4;
            string input;
            int doorsNumber;
            int colorSelection;
            string colorMenu = string.Format(@"Please select car color
1.Red
2.Blue
3.Black
4.Gray");
            System.Console.WriteLine(colorMenu);
            input = System.Console.ReadLine();
            checkUserSelection(input, numberOfCarColors);
            colorSelection = int.Parse(input);
            ((Car)i_NewVehicle).CarColor = (Car.eColor)colorSelection;
            string doorMenu = string.Format(@"Please select number of doors
1.Two
2.Three
3.Four
4.Five");
            System.Console.WriteLine(doorMenu);
            input = System.Console.ReadLine();
            checkUserSelection(input, numberOfCarDoorsOption);
            doorsNumber = int.Parse(input);
            ((Car)i_NewVehicle).NumberOfDoors = (Car.eNumberOfDoors)doorsNumber;
            Console.Clear();
        }

        // $G$ CSS-999 (-5) If you use string as a condition --> then you should have use constant here.
        public void GetTruckParametrs(Vehicle i_NewVehicle)
        {
            string input;
            System.Console.WriteLine("Is the truck transporting hazardous materials? (enter Y/N) ");
            input = System.Console.ReadLine();
            while (!input.Equals("Y") && !input.Equals("N"))
            {
                System.Console.WriteLine("Enter Y for yes or N for no");
                input = System.Console.ReadLine();
            }

            ((Truck)i_NewVehicle).IsLTransportDangerousMaterials = input.Equals("Y");
            System.Console.WriteLine("Enter truck cargo volume");
            input = System.Console.ReadLine();
            checkCargoVolumeInput(input);
            ((Truck)i_NewVehicle).VolumeOfCargo = float.Parse(input);
            Console.Clear();
        }
    }
}
