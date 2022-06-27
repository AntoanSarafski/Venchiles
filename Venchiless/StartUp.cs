using System;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] truckInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carLitersPerKilometer = double.Parse(carInfo[2]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckLitersPerKilometer = double.Parse(truckInfo[2]);

            Car car = new Car(carFuelQuantity, carLitersPerKilometer);
            Truck truck = new Truck(truckFuelQuantity, truckLitersPerKilometer);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = command[0];
                string vehicle = command[1];
                double value = double.Parse(command[2]);

                IVehicle currentVehicle = null;

                if (vehicle == "Car")
                {
                    currentVehicle = car;
                }
                else
                {
                    currentVehicle = truck;
                }
                if (action == "Drive")
                {

                    if (currentVehicle.CanDrive(value))
                    {
                        currentVehicle.Drive(value);
                        Console.WriteLine($"{vehicle} travelled {value} km");
                    }
                    else
                    {
                        Console.WriteLine($"{vehicle} needs refueling");
                    }
                }
                else
                {
                    currentVehicle.Refuel(value);
                }

            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Car: {truck.FuelQuantity:F2}");
        }
    }
}
