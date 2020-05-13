using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManagement
    {
        private readonly GarageLogic.ManageGarage m_Garage = new GarageLogic.ManageGarage();
        // $G$ NTT-999 (-5) This kind of field should be readonly.
        private UserInterface m_UserInterface = new UserInterface();
        private UserInterface.eSelectOptions m_SelectedOption;

        public void Start()
        {
            do
            {
                try
                {
                    m_UserInterface.PrintMenu();
                    m_SelectedOption = m_UserInterface.GetUserChoice();
                    Console.Clear();
                    switch (m_SelectedOption)
                    {
                        case UserInterface.eSelectOptions.AddNewVehicle:
                            addNewVehicle();
                            break;
                        case UserInterface.eSelectOptions.DisplayVehicles:
                            displayVehicles();
                            break;
                        case UserInterface.eSelectOptions.ChangeVehicleStatus:
                            changeVehicleStatus();
                            break;
                        case UserInterface.eSelectOptions.InflateAirInTheWheelsToTheMaximum:
                            inflateAirInTheWheelsToTheMaximum();
                            break;
                        case UserInterface.eSelectOptions.RefuelVehicle:
                            refuelVehicle();
                            break;
                        case UserInterface.eSelectOptions.ChargeElectricVehicle:
                            chargeElectricVehicle();
                            break;
                        case UserInterface.eSelectOptions.DisplayFullData:
                            displayFullData();
                            break;
                        case UserInterface.eSelectOptions.Exit:
                            return;
                        default:
                            m_UserInterface.Print("Invalid input please try again");
                            break;
                    }

                    m_UserInterface.Print(Environment.NewLine);
                }
                catch (FormatException fe)
                {
                    m_UserInterface.Print(fe.Message);
                }
                catch (ArgumentOutOfRangeException aoore)
                {
                    m_UserInterface.Print(aoore.Message);
                }
                catch (ArgumentException ae)
                {
                    m_UserInterface.Print(ae.Message);
                }
                catch (ValueOutOfRangeExeption voore)
                {
                    m_UserInterface.Print(voore.Message);
                }
                catch (Exception)
                {
                    m_UserInterface.Print("Something want wrong please try again");
                }
                }
            while (m_SelectedOption != UserInterface.eSelectOptions.Exit);
        }

        private void addNewVehicle()
        {
            string licensePlate = getLicensePlate();
            bool ifVhicleAlredyExist;
            ifVhicleAlredyExist = m_Garage.CheckIfVhicleAlredyExist(licensePlate);
            if (ifVhicleAlredyExist == true)
            {
                m_UserInterface.Print("Vehicle alredy exist in the garage");
                m_Garage.UpdateStatus(licensePlate, GarageLogic.AutomobileRepairShop.eVehicleStatus.InRepair);
            }
            else
            {
                string vehicleModelName;
                string wheelManufacturer;
                string ownerName;
                string ownerPhoneNumber;
                float currentAirPressure;
                float currentEnergyAmount;
                m_UserInterface.ScanOwnerDetails(out ownerName, out ownerPhoneNumber);
                CreateVehicles.eVehiclesType vehicleType = m_UserInterface.getVehicle();
                EngineType.eEnergySource energySource;
                if (vehicleType == CreateVehicles.eVehiclesType.Truck)
                {
                    energySource = EngineType.eEnergySource.Fuel;
                }
                else
                {
                    m_UserInterface.GetEnergySource(out energySource);
                }

                m_UserInterface.ScanVehicleDetails(out vehicleModelName, out wheelManufacturer, out currentAirPressure, out currentEnergyAmount);
                Vehicle newVehicle = null;
                switch (vehicleType)
                {       
                    case CreateVehicles.eVehiclesType.Car:
                        newVehicle = CreateVehicles.CreateVehicle(licensePlate, vehicleModelName, wheelManufacturer, energySource, vehicleType, currentAirPressure, currentEnergyAmount);
                        m_UserInterface.GetCarParametrs(newVehicle);
                        break;
                    case CreateVehicles.eVehiclesType.Motorcycle:
                        newVehicle = CreateVehicles.CreateVehicle(licensePlate, vehicleModelName, wheelManufacturer, energySource, vehicleType, currentAirPressure, currentEnergyAmount);
                        m_UserInterface.GetMotorcycleParametrs(newVehicle);
                        break;
                    case CreateVehicles.eVehiclesType.Truck:
                        newVehicle = CreateVehicles.CreateVehicle(licensePlate, vehicleModelName, wheelManufacturer, energySource, vehicleType, currentAirPressure, currentEnergyAmount);
                        m_UserInterface.GetTruckParametrs(newVehicle);
                        break;
                }

                m_Garage.AddNewVhicle(ownerName, ownerPhoneNumber, newVehicle);
            }
        }

        private void displayVehicles()
        {
            m_UserInterface.DisplayVehiclesInTheGarage(m_Garage.ManageGarageDictionary);
        }

        private void changeVehicleStatus()
        {
            string licensePlate = getLicensePlate();
            AutomobileRepairShop.eVehicleStatus newStatus;
            m_UserInterface.ScanNewVehicleStatus(out newStatus);
            m_Garage.UpdateStatus(licensePlate, newStatus);
        }

        private void inflateAirInTheWheelsToTheMaximum()
        {
            string licensePlate = getLicensePlate();
            foreach (Wheel wheel in m_Garage.ManageGarageDictionary[licensePlate].newVehicle.Wheels)
            {
                wheel.FillAir(wheel.MaxtAirPressure - wheel.CurrentAirPressure);
            }
        }

        private void refuelVehicle()
        {
            string licensePlate = getLicensePlate();
            Fuel.eFuelType fuelType;
            float amountOfFuel;
            m_UserInterface.GetfuelType(out fuelType);
            Fuel fuel = m_Garage.ManageGarageDictionary[licensePlate].newVehicle.EnergySource as Fuel;
            if (m_Garage.ManageGarageDictionary[licensePlate].newVehicle.EnergySource is Fuel)
            {
                fuel.CheckFuelType(fuelType);
            }
            else
            {
                throw new ArgumentException("User try to refuel electric car");
            }

            m_UserInterface.GetAmountOfFuel(out amountOfFuel);
            m_Garage.ManageGarageDictionary[licensePlate].newVehicle.EnergySource.FillEnergy(amountOfFuel);
        }

        private void chargeElectricVehicle()
        {
            float minuteToCharge;
            string licensePlate = getLicensePlate();
            m_UserInterface.GetminuteToCharge(out minuteToCharge);
            if (m_Garage.ManageGarageDictionary[licensePlate].newVehicle.EnergySource is Electricity)
            {
                m_Garage.ManageGarageDictionary[licensePlate].newVehicle.EnergySource.FillEnergy(minuteToCharge);
            }
            else
            {
                throw new ArgumentException("User try to charge fuel type car");
            }
        }

        private void displayFullData()
        {
            string licensePlate = getLicensePlate();
            Console.Clear();
            m_UserInterface.Print(m_Garage.ManageGarageDictionary[licensePlate].ToString());
        }

        private string getLicensePlate()
        {
            string licensePlate;
            m_UserInterface.ScanLicensePlate(out licensePlate);
            return licensePlate;
        }   
    }
}
