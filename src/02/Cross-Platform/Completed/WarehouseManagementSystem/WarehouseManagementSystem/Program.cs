using System.Data.SqlClient;

using SqlConnection connection 
    = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Code\WarehouseManagement.mdf;Integrated Security=True;Connect Timeout=30");

using SqlCommand command
    = new SqlCommand("SELECT * FROM [Orders]", connection);

connection.Open();

using SqlDataReader reader =
    command.ExecuteReader();

while(reader.Read())
{
    Console.WriteLine(reader["Id"]);
}

Console.ReadLine();