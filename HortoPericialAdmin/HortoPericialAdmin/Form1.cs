using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using MySql.Data.MySqlClient;


namespace HortoPericialAdmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ArrayList list = new ArrayList();

            databaseconnection NewConnection = new databaseconnection();
            NewConnection.dbConnection();

            MySqlCommand querysql = new MySqlCommand("select * from distrito", databaseconnection.db);

            MySqlDataReader dataread = querysql.ExecuteReader();



            //int count = 0;
            while (dataread.Read())
            {
                // count = count + 1;
                //comboBox1.Items.Add(dataread["id_distrito"].ToString() + " " + "-" + " " + dataread["nome_dist"].ToString());
                list.Add(dataread["id_distrito"].ToString());
                list.Add(dataread["nome_dist"].ToString());
            }

            foreach (string value in list)
            {
                MessageBox.Show(value);
                //Console.WriteLine(value); // bird, plant
            }

           // dataGrid1.ItemsSource = list;
            //comboBox1.Items.Add("Adicionar novo Distrito");
            /*if (count == 0)
            {
                comboBox1.Visibility = Visibility.Hidden;
            }

            else
            {
                comboBox1.Visibility = Visibility.Visible;

            }*/

            databaseconnection.db.Close();




        }
    }
}
