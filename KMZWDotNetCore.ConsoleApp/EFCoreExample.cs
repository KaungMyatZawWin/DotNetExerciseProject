using KMZWDotNetCore.ConsoleApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMZWDotNetCore.ConsoleApp
{
    public class EFCoreExample
    {
        #region ReadMethod
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var model = db.Blog.Where(x => x.DeleteFlag == 0).ToList();
            foreach (var item in model)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("------------------------");
            }
        }
        #endregion

        #region CreateMethod
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
            db.Blog.Add(blog);
            var model = db.SaveChanges();

            string result = model == 1 ? "Successfully Create New Blog." : "Failed To Create!";
            Console.WriteLine(result);
        }
        #endregion

        #region UpdateMethod
        public void Update()
        {
            Console.Write("Enter BlogId To Find: ");
            string idStr = Console.ReadLine()!;
            int blogId = int.Parse(idStr);

            AppDbContext db = new AppDbContext();

            var item = db.Blog.AsNoTracking().FirstOrDefault(x => x.BlogId == blogId);
            if (item is null)
            {
                Console.WriteLine("Item not found !");
                return;
            }

            Console.Write("Enter Author Name: ");
            string name = Console.ReadLine()!;
            Console.Write("Enter Author Title: ");
            string title = Console.ReadLine()!;
            Console.Write("Enter Author Content: ");
            string content = Console.ReadLine()!;

            if (!string.IsNullOrEmpty(name))
            {
                item.BlogAuthor = name;
            }

            if (!string.IsNullOrEmpty(title))
            {
                item.BlogTitle = title;
            }

            if (!string.IsNullOrEmpty(content))
            {
                item.BlogContent = content;
            }

            db.Entry(item).State = EntityState.Modified;
            var model = db.SaveChanges();

            string result = model == 1 ? "Successfylly Updated!" : "Failed to Update!";
            Console.WriteLine(result);
        }
        #endregion

        public void Delete()
        {
            Console.Write("Enter BlogId To Find: ");
            string idStr = Console.ReadLine()!;
            int blogId = int.Parse(idStr);

            AppDbContext db = new AppDbContext();
            var item = db.Blog.AsNoTracking().FirstOrDefault(x => x.BlogId == blogId);
            if (item is null)
            {
                Console.WriteLine("Item not found!");
                return;
            }

            db.Entry(item).State = EntityState.Deleted;
            var model = db.SaveChanges();

            string result = model == 1 ? "Successfully Deleted. " : "Failed to Delete!";

            Console.WriteLine(result);
        }

    }
}
