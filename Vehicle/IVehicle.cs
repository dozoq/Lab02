namespace Vehicle
{
    public interface IVehicle
    {
        public       VehicleState State { get; protected set; }
        public       float        Speed { get; protected set; }
        
        public void Move()
        {
            
        }
    }

    public enum VehicleState
    {
        Moving, Staying
    }
}