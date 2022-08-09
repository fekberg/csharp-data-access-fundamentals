using Microsoft.Data.Sqlite;
using System.Data.SqlClient;

/// TODO
/// CHANGE Data Source TO POINT TO THE DATABASE FILE (db)
/// HAS TO BE THE EXACT PATH
using SqliteConnection connection 
    = new SqliteConnection(@"Data Source=warehouse.db;Integrated Security=True;Connect Timeout=30");

using SqliteCommand command
    = new SqliteCommand("SELECT * FROM [Orders]", connection);

connection.Open();

using SqliteDataReader reader =
    command.ExecuteReader();

while(reader.Read())
{
    Console.WriteLine(reader["Id"]);
}

Console.ReadLine();