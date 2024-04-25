// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using TYDotNetCore.ConsoleApp.AdoDotNetExamples;
using TYDotNetCore.ConsoleApp.DapperDotNetExamples;

Console.WriteLine("Hello, World!");

/* 
Ctrl + . = suggestion
F11 = run into the function step by step
F10 = run line by line
F9 = set breakpoint
*/

/*
SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "THU-YEIN-1996"; //server name
stringBuilder.InitialCatalog = "DotNetCoreTrainingBatch4"; //database name
stringBuilder.UserID = "sa";
stringBuilder.Password = "sa@123";
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
connection.Open();
Console.WriteLine("Connection open.");

// READ DATA FROM DATABASE
string query = "select * from tbl_blog";
SqlCommand cmd = new SqlCommand(query, connection); // put into sql object to be able to recognize as query code
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); // create new query page to run query cmd
DataTable dt = new DataTable(); // create a table object to put data
sqlDataAdapter.Fill(dt); // fill data into table object

connection.Close();
Console.WriteLine("Connection close.");

// dataset => datatable
// datatable => datarow
// datarow => datacolumn

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog Id => " + dr["BlogId"]);
    Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
    Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
    Console.WriteLine("Blog Content => " + dr["BlogContent"]);
    Console.WriteLine("-------------------------------------");
} */

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Create("title", "author", "content");
//adoDotNetExample.Read();
//adoDotNetExample.Update(12, "test title", "test author", "test content");
//adoDotNetExample.Delete(12);
//adoDotNetExample.Edit(212);

DapperDotNetExample dapperDotNetExample = new DapperDotNetExample();
dapperDotNetExample.Run();
Console.ReadKey();
