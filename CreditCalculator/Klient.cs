using System;
using System.Data;
using System.Data.SqlClient;

public class ClientManagement
{
    private string connectionString = "/l";

    public DataTable GetAllClients()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Clients";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable clientsTable = new DataTable();
            adapter.Fill(clientsTable);
            return clientsTable;
        }
    }

    public void AddClient(string firstName, string lastName, string email)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Clients (FirstName, LastName, Email) VALUES (@FirstName, @LastName, @Email)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Email", email);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void UpdateClient(int clientID, string firstName, string lastName, string email)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "UPDATE Clients SET FirstName = @FirstName, LastName = @LastName, Email = @Email WHERE ClientID = @ClientID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientID", clientID);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Email", email);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public void DeleteClient(int clientID)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "DELETE FROM Clients WHERE ClientID = @ClientID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientID", clientID);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
