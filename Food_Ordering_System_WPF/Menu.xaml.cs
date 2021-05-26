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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            Show_menu();
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new MainWindow().Show();

        }
        public void Show_menu()
        {
            DBclass db = new DBclass();
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;userName=root;password=;database=food ordering system"))
            {
                conn.Open();
                string query = "SELECT * FROM menu";
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    da.Fill(dt);
            }
            DgItem.ItemsSource = dt.DefaultView;
        }

        private void Order_button_Click(object sender, RoutedEventArgs e)
        {
            List<MenuItem> selectedMenus = new List<MenuItem>();

            if (DgItem.SelectedItems.Count > 0)
            {
                for (int i = 0; i < DgItem.SelectedItems.Count; i++)
                {
                    System.Data.DataRowView selectedRow = (System.Data.DataRowView)DgItem.SelectedItems[i];
                    //string str = Convert.ToString(selectedFile.Row.ItemArray[0]);
                    MenuItem mi = new MenuItem();
                    mi.id = (int)selectedRow.Row.ItemArray[0];
                    mi.name = (string)selectedRow.Row.ItemArray[1];
                    mi.price = (string)selectedRow.Row.ItemArray[2];
                    selectedMenus.Add(mi);
                    //DgselectItem.ItemsSource = selectedMenus;
                }
                this.Hide();
                new cartview(selectedMenus).Show();
            }
        }

        private void DgItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DgItem_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
