using System.Collections.ObjectModel;

namespace _04_EntityFramework.Entity
{
    public class Flight
    {
        public int Id { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartireTime { get; set; }
        public string AeeivalCity { get; set; }
        public string DepartireCity { get; set; }
        public AirPlane AirPlane { get; set; }
        public int AirPlaneId { get; set; }
        public Collection<Client> Clients { get; set; }
    }
}
