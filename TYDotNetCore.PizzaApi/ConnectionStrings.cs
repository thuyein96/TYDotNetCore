﻿
using System.Data.SqlClient;

namespace TYDotNetCore.PizzaApi
{
    internal class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetCoreTrainingBatch4",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true
        };

    }
}
