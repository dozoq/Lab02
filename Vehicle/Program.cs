using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle
{
    class Program
    {
        static void Main(string[] args)
        {
            IVehicle car = new Car();
            Console.WriteLine(car.ToString());
            car.Start();
            Console.WriteLine(car.ToString());
            car.AdjustSpeed(50);
            Console.WriteLine(car.ToString());
            car.AdjustSpeed(-51);
            Console.WriteLine(car.ToString());

            BaseAirVehicle airVehicle = new Paraglider();
            Console.WriteLine(airVehicle.ToString());

            IVehicle ship = new Ship();
            Console.WriteLine(ship.ToString());

            List<IVehicle> vehicles = new List<IVehicle>()
            {
                new Car(),
                new Paraglider(),
                new Aircraft(),
                new Ship(),
                new Skateboard()
            };
            
            Random random = new Random();
            Console.WriteLine("---------Lista w kolejności------------");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
                vehicle.Start();
                vehicle.AdjustSpeed(Convert.ToSingle(random.NextDouble()*vehicle.GetMaxSpeed()));
            }

            
            Console.WriteLine("---------Lista tylko lądowe------------");
            foreach (var vehicle in vehicles.Where((x) => x.GetType().IsSubclassOf(typeof(BaseLandVehicle))))
            {
                Console.WriteLine(vehicle.ToString());
            }

            Console.WriteLine("---------Lista po prędkości------------");
            vehicles.Sort(((vehicle, vehicle1) =>
                vehicle.Speed < IVehicle.ConvertToEnvironmentType(vehicle1.Speed, vehicle1.Type, vehicle.Type) ? 1 : -1));
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle.ToString());
            }
            
            
            foreach (var vehicle in vehicles.Where((x) => x.GetType().IsSubclassOf(typeof(BaseWaterVehicle))))
            {
                ((BaseWaterVehicle)vehicle).StartLanding();
            }
            Console.WriteLine("---------Lista po prędkości i tylko w środowisku lądowym------------");
            foreach (var vehicle in vehicles.Where((x) => x.Type == EnvironmentType.Land))
            {
                Console.WriteLine(vehicle.ToString());
            }
        }
    }
}