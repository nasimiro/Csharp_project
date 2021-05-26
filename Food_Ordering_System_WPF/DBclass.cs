using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Food_Ordering_System_WPF
{
    class DBclass
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;userName=root;password=;database=food ordering system");
        public void ConnectionOpen()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void ConnectionClose()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
        public void executeMyQuery(String query)
        {
            try
            {
                ConnectionOpen();
               MySqlCommand mc = new MySqlCommand(query, connection);
                if (mc.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Query Executed");
                }
                else
                {
                    MessageBox.Show("Query is not Executed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                ConnectionClose();
            }
        }
        /*public void Page_load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM menu", conn);
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds, "Menu");
            DataGrid_1.Datasource = ds.Tables["menu"].DefualView;

        }*/
    }
    
}
