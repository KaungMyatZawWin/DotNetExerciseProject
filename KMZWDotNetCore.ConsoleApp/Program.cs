// See https://aka.ms/new-console-template for more information

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

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("John Doe","Testing Title","This is content");
//adodotnetexample.update(12, "update john doe", "update title", "update content");
//adoDotNetExample.Delete(12);
//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Create();
//dapperExample.Update();
//dapperExample.Delete();

EFCoreExample efcore = new EFCoreExample();
//efcore.Read();
//efcore.Create();
//efcore.Update();
//efcore.Delete();

int option;

do
{
    Console.WriteLine("Select One optin ( Only type number )");
    Console.Write("1 To See All Blog , 2 To Create Blog , 3 To Update Blog , 4 To Delete Blog :");
    string numStr = Console.ReadLine()!;
    option = int.Parse(numStr);

    switch (option)
    {
        case 1:
            efcore.Read();
            break;
        case 2:
            efcore.Create();
            break;
        case 3:
            efcore.Update();
            break;
        case 4:
            efcore.Delete();
            break;
        default:
            Console.WriteLine("Please Only Select Within 1 to 4 !");
            option = 1;
            break;

    }

}
while (option == 1 || option == 2 || option == 3 || option == 4);
