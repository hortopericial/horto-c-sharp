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
            tabItem4.Visibility = Visibility.Hidden;
            tabItem5.Visibility = Visibility.Hidden;
            tabItem6.Visibility = Visibility.Hidden;
            tabItem7.Visibility = Visibility.Hidden;
            tabItem8.Visibility = Visibility.Hidden;
            tabItem9.Visibility = Visibility.Hidden;
            tabItem10.Visibility = Visibility.Hidden;
            tabItem11.Visibility = Visibility.Hidden;
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
            MySqlCommand querysql = new MySqlCommand("select nome_util, password from utilizadores where nome_util='" + this.textBox1.Text + "' and password='" + this.passwordBox1.Password + "'", databaseconnection.db);
            MySqlDataReader dataread = querysql.ExecuteReader();
            int count = 0;
            while (dataread.Read())
            {
                count = 1;
            }

            if (count == 1)
            {

                MessageBox.Show("Login with sucess!!");
                tabControl1.SelectedIndex = 1;
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
            button2.Visibility = Visibility.Visible;
            button3.Visibility = Visibility.Hidden;
            button5.Visibility = Visibility.Hidden;
            textBox1.Clear();
            passwordBox1.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            databaseconnection.db.Close();

        }

        // Inserir distrito menu
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 2;
   
            button5.Visibility = Visibility.Visible;

        }

        // inserir distrito
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            databaseconnection NewConnection = new databaseconnection();
            NewConnection.dbConnection();

            MySqlCommand querysql = new MySqlCommand("INSERT INTO distrito (nome_dist) Values ('" + this.textBox3.Text + "')", databaseconnection.db);
            querysql.ExecuteNonQuery();
            databaseconnection.db.Close();
            MessageBox.Show("Sucesso!!");

        }

        // Botão voltar
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            button5.Visibility = Visibility.Hidden;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
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
            textBox2.Clear();
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
                comboBox1.Items.Add(dataread["id_distrito"].ToString() + " " + "-" + " " + dataread["nome_dist"].ToString());
            }

            comboBox1.Items.Add("Adicionar novo Distrito");
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
        
        // inserir concelho
        private void button7_Click(object sender, RoutedEventArgs e)
        {

            string selectedItem = comboBox1.Items[comboBox1.SelectedIndex].ToString();

            string[] getid_dist = selectedItem.Split(' ');

            databaseconnection NewConnection = new databaseconnection();
            NewConnection.dbConnection();

            MySqlCommand querysql = new MySqlCommand("INSERT INTO concelho (iddistrito_fk, nome_conc) Values ('" + getid_dist[0] + "','" + this.textBox2.Text + "')", databaseconnection.db);
            querysql.ExecuteNonQuery();
            databaseconnection.db.Close();
            MessageBox.Show("Sucesso!!");

        }

        // verifica a selecção da combobox1
        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string selectedItem = comboBox1.Items[comboBox1.SelectedIndex].ToString();
                string teste = comboBox1.SelectedIndex.ToString();
                if (String.Compare(selectedItem, "Adicionar novo Distrito") == 0)
                {
                    MessageBox.Show(teste);

                }
                else
                {
                    MessageBox.Show(teste);
                }
            }
            catch (Exception E)
            {
                return;
            }            
        }

        // questionset menu botão
        private void button8_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            textBox4.Clear();
            button5.Visibility = Visibility.Visible;
            
            int temp = textBox4.Text.Length;
            if (temp == 0)
            {
                button10.IsHitTestVisible = false;
            }
            else
            {
                button10.IsHitTestVisible = true;
            }
        }

        // pre-diagnostico menu botão
        private void button9_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 5;

            button5.Visibility = Visibility.Visible;

            databaseconnection NewConnection = new databaseconnection();
            NewConnection.dbConnection();

            MySqlCommand querysql = new MySqlCommand("select * from Questionset", databaseconnection.db);
            
            MySqlDataReader dataread = querysql.ExecuteReader();
           
            int count = 0;
            comboBox2.Items.Add("Escolha a sua QuestionSet");
            while (dataread.Read())
            {
                count = count + 1;
                comboBox2.Items.Add(dataread["id_qs"].ToString() + " " + "-" + " " + dataread["name_qs"].ToString());
            }

            
            if (count == 0)
            {
                comboBox2.Visibility = Visibility.Visible;
            }

            else
            {
                comboBox2.Visibility = Visibility.Visible;

            }
            dataread.Close();

            MySqlCommand querysql1 = new MySqlCommand("select * from pre_diagnostico", databaseconnection.db);
            MySqlDataReader dataread1 = querysql1.ExecuteReader();

            comboBox3.Items.Add("0 - Esta é a primeira pergunta!");
            while (dataread1.Read())
            {
                comboBox3.Items.Add(dataread1["id_pergunta"].ToString() + " " + "-" + " " + dataread1["pergunta"].ToString());
            }
            dataread1.Close();
            databaseconnection.db.Close();

            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
           

        }

        //inserir questionset
        private void button10_Click(object sender, RoutedEventArgs e)
        {
            databaseconnection NewConnection = new databaseconnection();
            NewConnection.dbConnection();

            MySqlCommand querysql = new MySqlCommand("INSERT INTO questionset (name_qs) Values ('" + this.textBox4.Text + "')", databaseconnection.db);
            querysql.ExecuteNonQuery();
            databaseconnection.db.Close();
            MessageBox.Show("Sucesso!!");
        }
        // testa se o botão de inserir questionset pode ou não estar ativo
        private void textBox4_TextChanged(object sender, TextChangedEventArgs e)
        {
            int temp = textBox4.Text.Length;
            if (temp == 0)
            {
                button10.IsHitTestVisible = false;
            }
            else
            {
                button10.IsHitTestVisible = true;
            }
        }

        // inserir deficiencias menu botão
        private void button13_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 8;
            textBox8.Clear();
            button5.Visibility = Visibility.Visible;

        }

        // inserir deficieencia
        private void button16_Click(object sender, RoutedEventArgs e)
        {
            databaseconnection NewConnection = new databaseconnection();
            NewConnection.dbConnection();

            MySqlCommand querysql = new MySqlCommand("INSERT INTO deficiencias (nome_deficiencia) Values ('" + this.textBox8.Text + "')", databaseconnection.db);
            querysql.ExecuteNonQuery();
            databaseconnection.db.Close();
            MessageBox.Show("Sucesso!!");
        }

        // botão menu questionarios
        private void button17_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 6;

            button5.Visibility = Visibility.Visible;


            databaseconnection NewConnection = new databaseconnection();
            NewConnection.dbConnection();

            MySqlCommand querysql = new MySqlCommand("select * from Questionset", databaseconnection.db);

            MySqlDataReader dataread = querysql.ExecuteReader();

            int count = 0;
            comboBox4.Items.Add("Escolha a sua QuestionSet");
            while (dataread.Read())
            {
                count = count + 1;
                comboBox4.Items.Add(dataread["id_qs"].ToString() + " " + "-" + " " + dataread["name_qs"].ToString());
            }

            databaseconnection.db.Close();

        }

        private void button18_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 7;

            button5.Visibility = Visibility.Visible;

            databaseconnection NewConnection = new databaseconnection();
            NewConnection.dbConnection();

            databaseconnection.db.Close();
        }

        private void button19_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 9;

            button5.Visibility = Visibility.Visible;

            databaseconnection NewConnection = new databaseconnection();
            NewConnection.dbConnection();

            databaseconnection.db.Close();
        }

        private void button20_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 10;

            button5.Visibility = Visibility.Visible;

            databaseconnection NewConnection = new databaseconnection();
            NewConnection.dbConnection();

            databaseconnection.db.Close();
        }

        // inserir pergunta de prediagnostico e fazer inserção seguinte
        private void button11_Click(object sender, RoutedEventArgs e)
        {
            String temp1="";
            String selectedItem1 = comboBox2.Items[comboBox2.SelectedIndex].ToString();
            String selectedItem2 = comboBox3.Items[comboBox3.SelectedIndex].ToString();
            String[] getid_qs = selectedItem1.Split(' ');
            String[] getid_pred = selectedItem2.Split(' ');
            int aux = Convert.ToInt32(getid_pred[0]);
            int aux1 = Convert.ToInt32(getid_qs[0]);

            if (radioButton2.IsChecked == true)
            {
                temp1 = radioButton2.Content.ToString();
                MessageBox.Show(temp1);
            }
            if (radioButton1.IsChecked == true)
            {
                temp1 = radioButton1.Content.ToString();
                MessageBox.Show(temp1);
            }
            if(radioButton2.IsChecked == false && radioButton1.IsChecked == false)
            {
                temp1 = null;
                MessageBox.Show(temp1);
            }
            databaseconnection NewConnection = new databaseconnection();
            NewConnection.dbConnection();



            if (String.Compare(selectedItem2, "0 - Esta é a primeira pergunta!") == 0)
            {
                MySqlCommand querysql = new MySqlCommand("INSERT INTO pre_diagnostico (pergunta, resposta, flag, id_qs_fk_pd) Values ('" + this.textBox5.Text + "', '" + this.textBox6.Text + "', '" + temp1 + "','" + aux1 + "')", databaseconnection.db);
                querysql.ExecuteNonQuery();
                MessageBox.Show("teste!!");

                MySqlCommand querysql1 = new MySqlCommand("SELECT id_pergunta FROM pre_diagnostico WHERE pergunta = '" + this.textBox5.Text + "'", databaseconnection.db);
                MySqlDataReader dataread = querysql1.ExecuteReader();
                String readaux="";
                while (dataread.Read())
                {
                    readaux = dataread["id_pergunta"].ToString();
                }
                dataread.Close();
                int getid_perg = Convert.ToInt32(readaux);

                MySqlCommand querysql2 = new MySqlCommand("UPDATE questionset SET pre_diagnostico_perguntaid = '" + getid_perg + "' WHERE id_qs = '" + aux1 + "'", databaseconnection.db);
                querysql2.ExecuteNonQuery();
                                
                MessageBox.Show("Sucesso!!");

            }
            else
            {
                MySqlCommand querysql = new MySqlCommand("INSERT INTO pre_diagnostico (pergunta, resposta, flag, id_qs_fk_pd) Values ('" + this.textBox5.Text + "', '" + this.textBox6.Text + "', '" + temp1 + "','" + aux1 + "')", databaseconnection.db);
                querysql.ExecuteNonQuery();
                MessageBox.Show("teste!!");

                MySqlCommand querysql1 = new MySqlCommand("SELECT id_pergunta FROM pre_diagnostico WHERE pergunta = '" + this.textBox5.Text + "'", databaseconnection.db);
                MySqlDataReader dataread = querysql1.ExecuteReader();
                String readaux = "";
                while (dataread.Read())
                {
                    readaux = dataread["id_pergunta"].ToString();
                }
                dataread.Close();
                int getid_perg = Convert.ToInt32(readaux);

                MySqlCommand querysql2 = new MySqlCommand("UPDATE pre_diagnostico SET pre_diagnostico_id_pergunta= '" + getid_perg + "' WHERE id_pergunta = '" + aux + "'", databaseconnection.db);
                querysql2.ExecuteNonQuery();

                MessageBox.Show("Sucesso!!");
            }

            MessageBox.Show("Sucesso!!");

            radioButton1.IsChecked = false;
            radioButton2.IsChecked = false;
            textBox5.Clear();
            textBox6.Clear();
            comboBox3.Items.Clear();

            MySqlCommand querysql3 = new MySqlCommand("select * from pre_diagnostico", databaseconnection.db);
            MySqlDataReader dataread1 = querysql3.ExecuteReader();
            int count = 0;
            while (dataread1.Read())
            {
                count++;
                comboBox3.Items.Add(dataread1["id_pergunta"].ToString() + " " + "-" + " " + dataread1["pergunta"].ToString());
            }
        

            dataread1.Close();
            databaseconnection.db.Close();

            comboBox3.SelectedIndex = count-1;

        }
    }
}
