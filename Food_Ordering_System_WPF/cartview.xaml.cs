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
    /// Interaction logic for cartview.xaml
    /// </summary>
    public partial class cartview : Window
    {
        MySqlConnection con = new MySqlConnection("server=localhost;port=3306;userName=root;password=;database=food ordering system");
        MySqlCommand mc;
        List<MenuItem> selecteItems = new List<MenuItem>();

        public cartview(List<MenuItem> items)
        {
            InitializeComponent();
            this.selecteItems = items;
            this.DgselectItem.ItemsSource = this.selecteItems;
        }

        public cartview()
        {
            System.Data.DataTable dt = new DataTable();
            DgselectItem.ItemsSource = dt.DefaultView;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new Menu().Show();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String insertQuery = "INSERT INTO cartview(customerNumber) VALUES('" +int.Parse(TextNumber.Text) + "')";
            executeMyQuery(insertQuery);

        }
    }
}
