using System.Text;

namespace _02_CRUD_interface
{



    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SportShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            SportShopDb sportShop = new SportShopDb(connectionString);
            Product pr = new Product()
            {
                Name = "Ball",
                Type = "Equipment",
                Quantity = 10,
                CostPrice = 100,
                Producer = "China",
                Price = 200
            };
            //sportShop.Create(pr);
            Console.WriteLine("Enter name of product to search : ");
            string name = Console.ReadLine()!;
            var products = sportShop.GetByName(name);
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

            sportShop.Delete(47);

            var changeProduct = sportShop.GetById(3);
            changeProduct.Price += 500;
            changeProduct.CostPrice += 300;
            sportShop.Update(changeProduct);
        }
    }
}
