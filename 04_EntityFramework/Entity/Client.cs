using System.Collections.ObjectModel;

namespace _04_EntityFramework.Entity
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public Collection<Flight> Flights { get; set; }
    }
}
