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
    
    public partial class Member_Login : Window
    {
        public Member_Login()
        {
            InitializeComponent();
        }

        private void Login_button_Click(object sender, RoutedEventArgs e)
        {
            DBclass db =new DBclass();
            String userName = user.Text;
            String password = Password.Password;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `userName`=@un and `password`=@pass",db.getConnection());
            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = userName;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            //string combo = this.combobox.SelectedItem.ToString();
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Log in success");
                for(int i=0; i<table.Rows.Count; i++)
                {
                    if (table.Rows[i]["userType"].ToString() == "manager")
                    {
                       MessageBox.Show("Welcome to Manager Panel");
                        this.Hide();
                        manager_page m = new manager_page();
                        m.ShowDialog();
                    }
                    else if(table.Rows[i]["userType"].ToString() == "staff")
                    {
                        this.Hide();
                        staff_panel sp = new staff_panel();
                        sp.ShowDialog();
                    }
                }
                Close();             
            }
            else
            {
             MessageBox.Show("Please,Enter the correct user id or password!!");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            new MainWindow().Show();

        }


    }
}

