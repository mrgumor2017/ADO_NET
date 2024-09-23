using System.Collections.ObjectModel;

namespace _04_EntityFramework
{
    
        internal class Program
    {
        static void Main(string[] args)
        {
            AirPlaneDbConbtext dbContext = new AirPlaneDbConbtext();
            dbContext.Clients.Add(new Client()
            {
                Name = "Max",
                Email = "vova@gmail.com",
                Birthday = new DateTime(2000, 5, 12)
            });
            dbContext.SaveChanges();

            foreach (var client in dbContext.Clients)
            {
                Console.WriteLine($"{client.Name} . {client.Email} . {client.Birthday}");
            }
        }
    }
}
