using System.Collections.ObjectModel;

namespace _04_EntityFramework.Entity
{
    public class AirPlane
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int MaxPassanger { get; set; }
        public Collection<Flight> Flights { get; set; }

    }
}
