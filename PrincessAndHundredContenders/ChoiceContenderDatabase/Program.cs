// See https://aka.ms/new-console-template for more information

using ChoiceContender;
using Npgsql;

var cs = "Host=localhost;Username=postgres;Password=s$cret;Database=testdb";

// The using statement releases the database connection resource when the variable goes out of scope. 
using var con = new NpgsqlConnection(cs);
con.Open();