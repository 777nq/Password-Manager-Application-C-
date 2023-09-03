// MainForm.cs
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PasswordManagerApp
{
    public partial class MainForm : Form
    {
        private PasswordManager passwordManager = new PasswordManager();

        public MainForm()
        {
            InitializeComponent();
            passwordManager.LoadData();
            UpdatePasswordList();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            PasswordEntryForm entryForm = new PasswordEntryForm();
            if (entryForm.ShowDialog() == DialogResult.OK)
            {
                passwordManager.AddEntry(entryForm.PasswordEntry);
                UpdatePasswordList();
            }
        }

        private void UpdatePasswordList()
        {
            passwordListView.Items.Clear();
            List<PasswordEntry> entries = passwordManager.GetEntries();

            foreach (var entry in entries)
            {
                ListViewItem item = new ListViewItem(new[] { entry.Website, entry.Username, entry.Password });
                passwordListView.Items.Add(item);
            }
        }

        // Other event handlers for the UI elements go here...
    }
}
