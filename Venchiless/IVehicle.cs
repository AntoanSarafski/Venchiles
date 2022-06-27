using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }

        public double FuelConsumption { get; }

        public double TankCapacity { get; }

        public bool IsEmpty { get; set; }

        public bool CanDrive(double kilometers);

        public void Drive(double kilometers);

        public void Refuel(double amount);

        public bool CanRefuel(double amount);

    }
}
