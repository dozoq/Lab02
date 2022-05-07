namespace Vehicle
{
    public class OilEngine : IEngine
    {
        private int _power = 5;
        private FuelType _fuel = FuelType.Oil;

        int IEngine.Power
        {
            get => _power;
            set => _power = value;
        }

        FuelType IEngine.Fuel
        {
            get => _fuel;
            set => _fuel = value;
        }
    }
    
    public class Car : BaseLandVehicle
    {
        
        public Car() : base(5, new OilEngine())
        {
        }
    }
    
    public class Skateboard : BaseLandVehicle
    {
        public Skateboard() : base(4)
        {
        }
    }

    public class Ship : BaseWaterVehicle
    {
        public Ship() : base(15, new OilEngine())
        {
        }
    }
    
    public class Aircraft : BaseAirVehicle
    {
        public Aircraft() : base(new OilEngine())
        {
        }
    }

    public class Paraglider : BaseAirVehicle
    {
    }
}