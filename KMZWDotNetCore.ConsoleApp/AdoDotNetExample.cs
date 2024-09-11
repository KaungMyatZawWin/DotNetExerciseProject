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

        public void Create(string aurthorName,string title, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("Connection is open.");

            string queryString = @"INSERT INTO [dbo].[Tbl_Blog]
                                       ([BlogTitle]
                                       ,[BlogContent]
                                       ,[BlogAurthor])
                                        VALUES
                                       (@title
                                       ,@content
                                       ,@aurthor)";

            SqlCommand cmd = new SqlCommand(queryString,connection);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@content", content);
            cmd.Parameters.AddWithValue("@aurthor", aurthorName);

            int result = cmd.ExecuteNonQuery();


            connection.Close();
            Console.WriteLine("Connection was closed!");

            string message = result > 0 ? "Successfully created new blog." : "Faild to create!";
            Console.WriteLine(message);
        }

        public void Update(int blogId, string aurthor , string blogTitle , string blogContent)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("Connection is open.");

            string queryString = @"UPDATE [dbo].[Tbl_Blog]
               SET [BlogTitle] = @BlogTitle
                  ,[BlogContent] = @BlogContent
                  ,[BlogAurthor] = @BlogAurthor
             WHERE BlogId= @BlogId";

            SqlCommand cmd = new SqlCommand(queryString,connection);
            cmd.Parameters.AddWithValue("@BlogId", blogId);
            cmd.Parameters.AddWithValue("@BlogTitle", blogTitle);
            cmd.Parameters.AddWithValue("@BlogContent", blogContent);
            cmd.Parameters.AddWithValue("@BlogAurthor", aurthor);

            int result = cmd.ExecuteNonQuery();

            connection .Close();
            Console.WriteLine("Connection was closed!");

            Console.WriteLine(result == 1 ? "Successfully updated blog." : "Failed to update!");
        }


        public void Delete(int blogId) 
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("Connection is open.");

            string queryString = @"DELETE FROM [dbo].[Tbl_Blog]
                    WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(queryString, connection);
            cmd.Parameters.AddWithValue("@BlogId", blogId);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            Console.WriteLine("Connection was closed!");

            Console.WriteLine(result == 1 ? "Successfully Deleted Blog." : "Failed to Delete!");

        }
    }   
}
