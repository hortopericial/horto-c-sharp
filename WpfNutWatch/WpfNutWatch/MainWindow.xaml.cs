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

namespace WpfNutWatch
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
            tabItem1.Visibility = Visibility.Hidden;
            tabItem2.Visibility = Visibility.Hidden;
            buttonLogout.Visibility = Visibility.Hidden;
        }

        private void buttonSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            buttonLogout.Visibility = Visibility.Visible;
        }

        private void buttonLogout_Click(object sender, RoutedEventArgs e)
        {
            buttonLogout.Visibility = Visibility.Hidden;
            tabControl1.SelectedIndex = 0;
            textBoxPwd.Clear();
            textBoxUser.Clear();
        }

        private void buttonPagIni_Click(object sender, RoutedEventArgs e)
        {
            FormPagIni formpi = new FormPagIni();
            formpi.ShowDialog();
        }

        private void buttonDis_Click(object sender, RoutedEventArgs e)
        {
            Distrito formDis = new Distrito();
            formDis.ShowDialog();
        }
        
        // menu para inserir concelho
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand verifica = new MySqlCommand("SELECT * FROM distrito", DBConnect.db);
            MySqlDataReader read = verifica.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                count = count + 1;
            }
            DBConnect.db.Close();

            if (count != 0)
            {
                Concelho formCon = new Concelho();
                formCon.ShowDialog();
            }
            else 
            {
      
                if (MessageBox.Show("Não tem Distritos inseridos, quer inserir agora?","Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                    Distrito formDis = new Distrito();
                    formDis.ShowDialog();
                    Concelho formCon = new Concelho();
                    formCon.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Operação anulada!!!");
                }

            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            FormNoti formnoti = new FormNoti();
            formnoti.ShowDialog();
        }

        private void button3DefEsp_Click(object sender, RoutedEventArgs e)
        {
            Especie_Defeciencia formDefEsp = new Especie_Defeciencia();
            formDefEsp.ShowDialog();
        }
        //question set
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            QuestionSet quest = new QuestionSet();
            quest.ShowDialog();
        }
        //perguntas de diagnostico
        private void buttonPerDia_Click(object sender, RoutedEventArgs e)
        {
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand verifica = new MySqlCommand("SELECT * FROM questionset", DBConnect.db);
            MySqlDataReader read = verifica.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                count = count + 1;
            }
            DBConnect.db.Close();

            if (count != 0)
            {
                Questionario pergunt = new Questionario();
                pergunt.ShowDialog();
            }
            else
            {
                if (MessageBox.Show("Não tem QuestionSet inserido, quer inserir agora?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    QuestionSet quest = new QuestionSet();
                    quest.ShowDialog();
                    Questionario pergunt = new Questionario();
                    pergunt.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Operação anulada!!!");
                }
            }           
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Contactos contact = new Contactos();
            contact.ShowDialog();
        }
    }
}
