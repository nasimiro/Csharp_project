using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Food_Ordering_System_WPF
{
    /// <summary>
    /// Interaction logic for Update_Menu.xaml
    /// </summary>
    public partial class Update_Menu : Window
    {
        MySqlConnection con = new MySqlConnection("server=localhost;port=3306;userName=root;password=;database=food ordering system");
        MySqlCommand mc;

        public Update_Menu()
        {
            InitializeComponent();
            populateDG();

        }
        public void populateDG()
        {
            con.Open();
            string query = "SELECT * FROM menu";
            DataTable dt = new DataTable();
            using (MySqlDataAdapter da = new MySqlDataAdapter(query, con))
                da.Fill(dt);
            DG.ItemsSource = dt.DefaultView;
            DG.SelectionMode = DataGridSelectionMode.Extended; DG.SelectionMode = DataGridSelectionMode.Extended;
        }
        public void ConnectionOpen()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void ConnectionClose()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

        public void executeMyQuery(String query)
        {
            try
            {
                ConnectionOpen();
                mc = new MySqlCommand(query, con);
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
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Member_Login m = new Member_Login();
            m.Show();
            Close();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            String insertQuery = "INSERT INTO menu(itemName,itemPrice) VALUES('" + itemname_txt.Text + " ',' " + itemprice_txt.Text + "')";
            executeMyQuery(insertQuery);
            populateDG();

        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            String deleteQuery = "DELETE FROM menu WHERE id=" + int.Parse(id_txt.Text);
            executeMyQuery(deleteQuery);
            populateDG();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            String updateQuery = "UPDATE menu SET itemName='" + itemname_txt.Text + " ',itemPrice=' " + itemprice_txt.Text + "' WHERE id=" + int.Parse(id_txt.Text);
            executeMyQuery(updateQuery);
            populateDG();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            MySqlDataReader mdr;
            String select = "SELECT * FROM menu WHERE id=" + int.Parse(id_txt.Text);
            mc = new MySqlCommand(select, con);
            ConnectionOpen();
            mdr = mc.ExecuteReader();

            if (mdr.Read())
            {
                itemname_txt.Text = mdr.GetString("itemName");
                itemprice_txt.Text = mdr.GetString("itemPrice");
                id_txt.Text = mdr.GetString("id");
            }
            else
            {
                MessageBox.Show("Item not Found");
            }
            ConnectionClose();


        }

        private void DG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
