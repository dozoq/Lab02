using System;

namespace Vehicle
{
    public interface IVehicle
    {
        public       VehicleState State { get; protected set; }
        public       EnvironmentType Type { get; protected set; }
        public float Speed{ get; protected set; }
        
        public void Move()
        {
            
        }

        public void ChangeEnvironmentType(EnvironmentType type)
        {
            float convertedSpeed = ConvertToEnvironmentType(this.Speed, this.Type, type);
            Type = type;
            Speed = Math.Clamp(convertedSpeed, State == VehicleState.Staying?0:GetMinSpeed(), State == VehicleState.Staying?0:GetMaxSpeed());
        }

        public void AdjustSpeed(float value)
        {
            if(State == VehicleState.Moving)
                Speed = Math.Clamp(Speed + value, GetMinSpeed(), GetMaxSpeed());
        }

        public void Stop();
        public void Start();

        public float GetMaxSpeed()
        {
            switch (Type)
            {
                case EnvironmentType.Land:
                    return 350;
                case EnvironmentType.Air:
                    return 200;
                case EnvironmentType.Water:
                    return 40;
                default:
                    throw new Exception("Not Supported Environment Type");
            }
        }
        public float GetMinSpeed()
        {
            switch (Type)
            {
                case EnvironmentType.Air:
                    return 20;
                case EnvironmentType.Land:
                    return 1;
                case EnvironmentType.Water:
                    return 1;
                default:
                    throw new Exception("Not Supported Environment Type");
            }
        }

        public string GetMetricUnit()
        {
            switch (Type)
            {
                case EnvironmentType.Land:
                    return "km/h";
                case EnvironmentType.Air:
                    return "m/s";
                case EnvironmentType.Water:
                    return "knot/h";
                default:
                    throw new Exception("Not Supported Environment Type");
            }
        }

        public static float ConvertToEnvironmentType(float value, EnvironmentType fromType, EnvironmentType toType)
        {
            switch (fromType)
            {
                case EnvironmentType.Air:
                    switch (toType)
                    {
                        case EnvironmentType.Air:
                            return value;
                        case EnvironmentType.Land:
                            return value*3.6f;
                        case EnvironmentType.Water:
                            return value*1.9438f;
                        default:
                            throw new Exception("Not Supported Environment Type");
                    }
                case EnvironmentType.Water:
                    switch (toType)
                    {
                        case EnvironmentType.Air:
                            return value*0.51444f;
                        case EnvironmentType.Land:
                            return value*1.85200f;
                        case EnvironmentType.Water:
                            return value;
                        default:
                            throw new Exception("Not Supported Environment Type");
                    }
                case EnvironmentType.Land:
                    switch (toType)
                    {
                        case EnvironmentType.Air:
                            return value*0.27777f;
                        case EnvironmentType.Land:
                            return value;
                        case EnvironmentType.Water:
                            return value*0.53995f;
                        default:
                            throw new Exception("Not Supported Environment Type");
                    }
                default:
                    throw new Exception("Not Supported Environment Type");
            }
        }
    }

    public enum VehicleState
    {
        Moving, Staying
    }

    public enum EnvironmentType
    {
        Land, Water, Air
    }
}