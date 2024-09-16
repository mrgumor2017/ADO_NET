using System.Data.SqlClient;
using System.Text;

namespace _02_DZ
{
    class Store
    {
        SqlConnection conn;
        public Store(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }
        ~Store()
        {
            conn.Close();
        }

        // Додавання нової продажі з використанням параметризованого запиту
        public void Create(Sales sale)
        {
            string cmdText = @"INSERT INTO Sales (Amount, Sale_date) VALUES (@Amount, @Sale_date)";
            SqlCommand command = new SqlCommand(cmdText, conn);
            command.Parameters.AddWithValue("@Amount", sale.Amount);
            command.Parameters.AddWithValue("@Sale_date", sale.Sale_date);
            command.CommandTimeout = 5;

            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows affected!");
        }

        // Відображення всіх продажів за певний період
        public void GetSalesByPeriod(DateTime startDate, DateTime endDate)
        {
            string cmdText = @"SELECT * FROM Sales WHERE Sale_date BETWEEN @StartDate AND @EndDate";
            SqlCommand command = new SqlCommand(cmdText, conn);
            command.Parameters.AddWithValue("@StartDate", startDate);
            command.Parameters.AddWithValue("@EndDate", endDate);

            SqlDataReader reader = command.ExecuteReader();

            Console.OutputEncoding = Encoding.UTF8;
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader[0]}, Amount: {reader[1]}, Sale Date: {reader[2]}");
            }
            reader.Close();
        }

        // Показ останньої покупки покупця по імені та прізвищу
        public void GetLastSaleByCustomerName(string firstName, string lastName)
        {
            string cmdText = @"SELECT TOP 1 * FROM Sales 
                               JOIN Customers ON Sales.Customer_id = Customers.Id 
                               WHERE Customers.FirstName = @FirstName AND Customers.LastName = @LastName 
                               ORDER BY Sale_date DESC";
            SqlCommand command = new SqlCommand(cmdText, conn);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine($"Last Sale ID: {reader[0]}, Amount: {reader[1]}, Sale Date: {reader[2]}");
            }
            else
            {
                Console.WriteLine("No sales found for this customer.");
            }
            reader.Close();
        }

        // Видалення продавця або покупця по ID
        public void DeleteSaleById(int id)
        {
            string cmdText = @"DELETE FROM Sales WHERE Id = @Id";
            SqlCommand command = new SqlCommand(cmdText, conn);
            command.Parameters.AddWithValue("@Id", id);

            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows deleted!");
        }

        // Показ продавця, загальна сума продаж якого є найбільшою
        public void GetTopSeller()
        {
            string cmdText = @"SELECT TOP 1 Sellers.Name, SUM(Sales.Amount) as TotalSales 
                               FROM Sales 
                               JOIN Sellers ON Sales.Seller_id = Sellers.Id 
                               GROUP BY Sellers.Name 
                               ORDER BY TotalSales DESC";
            SqlCommand command = new SqlCommand(cmdText, conn);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine($"Top Seller: {reader[0]}, Total Sales: {reader[1]}");
            }
            reader.Close();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\\MSSQLLocalDB;
                                        Initial Catalog=Sales;
                                        Integrated Security=True;
                                        Connect Timeout=30;Encrypt=False;";
            Store store = new Store(connectionString);

            
            Console.WriteLine("Виберіть операцію:");
            Console.WriteLine("1. Додати нову продажу");
            Console.WriteLine("2. Показати всі продажі за певний період");
            Console.WriteLine("3. Показати останню покупку певного покупця по імені та прізвищу");
            Console.WriteLine("4. Видалити продавця або покупця по ID");
            Console.WriteLine("5. Показати продавця з найбільшою сумою продаж");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Sales newSale = new Sales
                    {
                        Amount = 1000, 
                        Sale_date = DateTime.Now
                    };
                    store.Create(newSale);
                    break;
                case 2:
                    Console.WriteLine("Введіть початкову дату (yyyy-mm-dd):");
                    DateTime startDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Введіть кінцеву дату (yyyy-mm-dd):");
                    DateTime endDate = DateTime.Parse(Console.ReadLine());
                    store.GetSalesByPeriod(startDate, endDate);
                    break;
                case 3:
                    Console.WriteLine("Введіть ім'я покупця:");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Введіть прізвище покупця:");
                    string lastName = Console.ReadLine();
                    store.GetLastSaleByCustomerName(firstName, lastName);
                    break;
                case 4:
                    Console.WriteLine("Введіть ID продажу для видалення:");
                    int id = int.Parse(Console.ReadLine());
                    store.DeleteSaleById(id);
                    break;
                case 5:
                    store.GetTopSeller();
                    break;
                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        }
    }
}
