using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace CRS
{
    internal class ClientHandler
    {
        private List<Client> clients = new List<Client>();

        public void AddClient(Client newClient)
        {
            clients.Add(newClient);
        }

        public Client? FindClient(Guid clientId)
        {
            return clients.Find(c => c.ClientID == clientId);
        }

        public List<Client> FindClients(string query)
        {
            return clients
                .Where(c =>
                    c.ClientID.ToString().Contains(query) ||
                    c.Name.Contains(query) ||
                    c.Address.Contains(query) ||
                    c.Email.Contains(query) ||
                    c.PhoneNumber.Contains(query) ||
                    c.ProductCategory.ToLower().Contains(query))
                .ToList();
        }

        public void RemoveClient(Guid clientId)
        {
            Client? clientToRemove = clients.Find(c => c.ClientID == clientId);
            if (clientToRemove != null)
            {
                clients.Remove(clientToRemove);
            }
        }

        public List<Client> GetAllClients()
        {
            return clients;
        }

        public void SaveToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                foreach (var client in clients)
                {
                    writer.WriteLine($"{client.ClientID},{client.Name},{client.Address},{client.PhoneNumber},{client.Email},{client.ProductCategory}");
                }
            }
        }

        public void LoadFromFile(string fileName)
        {
            // Clear clients so they don't duplicate
            clients.Clear();
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {

                        string[] clientData = line.Split(',');
                        Client newClient = new Client
                        {
                            Name = clientData[1],
                            Address = clientData[2],
                            PhoneNumber = clientData[3],
                            Email = clientData[4],
                            ProductCategory = clientData[5]
                        };
                        this.AddClient(newClient);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
