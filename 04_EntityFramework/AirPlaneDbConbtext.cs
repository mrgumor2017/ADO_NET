using _04_EntityFramework.Entity;
using Microsoft.EntityFrameworkCore;

namespace _04_EntityFramework
{
    public class AirPlaneDbConbtext : DbContext
    {
        public AirPlaneDbConbtext()
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<AirPlane> AirPlanes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog=AirportDb;
                                        Integrated Security=True;
                                        Connect Timeout=2;Encrypt=False;
                                        Trust Server Certificate=False;
                                        Application Intent=ReadWrite;
                                        Multi Subnet Failover=False");
        }
    }
}
