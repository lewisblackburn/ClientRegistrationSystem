using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS
{
    internal class ClientRegistrationSystem
    {
        private ClientService clientService = new ClientService();
        public event EventHandler? ClientListUpdated;

        private void OnClientListUpdated()
        {
            // Invoke the event when the client list is updated
            ClientListUpdated?.Invoke(this, EventArgs.Empty);
        }

        public void AddClient(string name, string address, string phoneNumber, string email, string productCategory)
        {
            Client newClient = new Client
            {
                Name = name,
                Address = address,
                PhoneNumber = phoneNumber,
                Email = email,
                ProductCategory = productCategory
            };

            clientService.AddClient(newClient);

            // Notify subscribers that the client list has been updated
            OnClientListUpdated();
            MessageBox.Show("Client added successfully!");
        }

        public void RemoveClient(Guid clientId)
        {
            clientService.RemoveClient(clientId);
            OnClientListUpdated();
            MessageBox.Show("Client removed successfully!");
        }

        public void SaveToFile(string fileName)
        {
            clientService.SaveToFile(fileName);
            MessageBox.Show("Client details saved to file successfully!");
        }

        public List<Client> GetAllClients()
        {
            return clientService.GetAllClients();
        }

        public List<Client> SearchClients(string query)
        {
            return clientService.FindClients(query);
        }
    }
}
