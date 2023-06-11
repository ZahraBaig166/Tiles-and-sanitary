using System;
using System.Data.SqlClient;
using Bogus;

namespace SupplierDataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=ZAHRA-PC\\SQLEXPRESS;Initial Catalog=TilesandSanitary;Integrated Security=True";

            // Create Faker instance
            var faker = new Faker();

            // Establish database connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Call insertion method for Suppliers
                InsertSupplierData(connection, faker);
            }

            Console.WriteLine("Data generation completed.");
            Console.ReadLine();
        }

        private static void InsertSupplierData(SqlConnection connection, Faker faker)
        {
            string insertQuery = "INSERT INTO Supplier (SupplierID, SupplierName, ContactInformation) VALUES (@SupplierID, @SupplierName, @ContactInformation)";

            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                for (int i = 1; i <= 150; i++)
                {
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@SupplierID", i);
                    command.Parameters.AddWithValue("@SupplierName", faker.Company.CompanyName());
                    command.Parameters.AddWithValue("@ContactInformation", "+92 3" + faker.Random.Number(0, 4) + faker.Random.Number(0, 9) + " " + faker.Random.Number(1000000, 9999999));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}