﻿// See https://aka.ms/new-console-template for more information

using KMZWDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

//SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
//stringBuilder.DataSource = ".";
//stringBuilder.InitialCatalog = "DotNetTrainingBatch4";
//stringBuilder.UserID = "sa";
//stringBuilder.Password = "sasa@123";


//SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
//connection.Open();

//string queryString = "select * from Tbl_Blog";

//SqlCommand cmd = new SqlCommand(queryString,connection);

//SqlDataAdapter adapter = new SqlDataAdapter(cmd);

//DataTable dt = new DataTable();

//adapter.Fill(dt);

//connection.Close();

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine("Blog Id ==> " + dr["BlogId"]);
//    Console.WriteLine("Blog Title ==> " + dr["BlogTitle"]);
//    Console.WriteLine("Blog Content ==> " + dr["BlogContent"]);
//    Console.WriteLine("Blog Aurthor ==> " + dr["BlogAurthor"]);
//}

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
adoDotNetExample.Read();