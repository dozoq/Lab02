using System;

namespace Vehicle
{
    public abstract class BaseAirVehicle: IVehicle
    {
        private VehicleState _state;
        private EnvironmentType _type;
        private float _speed;
        public IEngine Engine { get; protected set; }
        public bool IsInAir { get; protected set; }

        protected BaseAirVehicle(IEngine engine = null)
        {
            _type = EnvironmentType.Air;
            _state = VehicleState.Staying;
            _speed = 0;
            Engine = engine;
            IsInAir = false;
        }

        public virtual void StartLanding()
        {
            if(_speed <= ((IVehicle)this).GetMinSpeed())
                IsInAir = false;
            else
                Console.WriteLine("Too high speed to stop flying");
        }
        public virtual void StartFlying()
        {
            if(_speed >=((IVehicle)this).GetMinSpeed())
                IsInAir = true;
            else
                Console.WriteLine("Too low speed to start flying");
        }

        VehicleState IVehicle.State
        {
            get => _state;
            set => _state = value;
        }

        EnvironmentType IVehicle.Type
        {
            get => _type;
            set => _type = value;
        }

        float IVehicle.Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public void Stop()
        {
            if (!IsInAir)
            {
                _state = VehicleState.Staying;
                _speed = 0;
            }
        }

        public void Start()
        {
            if (!IsInAir)
            {
                _state = VehicleState.Moving;
                _speed = ((IVehicle)this).GetMinSpeed();
            }
        }
        
        public override string ToString()
        {
            return $"Typ: {this.GetType()};\n" +
                   $"Rodzaj: Powietrzny;\n" +
                   $"Środowisko: {_type};\n" +
                   $"Stan: {_state};\n" +
                   $"Min/Max Prędkość: {((IVehicle)this).GetMinSpeed()}\\{((IVehicle)this).GetMaxSpeed()} {((IVehicle)this).GetMetricUnit()}\n" +
                   $"Aktualna Prędkość: {_speed} {((IVehicle)this).GetMetricUnit()};\n" +
                   $"Czy ma silnik: {Engine != null}";
        }
    }
}