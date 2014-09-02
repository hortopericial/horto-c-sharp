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
        /// <summary>
        /// inicialização dos compomentes.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            tabControl1.SelectedIndex = 0;
            tabItem1.Visibility = Visibility.Hidden;
            tabItem2.Visibility = Visibility.Hidden;
            tabItem3.Visibility = Visibility.Hidden;
            button3.Visibility = Visibility.Hidden;
            button5.Visibility = Visibility.Hidden;
        }

        // Exit
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Login
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            databaseconnection NewConnection = new databaseconnection();
            NewConnection.dbConnection();
           

            MySqlCommand querysql = new MySqlCommand("select nome_util, password from utilizadores where nome_util='"+this.textBox1.Text+"' and password='"+this.passwordBox1.Password+ "'",databaseconnection.db);

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
                tabItem2.Visibility = Visibility.Hidden;
                tabItem3.Visibility = Visibility.Hidden;
                button2.Visibility = Visibility.Hidden;
                button3.Visibility = Visibility.Visible; 
                int temp = textBox3.Text.Length;
                if (temp == 0)
                {
                    button4.IsHitTestVisible = false;
                }
                else
                {
                    button4.IsHitTestVisible = true;
                }
            }

            else
            {
                MessageBox.Show("Invalid User ID ou Password!!");
            }

            databaseconnection.db.Close();
        }

        // Logout
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            tabItem2.Visibility = Visibility.Hidden;
            tabItem3.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Visible;
            button3.Visibility = Visibility.Hidden;
            button5.Visibility = Visibility.Hidden;
            textBox1.Clear();
            passwordBox1.Clear();
            comboBox1.Items.Clear();
            databaseconnection.db.Close();

        }


        // Inserir distrito
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            textBox3.Clear();
            tabItem1.Visibility = Visibility.Hidden;
            tabItem2.Visibility = Visibility.Hidden;
            tabItem3.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            button5.Visibility = Visibility.Visible;

        }

        // inserir distrito
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            databaseconnection NewConnection = new databaseconnection();
            NewConnection.dbConnection();

           // if ()
           // {
                MySqlCommand querysql = new MySqlCommand("INSERT INTO distrito (nome_dist) Values ('" + this.textBox3.Text + "')", databaseconnection.db);
                querysql.ExecuteNonQuery();
                databaseconnection.db.Close();
                MessageBox.Show("Sucesso!!");

        //    }
        }

        // Botão voltar
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            button5.Visibility = Visibility.Hidden;
            comboBox1.Items.Clear();
        }

        // Verifica se o botão de insirir do distrio pode estar activo ou nao
        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {
            int temp = textBox3.Text.Length;
            if (temp == 0)
            {
                button4.IsHitTestVisible = false;
            }
            else
            {
                button4.IsHitTestVisible = true;
            }
        }

        // inserir concelho
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            textBox3.Clear();
            tabItem1.Visibility = Visibility.Hidden;
            tabItem2.Visibility = Visibility.Hidden;
            tabItem3.Visibility = Visibility.Hidden;
            tabItem4.Visibility = Visibility.Hidden;
            button2.Visibility = Visibility.Hidden;
            button5.Visibility = Visibility.Visible;

            databaseconnection NewConnection = new databaseconnection();
            NewConnection.dbConnection();

            MySqlCommand querysql = new MySqlCommand("select * from distrito", databaseconnection.db);

            MySqlDataReader dataread = querysql.ExecuteReader();
            int count = 0;
            while (dataread.Read())
            {
                count = count + 1;
                comboBox1.Items.Add(dataread["id_distrito"].ToString()+" "+"-"+" "+dataread["nome_dist"].ToString());
            }

            if (count == 0)
            {
                comboBox1.Visibility = Visibility.Hidden;
            }

            else
            {
                comboBox1.Visibility = Visibility.Visible;

            }

            databaseconnection.db.Close();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {

            string selectedItem = comboBox1.Items[comboBox1.SelectedIndex].ToString();
        
            string[] getid_dist = selectedItem.Split(' ');

            databaseconnection NewConnection = new databaseconnection();
            NewConnection.dbConnection();

            // if ()
            // {
            MySqlCommand querysql = new MySqlCommand("INSERT INTO concelho (iddistrito_fk, nome_conc) Values ('"+ getid_dist[0] +"','" + this.textBox2.Text + "')", databaseconnection.db);
            querysql.ExecuteNonQuery();
            databaseconnection.db.Close();
            MessageBox.Show("Sucesso!!");

            //    }
                  
       
        }
    }
}
