using System;
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
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();
            Console.WriteLine("Connection was closed!");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blog Id ==> " + dr["BlogId"]);
                Console.WriteLine("Blog Aurthor ==> " + dr["BlogAurthor"]);
                Console.WriteLine("Blog Title ==> " + dr["BlogTitle"]);
                Console.WriteLine("Blog Content ==> " + dr["BlogContent"]);
                Console.WriteLine("--------------------------------------------");
            }
        }

    }
}
