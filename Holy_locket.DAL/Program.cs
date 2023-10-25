// See https://aka.ms/new-console-template for more information
using Holy_locket.DAL.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
internal class Program
{
    private static void Main(string[] args)
    {
              Console.WriteLine("Hello, World!");

        var connection =
      System.Configuration.ConfigurationManager.
      ConnectionStrings["connString"].ConnectionString;
        var db = new HolyLocketContext();
        
        SqlConnection con = new SqlConnection(connection);
        con.Open();
    }
}