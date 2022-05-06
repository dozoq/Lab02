namespace Vehicle
{
    public interface IEngine
    {
        public int      Power { get; protected set; }
        public FuelType Fuel  { get; protected set; }
    }

    public enum FuelType
    {
        Gasolin, Oil, LPG, Electricity
    }
}