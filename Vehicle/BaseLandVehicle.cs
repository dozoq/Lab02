using System;
using System.Runtime.CompilerServices;

namespace Vehicle
{
    public abstract class BaseLandVehicle : IVehicle
    {
        private VehicleState _state;
        private EnvironmentType _type;
        private float _speed;
        public IEngine Engine { get; protected set; }
        public int Wheels { get; protected set; }

        protected BaseLandVehicle(int wheels, IEngine engine = null)
        {
            Wheels = wheels;
            _state = VehicleState.Staying;
            _type = EnvironmentType.Land;
            _speed = 0;
            Engine = engine;
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
            _speed = 0;
            _state = VehicleState.Staying;
        }

        public void Start()
        {
            _state = VehicleState.Moving;
            _speed = ((IVehicle)this).GetMinSpeed();
        }

        public override string ToString()
        {
            return $"Typ: {this.GetType()};\n" +
                   $"Rodzaj: Lądowy;\n" +
                   $"Środowisko: {_type};\n" +
                   $"Stan: {_state};\n" +
                   $"Min/Max Prędkość: {((IVehicle)this).GetMinSpeed()}\\{((IVehicle)this).GetMaxSpeed()} {((IVehicle)this).GetMetricUnit()}\n" +
                   $"Aktualna Prędkość: {_speed} {((IVehicle)this).GetMetricUnit()};\n" +
                   $"Liczba Kół: {Wheels};\n" +
                   $"Czy ma silnik: {Engine != null}";
        }
    }
}