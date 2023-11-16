using Holy_locket.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Xml.Linq;
using System.Configuration;


string constr = System.Configuration.ConfigurationManager.ConnectionStrings["connString"].ToString();

Console.WriteLine(args.Length);
var contextOptions = new DbContextOptionsBuilder<HolyLocketContext>()
.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=holy_locket;Trusted_Connection=True;TrustServerCertificate=True;")
.Options;
using var context = new HolyLocketContext(contextOptions);
context.Database.EnsureCreated();
context.Database.CanConnect();
Console.WriteLine("123");