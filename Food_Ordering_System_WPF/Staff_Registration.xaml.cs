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
    /// Interaction logic for Staff_Registration.xaml
    /// </summary>
    public partial class Staff_Registration : Window
    {
        DBclass db = new DBclass();
        public Staff_Registration()
        {
            InitializeComponent();
            fillDataGrid();
        }

        public void fillDataGrid()
        {
            string query = "SELECT * FROM staff";
            DataTable dt = new DataTable();
            using (MySqlDataAdapter da = new MySqlDataAdapter(query, db.getConnection()))
            da.Fill(dt);
            staff_list.ItemsSource = dt.DefaultView;
            staff_list.SelectionMode = DataGridSelectionMode.Extended; staff_list.SelectionMode = DataGridSelectionMode.Extended;
        }
        
        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btnsave_Click(object sender, RoutedEventArgs e)
        {
            String query = "INSERT INTO staff(id,name,address,email) VALUES('" + txtid.Text + "','" + txtName.Text + "','"+txtaddres.Text+"','"+txtemail.Text+"')";         

            MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
            db.executeMyQuery(query);
            fillDataGrid();
        }

        private void Btnremove_Click(object sender, RoutedEventArgs e)
        {
            String query = "DELETE FROM staff WHERE id=" + int.Parse(txtid.Text);
            db.executeMyQuery(query);
            fillDataGrid();
        }

        private void Btnupdate_Click(object sender, RoutedEventArgs e)
        {
            String query = "UPDATE staff SET name='" + txtName.Text + " ', address='"+txtaddres.Text+"',email='"+txtemail.Text+"' WHERE id=" + int.Parse(txtid.Text);
            db.executeMyQuery(query);
            fillDataGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            manager_page m = new manager_page();
            m.ShowDialog();
        }
    }
}
