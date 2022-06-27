
using System;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        protected Vehicle(
            double tankCapacity, 
            double fuelQuantity, 
            double fuelConsumption)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity
        { 
            get => fuelQuantity; 
            private set
            {
                if (value > this.TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption { get; protected set; }

        public double TankCapacity { get; }
        public bool IsEmpty { get ; set ; }

        public bool CanDrive(double kilometers)
            => this.FuelQuantity - (kilometers * this.FuelConsumption) >= 0;

        public bool CanRefuel(double amount)
            => this.FuelQuantity + amount <= this.TankCapacity;

        public void Drive(double kilometers)
        {
            if (this.FuelQuantity - (kilometers * this.FuelConsumption) >= 0)
            {
                this.FuelQuantity -= kilometers * this.FuelConsumption;
            }
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (CanRefuel(amount))
            {
                this.FuelQuantity += amount;
            }
            else
            {
                System.Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
        }
    }
}
