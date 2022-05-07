using System;

namespace Vehicle
{
    public abstract class BaseWaterVehicle: IVehicle
    {
        private VehicleState _state;
        private EnvironmentType _type;
        private float _speed;
        public IEngine Engine { get; protected set; }
        public float Displacement { get; protected set; }

        protected BaseWaterVehicle(float displacement, IEngine engine = null)
        {
            Displacement = displacement;
            _type = EnvironmentType.Water;
            _state = VehicleState.Staying;
            _speed = 0;
            if (engine != null && engine.Fuel != FuelType.Oil)
            {
                throw new Exception("Water Vehicle Should Only Have Oil Powered Engine");
            }
            else
            {
                Engine = engine;
            }
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

        public virtual void StartLanding()
        {
            ((IVehicle)this).ChangeEnvironmentType(EnvironmentType.Land);
        }
        
        public virtual void StartSplashdown()
        {
            ((IVehicle)this).ChangeEnvironmentType(EnvironmentType.Water);
        }
        
        

        public override string ToString()
        {
            return $"Typ: {this.GetType()};\n" +
                   $"Rodzaj: Morski;\n" +
                   $"Środowisko: {_type};\n" +
                   $"Stan: {_state};\n" +
                   $"Min/Max Prędkość: {((IVehicle)this).GetMinSpeed()}\\{((IVehicle)this).GetMaxSpeed()} {((IVehicle)this).GetMetricUnit()}\n" +
                   $"Aktualna Prędkość: {_speed} {((IVehicle)this).GetMetricUnit()};\n" +
                   $"Czy ma silnik: {Engine != null}";
        }
    }
}