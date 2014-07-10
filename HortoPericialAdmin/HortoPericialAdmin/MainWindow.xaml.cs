using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;


namespace HortoPericialAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tabControl1.SelectedIndex = 0;
            tabItem2.Visibility = Visibility.Hidden;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            databaseconnection NewConnection = new databaseconnection();
            NewConnection.dbConnection();

            MySqlCommand querysql = new MySqlCommand("select nome_util, password from utilizadores where nome_util='"+this.textBox1.Text+"' and password='"+this.textBox2.Text+ "'",databaseconnection.db);

            MySqlDataReader dataread = querysql.ExecuteReader();
            int count = 0;
            while (dataread.Read())
            {
                count = count + 1;
            }

            if (count == 1)
            {
                MessageBox.Show("Login with sucess!!");
                tabControl1.SelectedIndex = 1;
                tabItem1.Visibility = Visibility.Hidden;            
                tabItem2.Visibility = Visibility.Visible;
                button2.Visibility = Visibility.Hidden;
            }

            else
            {
                MessageBox.Show("Invalid User ID ou Password!!");
            }

            databaseconnection.db.Close();
        }
    }
}
