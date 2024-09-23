using Dapper;
using KMZWDotNetCore.ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMZWDotNetCore.ConsoleApp
{
    public class DapperExample
    {
        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch5",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true,
        };

        public void Read()
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                string query = "select * from Tbl_Blog where DeleteFlag=0";
                var lst = db.Query<BlogDataModel>(query).ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogContent);
                }
            }
        }

        public void Create()
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                Console.Write("Enter Author Name: ");
                string name = Console.ReadLine()!;
                Console.Write("Enter Author Title: ");
                string title = Console.ReadLine()!;
                Console.Write("Enter Author Content: ");
                string content = Console.ReadLine()!;

                string query = @"INSERT INTO [dbo].[Tbl_Blog]
                                       ([BlogTitle]
                                       ,[BlogContent]
                                       ,[BlogAuthor],[DeleteFlag])
                                        VALUES
                                       (@BlogTitle
                                       ,@BlogContent
                                       ,@BlogAuthor,@DeleteFlag)";

                int lst = db.Execute(query, new BlogDataModel { BlogTitle = title, BlogContent = content, BlogAuthor = name, DeleteFlag = 0 });

                string result = lst > 0 ? "Successfully Created New Blog. " : "Failed To Create!";
                Console.WriteLine(result);
            }
        }

        public void Update()
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                Console.Write("Enter BlogId To Find: ");
                string idStr = Console.ReadLine()!;
                int blogId = int.Parse(idStr);

                string findQuery = "select * from Tbl_Blog where BlogId = @BlogId ";
                var model = db.QueryFirstOrDefault<BlogDataModel>(findQuery, new BlogDataModel { BlogId = blogId });


                Console.WriteLine(model.BlogAuthor);
                if (model is null)
                {
                    Console.WriteLine("Blog Doesn't exit!");
                    return;
                }

                Console.Write("Enter Author Name: ");
                string name = Console.ReadLine()!;
                Console.Write("Enter Author Title: ");
                string title = Console.ReadLine()!;
                Console.Write("Enter Author Content: ");
                string content = Console.ReadLine()!;

                string query = @"UPDATE [dbo].[Tbl_Blog]
                  SET [BlogTitle] = @BlogTitle
                     ,[BlogContent] = @BlogContent
                     ,[BlogAuthor] = @BlogAuthor
                WHERE BlogId= @BlogId";

                var resp = db.Execute(query, new { BlogTitle = title, BlogContent = content, BlogAuthor = name, BlogId = blogId });
                string result = resp == 1 ? "Successfully updated. " : "Update Failed!";
                Console.WriteLine(result);
            }
        }

        public void Delete()
        {
            using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                Console.Write("Enter BlogId To Find: ");
                string idStr = Console.ReadLine()!;
                int blogId = int.Parse(idStr);

                string findQuery = "select * from Tbl_Blog where BlogId = @BlogId ";
                var model = db.QueryFirstOrDefault<BlogDataModel>(findQuery, new BlogDataModel { BlogId = blogId });

                string query = @"DELETE FROM [dbo].[Tbl_Blog]
                    WHERE BlogId=@BlogId";
                int resp = db.Execute(query,new {BlogId =  blogId});
                string result = resp == 1 ? "Successfully Deleted!" : "Failed to Delete!";
                Console.WriteLine(result);
            }
        }
    }
}
