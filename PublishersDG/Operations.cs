using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublishersDG
{
    internal class Operations
    {
        Publisher publisher = new Publisher();
        string sql;
        SqlConnection connection = new SqlConnection();
        SqlCommand command = new SqlCommand();
        internal Operations()
        {
            connection.ConnectionString = "Data Source=(local);Initial Catalog=pubs;Integrated Security=True";
        }

        //Create the insert method
        internal bool Insert(Publisher publisher)
        {
            sql = "INSERT INTO publishers VALUES(@pubid, @name, @city, @state, @country)";
            command.Parameters.AddWithValue("@pubid", publisher.PubId);
            command.Parameters.AddWithValue("@name", publisher.Name);
            command.Parameters.AddWithValue("@city", publisher.City);
            command.Parameters.AddWithValue("@state", publisher.State);
            command.Parameters.AddWithValue("@country", publisher.Country);
            try { 
                command.CommandText = sql;
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                connection.Close();
                MessageBox.Show("Editorial insertada correctamente", "Editorial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                command.Parameters.Clear();
                connection.Close();
                MessageBox.Show(ex.Message, "Editorial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Create the update method
        internal bool Update(Publisher publisher)
        {
            sql = "UPDATE publishers SET pub_name = @name, city = @city, state = @state, country = @country WHERE pub_id = @pubid";
            command.Parameters.AddWithValue("@pubid", publisher.PubId);
            command.Parameters.AddWithValue("@name", publisher.Name);
            command.Parameters.AddWithValue("@city", publisher.City);
            command.Parameters.AddWithValue("@state", publisher.State);
            command.Parameters.AddWithValue("@country", publisher.Country);
            try
            {
                command.CommandText = sql;
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                connection.Close();
                MessageBox.Show("Editorial actualizada correctamente", "Editorial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                command.Parameters.Clear();
                connection.Close();
                MessageBox.Show(ex.Message, "Editorial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        //Create the delete method with a parameter of type string to receive the pubid
        internal bool Delete(string pubid)
        {
            sql = "DELETE FROM publishers WHERE pub_id = @pubid";
            command.Parameters.AddWithValue("@pubid", pubid);
            try
            {
                command.CommandText = sql;
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                connection.Close();
                MessageBox.Show("Editorial eliminada correctamente", "Editorial", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                command.Parameters.Clear();
                connection.Close();
                MessageBox.Show(ex.Message, "Editorial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Create the search method with a parameter of type string to receive the pubid and return a DataTable object
        internal DataTable Search(string pubid)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            sql = "SELECT pub_id AS 'Código', pub_name AS 'Nombre', city AS 'Ciudad', state AS 'Estado', country AS 'País' FROM publishers WHERE pub_id = @pubid";
            command.Parameters.AddWithValue("@pubid", pubid);
            try
            {
                command.CommandText = sql;
                command.Connection = connection;
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
                command.Parameters.Clear();
                return dataTable;
            }
            catch (Exception ex)
            {
                command.Parameters.Clear();
                MessageBox.Show(ex.Message, "Editorial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //Create a show method to return all the records of the publishers table, return a DataTable object
        internal DataTable Show()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            sql = "SELECT pub_id AS 'Código', pub_name AS 'Nombre', city AS 'Ciudad', state AS 'Estado', country AS 'País' FROM publishers";
            try
            {
                command.CommandText = sql;
                command.Connection = connection;
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Editorial", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        

    }

}
