using KMZWDotNetCore.ConsoleApp.Model;
using Microsoft.EntityFrameworkCore;
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

        public void Update()
        {
            Console.Write("Enter BlogId To Find: ");
            string idStr = Console.ReadLine()!;
            int blogId = int.Parse(idStr);

            
            AppDbContext db = new AppDbContext();
            var item  = db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == blogId);

            if (item is null)
            {
                Console.WriteLine("Blog not found!");
                return;
            }

            Console.WriteLine("------------------------");
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("------------------------");

            Console.Write("Enter Author Name: ");
            string name = Console.ReadLine()!;
            Console.Write("Enter Author Title: ");
            string title = Console.ReadLine()!;
            Console.Write("Enter Author Content: ");
            string content = Console.ReadLine()!;

            if(!string.IsNullOrEmpty(name))
            {
                item.BlogAuthor = name;
            }

            if(!string.IsNullOrEmpty(title))
            {
                item.BlogTitle = title; 
            }

            if(!string.IsNullOrEmpty(content))
            {
                item.BlogContent = content;
            }

            db.Entry(item).State = EntityState.Modified;
            var model = db.SaveChanges();

            string result = model == 1 ? "Successfully updated. " : "Failed to update";

            Console.WriteLine(result);

        }

        public void Delete()
        {
            Console.Write("Enter BlogId To Find: ");
            string idStr = Console.ReadLine()!;
            int blogId = int.Parse(idStr);

            AppDbContext db = new AppDbContext();
            var item = db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == blogId);
            if(item is null)
            {
                Console.WriteLine("Item not found!");
                return;
            };

            db.Entry(item).State = EntityState.Deleted;
            var model  = db.SaveChanges();

            string result = model == 1 ? "Successfully Deleted." : "Failed to Delete!";
            Console.WriteLine(result);
        }

    }
}
