using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Food_Ordering_System_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       

        private void Login_button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
             Member_Login ml = new Member_Login();
             ml.ShowDialog();
            //manager_page m2 = new manager_page();
            //m2.ShowDialog();
            //Staff_Registration sr = new Staff_Registration();
            // sr.ShowDialog();
            //Order_List ol = new Order_List();
            //ol.ShowDialog();
            
            Close();
            
        }

        private void order_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Menu m3 = new Menu();
            m3.ShowDialog();
            //new Menu().Show();
            // manager_page m = new manager_page();
            // m.ShowDialog();
        }
    }
}
