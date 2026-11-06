Console.OutputEncoding = System.Text.Encoding.UTF8;

List<Vehicle> vehicles = new List<Vehicle>();

vehicles.Add(new Car("Toyota", "Camry", 2020, 0, 5, 8));
vehicles.Add(new Car("Lada", "Vesta", 2018, 60, 5, 8));
vehicles.Add(new Truck("KAMAZ", "5490", 2019, 0, 20000));
vehicles.Add(new Truck("Volvo", "FH", 2012, 0, 25000));
vehicles.Add(new Bus("MAN", "Lion's City", 2021, 0, 40));
vehicles.Add(new Bus("Ikarus", "280", 1995, 0, 60));

double cargoWeight = 15000;
int passengersToBoard = 30;

for (int round = 1; round <= 2; round++)
{
    Console.WriteLine("=== Раунд " + round + " ===");
    Console.WriteLine();

    foreach (Vehicle v in vehicles)
    {
        string name = v.Brand + " " + v.Model;

        if (v is Car car)
        {
            if (car.OpenTrunk())
            {
                Console.WriteLine("Легковой " + name + ": багажник открыт");
            }
            else
            {
                Console.WriteLine("Легковой " + name + ": отказ, нельзя открыть багажник на скорости " + car.Speed + " км/ч");
            }
        }
        else if (v is Truck truck)
        {
            if (truck.LoadCargo(cargoWeight))
            {
                Console.WriteLine("Грузовой " + name + ": загружено " + cargoWeight + " кг, груз " + truck.CurrentLoad + " из " + truck.LoadCapacity + " кг");
            }
            else
            {
                double free = truck.LoadCapacity - truck.CurrentLoad;
                Console.WriteLine("Грузовой " + name + ": отказ, превышена грузоподъёмность (свободно " + free + " кг)");
            }
        }
        else if (v is Bus bus)
        {
            if (bus.BoardPassengers(passengersToBoard))
            {
                Console.WriteLine("Автобус " + name + ": село " + passengersToBoard + " пассажиров, в автобусе " + bus.PassengersCount + " из " + bus.SeatsCount);
            }
            else
            {
                int freeSeats = bus.SeatsCount - bus.PassengersCount;
                Console.WriteLine("Автобус " + name + ": отказ, не хватает мест (свободно " + freeSeats + ")");
            }
        }
        else
        {
            Console.WriteLine(name + ": для этого типа операций нет");
        }
    }

    Console.WriteLine();
}

Console.WriteLine("=== Проверка некорректных значений ===");
Console.WriteLine();

Truck testTruck = new Truck("MAZ", "6430", 2018, 0, 10000);
Bus testBus = new Bus("Ikarus", "256", 1990, 0, 20);

if (!testTruck.LoadCargo(-500))
{
    Console.WriteLine("Грузовик: отказ, вес груза должен быть больше 0");
}

if (!testBus.BoardPassengers(0))
{
    Console.WriteLine("Автобус: отказ, количество пассажиров должно быть больше 0");
}
