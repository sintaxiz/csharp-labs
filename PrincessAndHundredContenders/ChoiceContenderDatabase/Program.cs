// See https://aka.ms/new-console-template for more information

using Npgsql;

namespace ChoiceContenderDatabase;

class Program

{
    public static void Main(string[] args)

    {
        Console.WriteLine("ATTEMPT GENERATOR v0.1");
        var cs = "Host=localhost;Username=lumia;Password=admin;Database=princessdb";

        // The using statement releases the database connection resource when the variable goes out of scope. 
        using var con = new NpgsqlConnection(cs);
        con.Open();
    }
}

