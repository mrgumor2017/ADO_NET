using System.Data.SqlClient;
using System.Text;

namespace _01_ConnectiomMode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString =@"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog=Sales;
                                        Integrated Security=True;
                                        Connect Timeout=30;Encrypt=False;";
                                        
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            Console.WriteLine("Connection Success!!");

            #region Execute Reader for Customers
            string cmdText = @"SELECT * FROM Customers";
            Console.WriteLine("\n-------------------------------------------------------\n\t\tCustomers");
            Console.WriteLine("-------------------------------------------------------");

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            Console.OutputEncoding = Encoding.UTF8;

            // Відображаємо назви всіх колонок таблиці Customers
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),14}");
            }
            Console.WriteLine("\n-------------------------------------------------------");

            // Відображаємо всі значення кожного рядка таблиці Customers
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],14} ");
                }
                Console.WriteLine();
            }

            reader.Close(); // Закриваємо reader перед наступним запитом
            #endregion

            #region Execute Reader for Sellers
            cmdText = @"SELECT * FROM Sellers";
            Console.WriteLine("\n-------------------------------------------------------\n\t\tSellers");
            Console.WriteLine("\n-------------------------------------------------------");

            command = new SqlCommand(cmdText, sqlConnection); // Оновлюємо команду

            reader = command.ExecuteReader(); // Виконуємо новий запит

            // Відображаємо назви всіх колонок таблиці Sellers
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),14}");
            }
            Console.WriteLine("\n-------------------------------------------------------");

            // Відображаємо всі значення кожного рядка таблиці Sellers
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],14} ");
                }
                Console.WriteLine();
            }

            reader.Close(); // Закриваємо reader після завершення

            #endregion

            #region Execute Reader for Sellssers
            string firstName = "Andrew";  // ім'я продавця
            string lastName = "Shevchenko";  // прізвище продавця

            cmdText = @"SELECT Sales.SaleID, Sales.SaleAmount, Sales.SaleDate, Sellers.FirstName, Sellers.LastName
                   FROM Sales
                   JOIN Sellers ON Sales.SellerID = Sellers.SellerID
                   WHERE Sellers.FirstName = @FirstName AND Sellers.LastName = @LastName";

            command = new SqlCommand(cmdText, sqlConnection);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Sale ID: {reader["SaleID"]}, Amount: {reader["SaleAmount"]}, Date: {reader["SaleDate"]}, Seller: {reader["FirstName"]} {reader["LastName"]}");
            }

            reader.Close();
            #endregion
            sqlConnection.Close();
        }
    }
}
