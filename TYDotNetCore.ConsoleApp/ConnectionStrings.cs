﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYDotNetCore.ConsoleApp
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
