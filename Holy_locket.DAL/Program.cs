using Holy_locket.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    { 
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ToString();
            // Display the number of command line arguments.
            Console.WriteLine(args.Length);
            var contextOptions = new DbContextOptionsBuilder<HolyLocketContext>()
           .UseSqlServer(@"Server=DESKTOP-K7HFUB0\HOLY_LOCKET;Database=Holy_LocketDB;Trusted_Connection=True;TrustServerCertificate=True;")
           .Options;
            using var context = new HolyLocketContext(contextOptions);
            context.Database.EnsureCreated();
               context.Database.Migrate();
        context.Database.CanConnect();
        Console.WriteLine("123");
    }
}