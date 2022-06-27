
namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double tankCapacity, double fuelQuantity, double fuelConsumption) 
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption
            => base.FuelConsumption + 0.9;
    }
}
