using CommonLibrary.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace BestBuyTest.Test
{
    [TestClass]
    public class DatabaseTest
    {
        public static string currentSolutionDirectory;
        public static string currentProjectDirectory;
        static IConfiguration Configuration;

        DatabaseUtils dbUtils;

        [AssemblyInitialize]
        public static void PreSetup(TestContext context)
        {
            string currentWorkingDirectory = Environment.CurrentDirectory;

            currentProjectDirectory = Directory.GetParent(currentWorkingDirectory).Parent.Parent.FullName;

            currentSolutionDirectory = Directory.GetParent(currentWorkingDirectory).Parent.Parent.Parent.FullName;

            Configuration = new ConfigurationBuilder().AddJsonFile(currentProjectDirectory + "/appSettings.json").Build();

        }

        [TestInitialize]
        public void Setup()
        {
            dbUtils = new DatabaseUtils();

            string dataSource = Configuration["datebaseDetails:testCompleteDetails:dataSource"];
            string userId = Configuration["datebaseDetails:testCompleteDetails:userId"];
            string password = Configuration["datebaseDetails:testCompleteDetails:password"];
            string dbName = Configuration["datebaseDetails:testCompleteDetails:dbName"];

            dbUtils.CreateConnection(dataSource, userId, password, dbName);
        }

        [TestMethod]
        public void VerifySelectData()
        {
            var sqlQuery = "select * from OrdersTestData";

            var dataTable = dbUtils.ExecuteSelectQuery(sqlQuery);

            foreach(DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"Product name : {row["productName"]} , Quantity : {row["quantity"]}");
            }


        }

        [TestMethod]
        public void VerifyNonSelectData()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Insert into ");
            builder.Append("OrdersTestData (productName, quantity,price, orderDate, customerName, streetNumber, city, state, zipCode, cardNumber, cardType, expirationDate) ");
            builder.Append("Values ");
            builder.Append("('ScreenSaver', 5, 100, '06/04/2020', 'Saurabh Dhingra', 12, 'Gurgaon', 'Haryana', '122001', '324523452364', 'Visa', '06/06/2020')");

            string sqlQuery = builder.ToString();

            int rowsAffected = dbUtils.ExecuteNonSelectQuery(sqlQuery);

            Assert.AreEqual(1, rowsAffected);
        }

        [TestCleanup]
        public void Cleanup()
        {
            dbUtils.CloseConnection();
        }
    }
}
