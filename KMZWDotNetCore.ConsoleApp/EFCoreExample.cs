using KMZWDotNetCore.ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMZWDotNetCore.ConsoleApp
{
    public class EFCoreExample
    {

        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.Blogs.Where(x=>x.DeleteFlag == 0).ToList();
            foreach (var item in lst)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("------------------------");
            }
        }

        public void Create()
        {
            Console.Write("Enter Author Name: ");
            string name = Console.ReadLine()!;
            Console.Write("Enter Author Title: ");
            string title = Console.ReadLine()!;
            Console.Write("Enter Author Content: ");
            string content = Console.ReadLine()!;

            EFCoreDataModel blog = new EFCoreDataModel
            {
                BlogAuthor = name,
                BlogTitle = title, 
                BlogContent = content
            };

            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            int model = db.SaveChanges();

            string result = model == 1 ? "Scuccessfully Crete New Blog." : "Failed To Create!";
            Console.WriteLine(result);
        }
    }
}
