﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMZWDotNetCore.ConsoleApp
{
   
    internal class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder() {
           DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch4",
            UserID = "sa",
            Password = "sasa@123"
        };

        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("Connection is open.");

            string queryString = "select * from Tbl_Blog";
            SqlCommand cmd = new SqlCommand(queryString,connection);
            
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) {
                Console.WriteLine("Blog Id ==> " + reader["BlogId"]);
                Console.WriteLine("Blog Aurthor ==> " + reader["BlogAurthor"]);
                Console.WriteLine("Blog Title ==> " + reader["BlogTitle"]);
                Console.WriteLine("Blog Content ==> " + reader["BlogContent"]);
                Console.WriteLine("----------------------------------------------");
            }

            connection.Close();
            Console.WriteLine("Connection was closed!");

            
        }

    }
}
