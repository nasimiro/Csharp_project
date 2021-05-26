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
using System.Windows.Shapes;

namespace Food_Ordering_System_WPF
{
    /// <summary>
    /// Interaction logic for manager_page.xaml
    /// </summary>
    public partial class manager_page : Window
    {
        public manager_page()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //register button
            this.Hide();
            Staff_Registration sr = new Staff_Registration();
            sr.ShowDialog();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//edit item properties button
        {
            this.Hide();
            Update_Menu um = new Update_Menu();
            um.ShowDialog();
            //manager m = new manager();
            //m.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Member_Login ml = new Member_Login();
            ml.ShowDialog();
        }
    }
}
