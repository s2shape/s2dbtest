using System;
using System.Data.SqlClient;
using S2.BlackSwan.SupplyCollector.Ado;
using S2.BlackSwan.SupplyCollector.Models;

namespace S2DbTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString;
            if(args.Length == 1)
            {
                connectionString = args[0];
            }
            else
            {
                Console.WriteLine("Enter connection string:");
                connectionString = Console.ReadLine();
            }
            
            Console.WriteLine("Starting Ado.NET connection test...");
            TestConnectionString(connectionString);

            Console.WriteLine("Starting S2 connection test...");
            S2TestConnectionString(connectionString);

            Console.WriteLine("All tests complete.");
        }

        public static void TestConnectionString(string connectionString)
        {

            using SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                Console.WriteLine("Ado.NET connection test passed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ado.NET connection test failed with message: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public static void S2TestConnectionString(string connectionString)
        {
            var container = new DataContainer()
            {
                ConnectionString = connectionString
            };
            var supply = new SqlServerSupplyCollector();

            try
            {
                var testResult = supply.TestConnection(container);
                Console.WriteLine("S2 connection test passed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("S2 connection test failed with message: " + ex.Message);
            }
        }
    }
}
