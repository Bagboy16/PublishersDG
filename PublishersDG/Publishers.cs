using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublishersDG
{
    public partial class Publishers : Form
    {
        Operations operations = new Operations();
        DataTable table = new DataTable();

        public Publishers()
        {
            InitializeComponent();
        }

        //Create a Startup method
        private void StartUp() 
        {
            textBoxPubId.Clear();
            textBoxName.Clear();
            textBoxCity.Clear();
            textBoxState.Clear();
            textBoxCountry.Clear();
            buttonAdd.Enabled = true;
            buttonModify.Enabled = false;
            buttonDelete.Enabled = false;
            buttonCancel.Enabled = false;
            textBoxPubId.Focus();
        }

        //Create an UpdateTable method
        private void UpdateTable()
        {
            table = operations.Show();
            dataGridViewPublishers.DataSource = table;
        }

        private void Publishers_Load(object sender, EventArgs e)
        {
            UpdateTable();
            StartUp();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
           //Validate the textboxes
            if (textBoxPubId.Text == "" || textBoxName.Text == "" || textBoxCity.Text == "" || textBoxState.Text == "" || textBoxCountry.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                //Create a new publisher
                Publisher publisher = new Publisher();
                publisher.PubId = textBoxPubId.Text;
                publisher.Name = textBoxName.Text;
                publisher.City = textBoxCity.Text;
                publisher.State = textBoxState.Text;
                publisher.Country = textBoxCountry.Text;

                //Add the publisher to the database
                bool result = operations.Insert(publisher);
                
                //Validate the result
                if (result)
                {
                    UpdateTable();
                    StartUp();
                }

            }
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            //Validate the textboxes 
            if (textBoxPubId.Text == "" || textBoxName.Text == "" || textBoxCity.Text == "" || textBoxState.Text == "" || textBoxCountry.Text == "")
            {
                MessageBox.Show("Porfavor, llene todos los campos");
            }
            else
            {
                //Create a new publisher
                Publisher publisher = new Publisher
                {
                    PubId = textBoxPubId.Text,
                    Name = textBoxName.Text,
                    City = textBoxCity.Text,
                    State = textBoxState.Text,
                    Country = textBoxCountry.Text
                };

                //Update the publisher in the database
                bool result = operations.Update(publisher);

                //Validate the result
                if (result)
                {
                    UpdateTable();
                    StartUp();
                }

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            bool result = operations.Delete(textBoxPubId.Text);
            if (result)
            {
                UpdateTable();
                StartUp();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            StartUp();
        }

        private void dataGridViewPublishers_Click(object sender, EventArgs e)
        {
            //Create a variable to store the row clicked
            DataGridViewRow row = dataGridViewPublishers.CurrentRow;
            //Fill the textboxes with the data
            textBoxPubId.Text = row.Cells["pub_id"].Value.ToString();
            textBoxName.Text = row.Cells["pub_name"].Value.ToString();
            textBoxCity.Text = row.Cells["city"].Value.ToString();
            textBoxState.Text = row.Cells["state"].Value.ToString();
            textBoxCountry.Text = row.Cells["country"].Value.ToString();

            //Disable the add button
            buttonAdd.Enabled = false;
            //Enable the modify and delete buttons
            buttonModify.Enabled = true;
            buttonDelete.Enabled = true;
            buttonCancel.Enabled = true;

        }

        private void textBoxPubId_TextChanged(object sender, EventArgs e)
        {
            //Search the publisher by pubid
            buttonCancel.Enabled = true;
            DataTable dataTable = operations.Search(textBoxPubId.Text);
            dataGridViewPublishers.DataSource = dataTable;
            if (textBoxPubId.Text == "")
            {
                StartUp();
            }
        }
    }
}
