namespace CRS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            clientNameInput = new TextBox();
            enrollButton = new Button();
            clientAddressInput = new TextBox();
            clientPhoneNumberInput = new TextBox();
            clientEmailInput = new TextBox();
            searchInput = new TextBox();
            searchButton = new Button();
            clientTable = new DataGridView();
            saveButton = new Button();
            clientProductsInput = new TextBox();
            loadButton = new Button();
            ((System.ComponentModel.ISupportInitialize)clientTable).BeginInit();
            SuspendLayout();
            // 
            // clientNameInput
            // 
            clientNameInput.AccessibleName = "";
            clientNameInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            clientNameInput.Location = new Point(632, 173);
            clientNameInput.Name = "clientNameInput";
            clientNameInput.PlaceholderText = "Name";
            clientNameInput.Size = new Size(150, 23);
            clientNameInput.TabIndex = 1;
            clientNameInput.TextChanged += clientNameInput_TextChanged;
            // 
            // enrollButton
            // 
            enrollButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            enrollButton.Location = new Point(632, 318);
            enrollButton.Name = "enrollButton";
            enrollButton.Size = new Size(150, 35);
            enrollButton.TabIndex = 2;
            enrollButton.Text = "Enroll";
            enrollButton.UseVisualStyleBackColor = true;
            enrollButton.Click += enrollButton_Click;
            // 
            // clientAddressInput
            // 
            clientAddressInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            clientAddressInput.Location = new Point(632, 202);
            clientAddressInput.Name = "clientAddressInput";
            clientAddressInput.PlaceholderText = "Address";
            clientAddressInput.Size = new Size(150, 23);
            clientAddressInput.TabIndex = 3;
            // 
            // clientPhoneNumberInput
            // 
            clientPhoneNumberInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            clientPhoneNumberInput.Location = new Point(632, 231);
            clientPhoneNumberInput.Name = "clientPhoneNumberInput";
            clientPhoneNumberInput.PlaceholderText = "Phone number";
            clientPhoneNumberInput.Size = new Size(150, 23);
            clientPhoneNumberInput.TabIndex = 4;
            clientPhoneNumberInput.TextChanged += clientPhoneNumberInput_TextChanged;
            // 
            // clientEmailInput
            // 
            clientEmailInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            clientEmailInput.Location = new Point(632, 260);
            clientEmailInput.Name = "clientEmailInput";
            clientEmailInput.PlaceholderText = "Email";
            clientEmailInput.Size = new Size(150, 23);
            clientEmailInput.TabIndex = 5;
            clientEmailInput.TextChanged += clientEmailInput_TextChanged;
            // 
            // searchInput
            // 
            searchInput.Location = new Point(12, 19);
            searchInput.Name = "searchInput";
            searchInput.PlaceholderText = "Search clients...";
            searchInput.Size = new Size(617, 23);
            searchInput.TabIndex = 6;
            searchInput.TextChanged += searchInput_TextChanged;
            // 
            // searchButton
            // 
            searchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchButton.Location = new Point(635, 12);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(150, 35);
            searchButton.TabIndex = 7;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // clientTable
            // 
            clientTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientTable.Location = new Point(12, 48);
            clientTable.Name = "clientTable";
            clientTable.RowTemplate.Height = 25;
            clientTable.Size = new Size(617, 387);
            clientTable.TabIndex = 8;
            clientTable.CellContentClick += clientTable_CellContentClick;
            // 
            // saveButton
            // 
            saveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveButton.Location = new Point(632, 359);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(150, 35);
            saveButton.TabIndex = 9;
            saveButton.Text = "Save to File";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // clientProductsInput
            // 
            clientProductsInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            clientProductsInput.Location = new Point(632, 289);
            clientProductsInput.Name = "clientProductsInput";
            clientProductsInput.PlaceholderText = "Product Categories";
            clientProductsInput.Size = new Size(150, 23);
            clientProductsInput.TabIndex = 10;
            // 
            // loadButton
            // 
            loadButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            loadButton.Location = new Point(635, 400);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(150, 35);
            loadButton.TabIndex = 11;
            loadButton.Text = "Load from File";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(800, 450);
            Controls.Add(loadButton);
            Controls.Add(clientProductsInput);
            Controls.Add(saveButton);
            Controls.Add(clientTable);
            Controls.Add(searchButton);
            Controls.Add(searchInput);
            Controls.Add(clientEmailInput);
            Controls.Add(clientPhoneNumberInput);
            Controls.Add(clientAddressInput);
            Controls.Add(enrollButton);
            Controls.Add(clientNameInput);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Client Registration System";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)clientTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox clientNameInput;
        private Button enrollButton;
        private TextBox clientAddressInput;
        private TextBox clientPhoneNumberInput;
        private TextBox clientEmailInput;
        private TextBox searchInput;
        private Button searchButton;
        private DataGridView clientTable;
        private Button saveButton;
        private TextBox clientProductsInput;
        private Button loadButton;
    }
}