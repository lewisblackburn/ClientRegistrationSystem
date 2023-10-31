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
        private ClientHandler clientHandler = new ClientHandler("Server=localhost;Database=CRS;Uid=root;Pwd=root;");
        public event EventHandler? ClientListUpdated;

        private void OnClientListUpdated()
        {
            // Invoke the event when the clients table is updated
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

            clientHandler.AddClient(newClient);

            // Notify subscribers that the clients table has been updated
            OnClientListUpdated();
            MessageBox.Show("Client added successfully!");
        }

        public void RemoveClient(Guid clientId)
        {
            clientHandler.RemoveClient(clientId);
            OnClientListUpdated();
            MessageBox.Show("Client removed successfully!");
        }

        public void SaveToFile(string fileName)
        {
            clientHandler.SaveToFile(fileName);
            MessageBox.Show("Client details saved to file successfully!");
        }

        public List<Client> GetAllClients()
        {
            return clientHandler.GetAllClients();
        }

        public List<Client> SearchClients(string query)
        {
            return clientHandler.FindClients(query);
        }
    }
}
