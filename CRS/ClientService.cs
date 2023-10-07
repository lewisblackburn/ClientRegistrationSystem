using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS
{
    internal class ClientService
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
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var client in clients)
                {
                    writer.WriteLine($"{client.ClientID},{client.Name},{client.Address},{client.PhoneNumber},{client.Email},{client.ProductCategory}");
                }
            }
        }
    }
}
