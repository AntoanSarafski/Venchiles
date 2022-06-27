using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double tankCapacity, double fuelQuantity, double fuelConsumption) 
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }
        public override double FuelConsumption
            => this.IsEmpty
            ? base.FuelConsumption
            : base.FuelConsumption + 1.4;
    }
}
