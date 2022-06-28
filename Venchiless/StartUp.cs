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

            string[] busInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carLitersPerKilometer = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckLitersPerKilometer = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            double busFuelQuantity = double.Parse(truckInfo[1]);
            double busLitersPerKilometer = double.Parse(truckInfo[2]);
            double busTankCapacity = double.Parse(truckInfo[3]);

            Car car = new Car(carTankCapacity, carFuelQuantity, carLitersPerKilometer);
            Truck truck = new Truck(truckTankCapacity, truckFuelQuantity, truckLitersPerKilometer);
            Bus bus = new Bus(busTankCapacity, busFuelQuantity, busLitersPerKilometer);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string action = command[0];
                    string vehicle = command[1];
                    double value = double.Parse(command[2]);

                    IVehicle currentVehicle = GetVehicleType(car, truck, bus, vehicle);


                    if (action == "Drive" || action == "DriveEmpty")
                    {
                        if (action.Contains("Empty"))
                        {
                            bus.IsEmpty = true;
                        }
                        if (currentVehicle.CanDrive(value))
                        {
                            currentVehicle.Drive(value);
                            Console.WriteLine($"{vehicle} travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine($"{vehicle} needs refueling");
                        }
                        bus.IsEmpty = false;

                    }
                    else
                    {
                        if (currentVehicle.CanRefuel(value))
                        {
                            currentVehicle.Refuel(value);
                        }
                        else
                        {
                            Console.WriteLine($"Cannot fit {value} fuel in the tank");
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Car: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }

        private static IVehicle GetVehicleType(Car car, Truck truck, Bus bus, string vehicle)
        {
            if (vehicle == "Car")
            {
                return car;
            }
            else if (vehicle == "Truck")
            {
                return truck;
            }
            return bus;
        }
    }
}
