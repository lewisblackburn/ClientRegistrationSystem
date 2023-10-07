using System.Data;
using System;
using System.Windows.Forms;

namespace CRS

{
    public partial class Form1 : Form
    {
        private ClientRegistrationSystem CRS = new ClientRegistrationSystem();


        public Form1()
        {
            InitializeComponent();
            // Subscribe to the ClientListUpdated event
            CRS.ClientListUpdated += ClientListUpdatedHandler;
        }

        private void ClientListUpdatedHandler(object sender, EventArgs e)
        {
            // Call the public method to update the clientTable when the client list is updated
            // This means it will update when a client is removed or added.`
            List<Client> clients = CRS.GetAllClients();
            UpdateClientTable(clients);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = searchInput;

            CRS.AddClient("John Doe", "123 Main St", "555-1234", "john.doe@example.com", "Software");
            CRS.AddClient("Jane Smith", "456 Oak St", "555-5678", "jane.smith@example.com", "Laptops & PC");

            List<Client> clients = CRS.GetAllClients();
            UpdateClientTable(clients);
        }

        private void UpdateClientTable(List<Client> clients)
        {
            if (clientTable.Columns.Count == 0)
            {
                clientTable.Columns.Add("ClientID", "Client ID");
                clientTable.Columns.Add("Name", "Name");
                clientTable.Columns.Add("Address", "Address");
                clientTable.Columns.Add("PhoneNumber", "Phone Number");
                clientTable.Columns.Add("Email", "Email");
                clientTable.Columns.Add("ProductCategory", "Product Category");
            }

            // Clear existing rows
            clientTable.Rows.Clear();

            // Populate DataGridView with clients
            foreach (var client in clients)
            {
                clientTable.Rows.Add(
                    client.ClientID,
                    client.Name,
                    client.Address,
                    client.PhoneNumber,
                    client.Email,
                    client.ProductCategory
                );
            }
        }


        private void enrollButton_Click(object sender, EventArgs e)
        {
            CRS.AddClient(this.clientNameInput.Text, this.clientAddressInput.Text, this.clientPhoneNumberInput.Text, this.clientEmailInput.Text, this.clientProductsInput.Text);
            clientNameInput.Text = string.Empty;
            clientAddressInput.Text = string.Empty;
            clientEmailInput.Text = string.Empty;
            clientPhoneNumberInput.Text = string.Empty;
            clientProductsInput.Text = string.Empty;
        }

        private void clientNameInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void clientEmailInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void clientPhoneNumberInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            List<Client> searchResults = CRS.SearchClients(searchInput.Text);
            UpdateClientTable(searchResults);
        }

        private void searchInput_TextChanged(object sender, EventArgs e)
        {
            if (searchInput.Text.Length == 0)
            {
                List<Client> clients = CRS.GetAllClients();
                UpdateClientTable(clients);
            }
            else
            {
                List<Client> searchResults = CRS.SearchClients(searchInput.Text);
                UpdateClientTable(searchResults);
            }
        }

        private void clientTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // This isn't very user friendly and could be improved
            DialogResult dialogResult = MessageBox.Show("Do you want to remove the client?", "DANGER", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DataGridViewRow selectedRow = clientTable.Rows[e.RowIndex];
                Guid clientId = Guid.Parse(selectedRow.Cells["ClientId"].Value.ToString());
                CRS.RemoveClient(clientId);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do nothing
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            CRS.SaveToFile("clients.txt");
        }
    }
}