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
    /// Interaction logic for staff_panel.xaml
    /// </summary>
    public partial class staff_panel : Window
    {
        public staff_panel()
        {
            InitializeComponent();
        }

        private void Show_orders_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Order_List ol = new Order_List();
            ol.ShowDialog();
        }
    }
}
