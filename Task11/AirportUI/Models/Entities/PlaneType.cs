namespace AirportUI.Models.Entities
{
    public class PlaneType
    {
        public long Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int CargoCapacity { get; set; }

        public PlaneType Clone() => (PlaneType)MemberwiseClone();
    }
}
