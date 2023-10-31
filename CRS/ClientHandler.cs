using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace CRS
{
    internal class ClientHandler
    {
        private string connectionString;

        public ClientHandler(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddClient(Client newClient)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO clients (ClientID, Name, Address, PhoneNumber, Email, ProductCategory) " +
                               "VALUES (@ClientID, @Name, @Address, @PhoneNumber, @Email, @ProductCategory)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ClientID", newClient.ClientID);
                cmd.Parameters.AddWithValue("@Name", newClient.Name);
                cmd.Parameters.AddWithValue("@Address", newClient.Address);
                cmd.Parameters.AddWithValue("@PhoneNumber", newClient.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", newClient.Email);
                cmd.Parameters.AddWithValue("@ProductCategory", newClient.ProductCategory);
                cmd.ExecuteNonQuery();
            }
        }

        public Client? FindClients(Guid clientId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM clients WHERE ClientID = @ClientID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ClientID", clientId);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Client
                        {
                            ClientID = Guid.Parse(reader["ClientID"].ToString()),
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            ProductCategory = reader["ProductCategory"].ToString()
                        };
                    }
                    return null;
                }
            }
        }

        public List<Client> FindClients(string query)
        {
            List<Client> result = new List<Client>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string searchQuery = "%" + query + "%";
                string queryStr = "SELECT * FROM clients " +
                                 "WHERE ClientID LIKE @Query OR Name LIKE @Query OR Address LIKE @Query OR PhoneNumber LIKE @Query OR Email LIKE @Query OR ProductCategory LIKE @Query";
                MySqlCommand cmd = new MySqlCommand(queryStr, connection);
                cmd.Parameters.AddWithValue("@Query", searchQuery);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Client
                        {
                            ClientID = Guid.Parse(reader["ClientID"].ToString()),
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            ProductCategory = reader["ProductCategory"].ToString()
                        });
                    }
                }
            }
            return result;
        }

        public void RemoveClient(Guid clientId)
        {
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM clients WHERE ClientID = @ClientID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@ClientID", clientId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Client> GetAllClients()
        {
            List<Client> result = new List<Client>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM clients";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Client
                        {
                            ClientID = Guid.Parse(reader["ClientID"].ToString()),
                            Name = reader["Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["Email"].ToString(),
                            ProductCategory = reader["ProductCategory"].ToString()
                        });
                    }
                }
            }
            return result;
        }

        public void SaveToFile(string fileName)
        {
            List<Client> clients = this.GetAllClients();

            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                foreach (var client in clients)
                {
                    writer.WriteLine($"{client.ClientID},{client.Name},{client.Address},{client.PhoneNumber},{client.Email},{client.ProductCategory}");
                }
            }
        }
    }
}
