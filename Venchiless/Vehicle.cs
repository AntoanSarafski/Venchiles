using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; set; }

        public virtual double FuelConsumption { get; set; }

        public bool CanDrive(double kilometers)
            => this.FuelQuantity - (kilometers * this.FuelConsumption) >= 0;


        public void Drive(double kilometers)
        {
            if (this.FuelQuantity - (kilometers * this.FuelConsumption) >= 0)
            {
                this.FuelQuantity -= kilometers * this.FuelQuantity;
            }
        }

        public virtual void Refuel(double amount)
        {
            this.FuelQuantity += amount;
        }


    }
}
