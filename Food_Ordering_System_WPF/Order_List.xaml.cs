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
    /// Interaction logic for Order_List.xaml
    /// </summary>
    public partial class Order_List : Window
    {
        MySqlConnection con = new MySqlConnection("server=localhost;port=3306;userName=root;password=;database=food ordering system");
        MySqlCommand mc;
        public Order_List()
        {
            InitializeComponent();
            filldatagrid();
        }

        public void filldatagrid()
        {
            DBclass db = new DBclass();
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;userName=root;password=;database=food ordering system"))
            {
                conn.Open();
                string query = "SELECT * FROM cartview";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    da.Fill(dt);
            }
            DgOrderList.ItemsSource = dt.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)//back button
        {
            this.Hide();
            new Member_Login().Show();
        }
    }
}
